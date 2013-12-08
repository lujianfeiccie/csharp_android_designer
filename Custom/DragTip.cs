using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace csharp_android_designer_tool.Custom
{
    public class DragTip : BaseButton
    {
        private readonly int const_width = 30;
        private readonly int const_height = 30;
        private readonly int const_padding = 5;
        public DragTip():base()
        {
            this.Width = const_width;
            this.Height = const_height;
            this.viewType = ViewType.Other;
            this.BackColor = Color.White;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            //pevent.Graphics.DrawRectangle(Pens.Black, const_padding, const_padding,
            //    const_width - const_padding * 2, const_height - const_padding * 2);//画方框
           
            //画+字线
            pevent.Graphics.DrawLine(Pens.Black, const_width / 2, const_padding, //|线
                const_width / 2, const_height - const_padding);

            pevent.Graphics.DrawLine(Pens.Black, const_padding, const_height/2,//- 线
                const_width - const_padding, const_height / 2);
        }
    }
}
