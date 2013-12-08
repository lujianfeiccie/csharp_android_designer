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

namespace csharp_android_designer_tool
{
    public partial class Form1 : Form
    {
        MyApplication mApp = MyApplication.getInstance();

        TooBoxButton linearlayout = new TooBoxButton();
        TooBoxButton relativelayout = new TooBoxButton();


        public Form1()
        {
        
            InitializeComponent();
            Console.WriteLine("Form1 {0}", panel_view.Height);
           
            mApp.EditViewSize.height = panel_view.Height;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Form1_Load");
            this.ContextMenuStrip = contextMenuStrip1;
            resize_pictureBox();

            Button label_layout = new Button();
            label_layout.Width = linearlayout.Width;
            label_layout.Height = linearlayout.Height/2;
            label_layout.Text = "容器布局";
            flowLayoutPanel1.Controls.Add(label_layout);

            //LinearLayout
            linearlayout.Text = "LinearLayout";
            linearlayout.MouseUp += new MouseEventHandler(button_MouseUp);
            linearlayout.m_onDragTipShowDelegate += panel_view.showDragTips;
            flowLayoutPanel1.Controls.Add(linearlayout);
            
            //RelativeLayout
            relativelayout.Text = "RelativeLayout";
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
            _FormToolBar.TopMost = true;
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

        private void 输出xmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("正在开发...");
        }
    }
}
