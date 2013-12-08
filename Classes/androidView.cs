using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace csharp_android_designer_tool.Classes
{
    public class androidView
    {
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
