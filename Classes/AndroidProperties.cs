using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace csharp_android_designer_tool.Classes
{
    public class AndroidProperties
    {
        //安卓属性
        private Hashtable ht_properties = new Hashtable();

        public Hashtable Properties
        {
            get { return ht_properties; }
            set { ht_properties = value; }
        }

        public AndroidProperties()
        {
            ht_properties.Add(androidView.layout_width, "");
            ht_properties.Add(androidView.layout_height, "");
            ht_properties.Add(androidView.layout_margin, "");
            ht_properties.Add(androidView.layout_marginLeft, "");
            ht_properties.Add(androidView.layout_marginTop, "");
            ht_properties.Add(androidView.layout_marginRight, "");
            ht_properties.Add(androidView.layout_marginBottom, "");
            ht_properties.Add(androidView.padding, "");
            ht_properties.Add(androidView.paddingLeft, "");
            ht_properties.Add(androidView.paddingTop, "");
            ht_properties.Add(androidView.paddingRight, "");
            ht_properties.Add(androidView.paddingBottom, "");
        }
    }
}
