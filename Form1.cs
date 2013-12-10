using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using csharp_android_designer_tool.Classes;
using csharp_android_designer_tool.Custom;
using System.Xml;

namespace csharp_android_designer_tool
{
    public partial class Form1 : Form
    {
        MyApplication mApp = MyApplication.getInstance();

        ToolBoxButton linearlayout = new ToolBoxButton();
        ToolBoxButton relativelayout = new ToolBoxButton();

        BasePanel panelNodeSelected = null;
        public Form1()
        {
        
            InitializeComponent();
            Console.WriteLine("Form1 {0}", panel_view.Height);
           
            mApp.EditViewSize.height = panel_view.Height;
        }

        private void onNodeSelected(BasePanel panelNode)
        {
            Console.WriteLine("onNodeSelected");
            this.panelNodeSelected = panelNode;
            FormProperties propertiesDlg = FormProperties.getInstance();
            propertiesDlg.Show();
        }
        //处理按钮消息，包括移除控件
        protected override bool ProcessDialogKey(Keys keyData)
        {
            Console.WriteLine("keycode={0}",keyData);
            if (panelNodeSelected == null)
            {
                return false;
            }
            if (keyData == Keys.Back && !panelNodeSelected.IsRoot)
            {
                // Console.WriteLine("escape");
                panel_view.Controls.Remove(this.panelNodeSelected);
                return true;
            }
            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Form1_Load");
            //panel_view
            panel_view.m_onNodeSelectedDelegate += onNodeSelected;

            //Other
            this.ContextMenuStrip = contextMenuStrip1;
            this.KeyPreview = true;
            resize_pictureBox();

            Button label_layout = new Button();
            
            label_layout.Width = linearlayout.Width;
            label_layout.Height = linearlayout.Height/2;
            label_layout.Text = "容器布局";
            flowLayoutPanel1.Controls.Add(label_layout);

            //LinearLayout
            linearlayout.ViewClass = ViewClass.LinearLayout;
            linearlayout.Text = "LinearLayout";
            linearlayout.MouseUp += new MouseEventHandler(button_MouseUp);
            linearlayout.m_onDragTipShowDelegate += panel_view.showDragTips;
            flowLayoutPanel1.Controls.Add(linearlayout);
            
            //RelativeLayout
            relativelayout.Text = "RelativeLayout";
            relativelayout.ViewClass = ViewClass.RelativeLayout;
            relativelayout.MouseUp += new MouseEventHandler(button_MouseUp);
            relativelayout.m_onDragTipShowDelegate += panel_view.showDragTips;
            flowLayoutPanel1.Controls.Add(relativelayout);

            this.Resize += new EventHandler(Form1_Resize);
            this.splitContainer1.Panel2.Resize += new EventHandler(Form1_Resize);
        }

        void button_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender == linearlayout)
            {
                Console.WriteLine(" linearlayout key up ({0},{1})", e.X,e.Y);
            }
            else if (sender == relativelayout)
            {
                Console.WriteLine(" relativelayout key up");
            }
        }

        void Form1_Resize(object sender, EventArgs e)
        {
            resize_pictureBox();
        }

        private void resize_pictureBox()
        {
            splitContainer1.SplitterDistance = linearlayout.Width;
            int panel_height = splitContainer1.Panel2.Height;
            int panel_width = splitContainer1.Panel2.Width;

            float ratio = (float)panel_height/(float)panel_view.Height; 
            Console.WriteLine("ratio={0}",ratio);
            panel_view.Height = panel_height;
            panel_view.Width = panel_height * mApp.PhoneSize.width / mApp.PhoneSize.height;
            panel_view.Left = (panel_width - panel_view.Width) / 2;
            
            mApp.EditViewSize.width = panel_view.Width;
            mApp.EditViewSize.height = panel_view.Height;

            linearlayout.PanelViewLeft = panel_view.Left;
            relativelayout.PanelViewLeft = panel_view.Left;

            panel_view.resize_for_pic_status_bar();
            visitControlsRecursively(panel_view, ratio);
        }
        private void visitControlsRecursively(System.Windows.Forms.Control control,float ratio) {
            if (!control.HasChildren)
            {
                return;
            }
            else
            {
                foreach (Control ctrl in control.Controls)
                {
                    if (ctrl is Label||
                        ctrl is DragTip)
                    {
                       // Console.WriteLine("is picturebox");
                        
                        continue;
                    }

                    ctrl.Left = (int)((float)ctrl.Left * ratio);
                    ctrl.Top = (int)((float)ctrl.Top * ratio);
                    ctrl.Width = (int)((float)ctrl.Width * ratio);
                    ctrl.Height = (int)((float)ctrl.Height * ratio);
                    visitControlsRecursively(ctrl,ratio);
                }
            }
        }

        private void 分辨率ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormToolBar _FormToolBar = FormToolBar.getInstance();
            if (_FormToolBar.m_onResolutionReceiveDelegate == null)
            {
                _FormToolBar.m_onResolutionReceiveDelegate += onResolutionReceive;
            }
            _FormToolBar.Show();
        }
        
        private void onResolutionReceive(string text) {

       //     MessageBox.Show(BaseProperties.a.ToString());
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout aboutDlg = new FormAbout();
            aboutDlg.ShowDialog();
            aboutDlg = null;
        }

        XmlDocument doc = null;
        XmlElement root = null;
        XmlElement data = null;
        private void 输出xmlToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //========================写replace.xml文件==============================
            doc = new XmlDocument(); // 创建dom对象

            panel_view.mViewClass = ViewClass.RelativeLayout;
            if (panel_view.mViewClass == ViewClass.RelativeLayout)
            {
                root = doc.CreateElement(androidView.relativelayout); // 创建根节点album
            }
            else if (panel_view.mViewClass == ViewClass.LinearLayout)
            {
                root = doc.CreateElement(androidView.linearlayout); // 创建根节点album
                root.SetAttribute(androidView.orientation, Orientation_Phone.Vertical.ToString());
            }
            root.SetAttribute("xmlns:android", "http://schemas.android.com/apk/res/android");
            root.SetAttribute("xmlns:tools", "http://schemas.android.com/tools");
            //root.SetAttribute(androidView.layout_width, "match_parent");
            root.SetAttribute(androidView.layout_width, LayoutProperty.match_parent.ToString());
            root.SetAttribute(androidView.layout_height, LayoutProperty.match_parent.ToString());
            
            doc.AppendChild(root);    //  加入到xml document
            genXmlRecursively(panel_view, root);
            
            //MessageBox.Show("正在开发...");
            //MessageBox.Show(doc.ToString());
            //MessageBox.Show(doc.OuterXml);
            FormXmlOutput xmloutputdlg = new FormXmlOutput();
            xmloutputdlg.setText(doc.OuterXml.Replace("xml:","android:"));
            xmloutputdlg.ShowDialog();
          //  doc.Save(@"c:\data.xml");
        }

        //深度优先遍历的同时构建xml树
        private void genXmlRecursively(System.Windows.Forms.Control control, XmlElement root)
        {
            if (!control.HasChildren)
            {
                return;
            }
            else
            {
                foreach (Control ctrl in control.Controls)
                {
                    if (ctrl is Label ||
                        ctrl is DragTip)
                    {
                        // Console.WriteLine("is picturebox");

                        continue;
                    }
                    BasePanel node = (BasePanel)ctrl;
                    Console.WriteLine("node={0}",node.mViewClass.ToString());
                    XmlElement xmlnode = doc.CreateElement(node.mViewClass.ToString()); // 创建根节点album
                    root.AppendChild(xmlnode);
                    genXmlRecursively(ctrl, xmlnode);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
