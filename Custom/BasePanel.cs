using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using csharp_android_designer_tool.Properties;
using csharp_android_designer_tool.Classes;

namespace csharp_android_designer_tool.Custom
{
    public enum DownOnType
    {
        LeftTop,
        RightTop,
        LeftBottom,
        RightBottom,
        TopMid,
        LeftMid,
        BottomMid,
        RightMid,
        Normal
    }
    public class BasePanel:Panel
    {
        MyApplication mApp = MyApplication.getInstance();
        


        private DragTip mDragTip = new DragTip();
        bool isDown = false;
        bool isRoot = false;
        Point point_down = new Point();
        Label lbl_status_bar = new Label();
        //按钮类型
        public ViewClass mViewClass = ViewClass.Other;
        //拉伸拖动指示
        int const_width = 10;
        int const_height = 10;
        int padding = 1;

        DownOnType mDownOnType = DownOnType.Normal; 
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
            //Console.WriteLine("up width={0},height={1},left={2},top={3},({4},{5})",
             //       this.Width, this.Height, this.Left, this.Top, e.X, e.Y);
            isDown = false;
            mDownOnType = DownOnType.Normal;
            if (m_onNodeSelectedDelegate != null)
            {
                m_onNodeSelectedDelegate(this);
            }
           // mDragTip.Visible = false;
        }

        protected virtual void BasePanel_MouseDown(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("down width={0},height={1},left={2},top={3},({4},{5})",
             //       this.Width, this.Height, this.Left, this.Top, e.X, e.Y);

            isDown = true;
            point_down.X = e.X;
            point_down.Y = e.Y;

            if (e.X >= -padding && e.X < const_width - padding   //拽左上角
                && e.Y >= -padding && e.Y < const_height - padding)
            {
                mDownOnType = DownOnType.LeftTop;
            }
            else if (e.X >= this.Width - const_width - padding && e.X <= this.Width + padding    //拽右上角
                  && e.Y >= -padding && e.Y <= const_height)
            {
                mDownOnType = DownOnType.RightTop;
            }
            else if (e.X >= -padding && e.X < const_width - padding   //拽左下角
                && e.Y >= this.Height-const_height && e.Y <= this.Height)
            {
                mDownOnType = DownOnType.LeftBottom;
            }
            else if (e.X >= this.Width - const_width - padding && e.X <= this.Width + padding    //拽右下角
                  && e.Y >= this.Height-const_height && e.Y <= this.Height)
            {
                mDownOnType = DownOnType.RightBottom;
            }
            else if (e.X >= (this.Width - const_width) / 2 && e.X <= (this.Width + const_width) / 2 //拽中上
               && e.Y >= -padding && e.Y <= const_height)  
            {
                mDownOnType = DownOnType.TopMid;
            }
            else if (e.X >= -padding && e.X < const_width - padding
                  && e.Y >= (this.Height - const_height)/2 && e.Y <= (this.Height + const_height)/2)  //拽中左
            {
                mDownOnType = DownOnType.LeftMid;
            }
            else if (e.X >= this.Width - const_width - padding && e.X <= this.Width + padding
             && e.Y >= (this.Height - const_height) / 2 && e.Y <= (this.Height + const_height) / 2)  //拽中右
            {
                mDownOnType = DownOnType.RightMid;
            }
            else if (e.X >= (this.Width - const_width) / 2 && e.X <= (this.Width + const_width) / 2
          && e.Y >= this.Height - const_height && e.Y <= this.Height )  //拽中下
            {
                mDownOnType = DownOnType.BottomMid;
            }
            else
            {
                mDownOnType = DownOnType.Normal;
            }
        }

        protected virtual void BasePanel_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (isDown && !isRoot)
            {

              //  Console.WriteLine("move width={0},height={1},left={2},top={3},({4},{5})",
              //      this.Width,this.Height,this.Left,this.Top,e.X,e.Y);
               
                //计算位移增量
                int tranx = e.X - point_down.X;
                int trany = e.Y - point_down.Y;
                int width_increment = -tranx;
                int height_increment = -trany;
                switch (mDownOnType)
                {
                    case DownOnType.LeftTop:
                        {
                            this.Left = this.Left + tranx;
                            this.Top = this.Top + trany;
                            this.Width = this.Width + width_increment;
                            this.Height = this.Height + height_increment;
                        }
                        break;
                    case DownOnType.RightTop:
                        {
                            this.Top = this.Top + trany;
                            this.Width = this.Width - width_increment;
                            this.Height = this.Height + height_increment;
                            point_down.X -=  width_increment;
                        }
                        break;
                    case DownOnType.LeftBottom:
                        {
                            this.Left = this.Left + tranx;
                            this.Width = this.Width + width_increment;
                            this.Height = this.Height - height_increment;
                            point_down.Y -= height_increment;
                        }
                        break;
                    case DownOnType.RightBottom:
                        {
                            this.Width = this.Width - width_increment;
                            this.Height = this.Height - height_increment;
                            point_down.X -= width_increment;
                            point_down.Y -= height_increment;
                        }
                        break;
                    case DownOnType.TopMid:
                        {
                            this.Top = this.Top + trany;
                            this.Height = this.Height + height_increment;
                        }
                        break;
                    case DownOnType.LeftMid:
                        {
                            this.Left = this.Left + tranx;
                            this.Width = this.Width + width_increment;
                        }
                        break;
                    case DownOnType.RightMid:
                        {
                            this.Width = this.Width - width_increment;
                            point_down.X -= width_increment;
                        }
                        break;
                    case DownOnType.BottomMid:
                        {
                            this.Height = this.Height - height_increment;
                            point_down.Y -= height_increment;
                        }
                        break;
                    case DownOnType.Normal:
                        {
                            this.Left = this.Left + tranx;
                            this.Top = this.Top + trany;
                        }
                        break;
                    default:
                        break;
                }
                Invalidate();
            }
        }
        //显示拖动提示
        public virtual void showDragTips(int x, int y, bool visible, bool isInEditView, bool isUp, ViewClass mViewClass)
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
                mBasePanel.mViewClass = mViewClass;
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
