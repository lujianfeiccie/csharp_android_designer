using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using csharp_android_designer_tool.Properties;

namespace csharp_android_designer_tool.Custom
{
    public class BasePanel:Panel
    {
        MyApplication mApp = MyApplication.getInstance();
        


        private DragTip mDragTip = new DragTip();
        bool isDown = false;
        bool isRoot = false;
        Point point_down = new Point();
        Label lbl_status_bar = new Label();

        //拉伸拖动指示
        int const_width = 10;
        int const_height = 10;
        int padding = 1;


        //为实现删除结点功能，加入委托通知上层删除结点
        public delegate void onNodeSelectedDelegate(BasePanel node);
        public onNodeSelectedDelegate m_onNodeSelectedDelegate;
        public bool IsRoot
        {
            get { return isRoot; }
            set { this.isRoot = value;
                if (isRoot)
                {
                    if (!Controls.Contains(lbl_status_bar))
                    {
                        this.Controls.Add(lbl_status_bar);
                    }
                }
            }
        }
        public BasePanel():  this(false){
        }
        public BasePanel(bool isRoot) {
            mDragTip.Visible = false;
            this.isRoot = isRoot;
            this.Controls.Add(mDragTip);
            this.MouseMove += new MouseEventHandler(BasePanel_MouseMove);
            this.MouseDown += new MouseEventHandler(BasePanel_MouseDown);
            this.MouseUp += new MouseEventHandler(BasePanel_MouseUp);
            this.Focus();
            
         //   this.Focus();
         //   this.Resize += new EventHandler(BasePanel_Resize);

          
          //  resize_for_pic_status_bar();
          
        }
       

        void BasePanel_Resize(object sender, EventArgs e)
        {
            resize_for_pic_status_bar();
        }
        //调整状态条
        public void resize_for_pic_status_bar()
        {
            if (isRoot)
            {
                lbl_status_bar.Width = this.Width;
                lbl_status_bar.Height = (int)((float)mApp.EditViewSize.height * 0.05);
               // lbl_status_bar.Height = 100;
                lbl_status_bar.BackColor = Color.Black;
                Console.WriteLine("resize_for_pic_status_bar isRoot {0} width={1}",
                    mApp.EditViewSize.height, this.Width);
            }
        }

        protected virtual void BasePanel_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("up ({0},{1})",e.X,e.Y);
            isDown = false;
            if (m_onNodeSelectedDelegate != null)
            {
                m_onNodeSelectedDelegate(this);
            }
           // mDragTip.Visible = false;
        }

        protected virtual void BasePanel_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("down ({0},{1})", e.X, e.Y);
            isDown = true;
            point_down.X = e.X;
            point_down.Y = e.Y;
         //   mDragTip.Visible = true;
        }

        protected virtual void BasePanel_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (isDown && !isRoot)
            {

                //计算位移增量
                int tranx = e.X - point_down.X;
                int trany = e.Y - point_down.Y;

                if (e.X >= 0 && e.X <= const_width   //拽左上角
                && e.Y >= 0 && e.Y <= const_height)
                {
                     
                    Console.WriteLine("drag left top");
                    this.Left = this.Left + tranx;
                    this.Top = this.Top + trany;
                    int width_increment =  -tranx;
                    int height_increment = -trany;

                    this.Width = this.Width + width_increment;
                    this.Height = this.Height + height_increment;
                }
                else
                {
                    //改变自身位置
                    this.Left = this.Left + tranx;
                    this.Top = this.Top + trany;
                }
            }
        }
        //显示拖动提示
        public virtual void showDragTips(int x,int y,bool visible,bool isInEditView,bool isUp)
        {
          //  Console.WriteLine("showDragTips");
            mDragTip.Visible = visible;
            mDragTip.Left = x;
            mDragTip.Top = y;
            if (isInEditView && isUp)
            {
                BasePanel mBasePanel = new BasePanel(false);
                mBasePanel.Left = x;
                mBasePanel.Top = y;
                mBasePanel.BackColor = Color.Transparent;
                mBasePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                mBasePanel.Width = mApp.EditViewSize.width / 2;
                mBasePanel.Height = mApp.EditViewSize.width / 3;
                mBasePanel.isRoot = false;
                mBasePanel.m_onNodeSelectedDelegate = m_onNodeSelectedDelegate;
                this.Controls.Add(mBasePanel);
            }
        }
      
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
           // Console.WriteLine("onPaint");
            //e.Graphics.DrawLine(Pens.Black, 0, this.Height / 2, this.Width, this.Height / 2);
            if (!isRoot)
            {
               

                //绘制拖动指示框
                //左上角
                e.Graphics.DrawRectangle(Pens.Black,
                     -padding, -padding,
                     const_width, const_height);

                //右上角
                e.Graphics.DrawRectangle(Pens.Black,
                     this.Width - const_width -padding , -padding,
                     const_width, const_height);

                //右下角
                e.Graphics.DrawRectangle(Pens.Black,
                     this.Width - const_width - padding , this.Height-const_height - padding,
                     const_width, const_height);

                //左下角
                e.Graphics.DrawRectangle(Pens.Black,
                     - padding, this.Height - const_height - padding,
                     const_width, const_height);

                //上边中间
                e.Graphics.DrawRectangle(Pens.Black,
                      (this.Width - const_width)/2-padding, -padding,
                      const_width, const_height);

                //下边中间
                e.Graphics.DrawRectangle(Pens.Black,
                      (this.Width - const_width) / 2 - padding, this.Height-const_height,
                      const_width, const_height);


                //左边中间
                e.Graphics.DrawRectangle(Pens.Black,
                        -padding, (this.Height - const_height)/2,
                        const_width, const_height);


                //右边中间
                e.Graphics.DrawRectangle(Pens.Black,
                     this.Width - const_width - padding, (this.Height - const_height)/2,
                     const_width, const_height);
            }
        }

        
    }
}
