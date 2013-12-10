using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace csharp_android_designer_tool.Classes
{
    public enum ViewClass
    {
        LinearLayout,
        RelativeLayout,
        Other
    }
    public enum Orientation_Phone
    { 
        Vertical,
        Horizontal
    }
    public enum LayoutProperty
    {
        match_parent,
        wrap_content
    }
    public class androidView
    {
        public static readonly string linearlayout = "LinearLayout";
        public static readonly string relativelayout = "RelativeLayout";

        //专为输出android:标签准备
        public static readonly string layout_width2 = "xml:layout_width";
        public static readonly string layout_height2 = "xml:layout_height";
        public static readonly string padding2 = "xml:padding";
        public static readonly string paddingLeft2 = "xml:paddingLeft";
        public static readonly string paddingTop2 = "xml:paddingTop";
        public static readonly string paddingRight2 = "xml:paddingRight";
        public static readonly string paddingBottom2 = "xml:paddingBottom";
        public static readonly string layout_margin2 = "xml:layout_margin";
        public static readonly string layout_marginLeft2 = "xml:layout_marginLeft";
        public static readonly string layout_marginTop2 = "xml:layout_marginTop";
        public static readonly string layout_marginRight2 = "xml:layout_marginRight";
        public static readonly string layout_marginBottom2 = "xml:layout_marginBottom";
        public static readonly string orientation2 = "xml:orientation";

        //安卓属性
        public static readonly string layout_width = "android:layout_width";
        public static readonly string layout_height = "android:layout_height";
        public static readonly string padding = "android:padding";
        public static readonly string paddingLeft = "android:paddingLeft";
        public static readonly string paddingTop = "android:paddingTop";
        public static readonly string paddingRight = "android:paddingRight";
        public static readonly string paddingBottom = "android:paddingBottom";
        public static readonly string layout_margin = "android:layout_margin";
        public static readonly string layout_marginLeft = "android:layout_marginLeft";
        public static readonly string layout_marginTop = "android:layout_marginTop";
        public static readonly string layout_marginRight = "android:layout_marginRight";
        public static readonly string layout_marginBottom = "android:layout_marginBottom";
        public static readonly string orientation = "android:orientation";
        
        protected bool isContainer = true;
        public androidView()
        {
            
        }
    }
   
}
