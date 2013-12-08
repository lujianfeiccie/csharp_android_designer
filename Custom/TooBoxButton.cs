using System.Windows.Forms;
using System.Drawing;
using csharp_android_designer_tool.Classes;
using System;

namespace csharp_android_designer_tool.Custom
{
    public class TooBoxButton : BaseButton
    {
        public delegate void onDragTipShowDelegate(int x, int y,bool visible,bool isInView,bool isUp);
        public onDragTipShowDelegate m_onDragTipShowDelegate=null;
        private readonly int const_width = 100;
        private readonly int const_height = 50;
        private readonly int const_padding = 5;
        private Color origin_bg_color;
        private Color origin_font_color;
        private bool isDown = false;
        private int panelViewLeft = 0;

        public int PanelViewLeft
        {
            get { return panelViewLeft; }
            set { panelViewLeft = value; }
        }
        public TooBoxButton():base()
        {           
            this.Width = const_width;
            this.Height = const_height;
            this.viewType = ViewType.Container;
            origin_bg_color = this.BackColor;
            origin_font_color = this.ForeColor;
            this.MouseDown += new MouseEventHandler(LayoutBtn_MouseDown);
            this.MouseUp += new MouseEventHandler(LayoutBtn_MouseUp);
            this.MouseMove += new MouseEventHandler(LayoutBtn_MouseMove);
            
        }

        void LayoutBtn_MouseMove(object sender, MouseEventArgs e)
        {
            //throw new System.NotImplementedException();
            if (isDown)
            {
                if (e.X > this.Width + panelViewLeft)//在右边编辑区域内
                {
                    int x = e.X - this.Width - panelViewLeft;
                    int y = e.Y + this.Top;
                    Console.WriteLine("move in ({0},{1}) ({2},{3})", e.X, e.Y,
                        x,y);
                    if (m_onDragTipShowDelegate != null)
                    {
                        m_onDragTipShowDelegate(x, y,true,true,false);
                    }
                }
                else {
                    Console.WriteLine("move out ({0},{1})", e.X, e.Y);
                }
            }
        }

        void LayoutBtn_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackColor = origin_bg_color;
            this.ForeColor = origin_font_color;
            this.isDown = false;
            if (e.X > this.Width + panelViewLeft)//在右边编辑区域内
            {
                int x = e.X - this.Width - panelViewLeft;
                int y = e.Y + this.Top;
                Console.WriteLine("up in ({0},{1}) ({2},{3})", e.X, e.Y,
                    x, y);
                if (m_onDragTipShowDelegate != null)
                {
                    m_onDragTipShowDelegate(x, y, false, true,true);
                }
            }
            else
            {
                Console.WriteLine("up out ({0},{1})", e.X, e.Y);
                if (m_onDragTipShowDelegate != null)
                {
                    m_onDragTipShowDelegate(0, 0, false,false,true);
                }
            }
        }

        void LayoutBtn_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.isDown = true;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.DrawRectangle(Pens.Black, const_padding, const_padding,
                const_width - const_padding*2, const_height-const_padding*2);//花一条线
        }
    }
}
