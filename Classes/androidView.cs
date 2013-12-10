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
        public static readonly string layout_width = "xml:layout_width";
        public static readonly string layout_height = "xml:layout_height";
        public static readonly string padding = "xml:padding";
        public static readonly string paddingLeft = "xml:paddingLeft";
        public static readonly string paddingTop = "xml:paddingTop";
        public static readonly string paddingRight = "xml:paddingRight";
        public static readonly string paddingBottom = "xml:paddingBottom";
        public static readonly string layout_margin = "xml:layout_margin";
        public static readonly string layout_marginLeft = "xml:layout_marginLeft";
        public static readonly string layout_marginTop = "xml:layout_marginTop";
        public static readonly string layout_marginRight = "xml:layout_marginRight";
        public static readonly string layout_marginBottom = "xml:layout_marginBottom";
        public static readonly string orientation = "xml:orientation";
       

        Hashtable ht_properties=new Hashtable();
        protected bool isContainer = true;
        public androidView()
        {
            ht_properties.Add(layout_width, "");
            ht_properties.Add(layout_height, "");
            ht_properties.Add(padding, "");
            ht_properties.Add(paddingLeft, "");
            ht_properties.Add(paddingTop, "");
            ht_properties.Add(paddingRight, "");
            ht_properties.Add(paddingBottom, "");
            ht_properties.Add(layout_margin, "");
            ht_properties.Add(layout_marginLeft, "");
            ht_properties.Add(layout_marginTop, "");
            ht_properties.Add(layout_marginRight, "");
            ht_properties.Add(layout_marginBottom, "");
        }
    }
   
}
