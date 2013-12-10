using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using csharp_android_designer_tool.Classes;
using System.Collections;

namespace csharp_android_designer_tool
{
    public partial class FormProperties : Form
    {
        static FormProperties mFormProperties = null;
       // Hashtable ht_properties = new Hashtable();
        SortedList ht_properties = new SortedList();  
        private FormProperties()
        {
            InitializeComponent();
        }

        public static FormProperties getInstance()
        {
            if (mFormProperties == null || mFormProperties.IsDisposed)
            {
                mFormProperties = new FormProperties();
            }
            return mFormProperties;
        }

        private void FormProperties_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            //this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            initProperties();
          //  initListView(listView1);
        }

        private void initProperties()
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

        private void initListView(ListView listview)
        {
         /*   listview.Columns.Add("键", 200);
            listview.Scrollable = true;
            listview.GridLines = true; //显示表格线
            listview.View = View.Details;//显示表格细节

            listview.Columns.Add("值", 100);
            listview.Scrollable = true;
            listview.GridLines = true; //显示表格线
            listview.View = View.Details;//显示表格细节

            this.Width = 350;

          
            string key = "";
            key = androidView.layout_width;
            listview.Items.Add(key, key, ht_properties[key].ToString());
            
            key = androidView.layout_height;
            listview.Items.Add(key, key, ht_properties[key].ToString());

            key = androidView.layout_margin;
            listview.Items.Add(key, key, ht_properties[key].ToString());

            key = androidView.layout_marginLeft;
            listview.Items.Add(key, key, ht_properties[key].ToString());

            key = androidView.layout_marginRight;
            listview.Items.Add(key, key, ht_properties[key].ToString());

            key = androidView.layout_marginTop;
            listview.Items.Add(key, key, ht_properties[key].ToString());

            key = androidView.layout_marginBottom;
            listview.Items.Add(key, key, ht_properties[key].ToString());
            */

        }

    }
}
