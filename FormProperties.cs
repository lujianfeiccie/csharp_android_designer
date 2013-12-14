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
       // Hashtable properties.Properties = new Hashtable();
        AndroidProperties properties = new AndroidProperties();

        public AndroidProperties Properties
        {
            get { return properties; }
            set { properties = value;
            initListView();
            }
        }
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
           // initProperties();
           // initListView();

         
        }

        private void initProperties()
        {
            properties.Properties.Add(androidView.layout_width, "");
            properties.Properties.Add(androidView.layout_height, "");
            properties.Properties.Add(androidView.layout_margin, "");
            properties.Properties.Add(androidView.layout_marginLeft, "");
            properties.Properties.Add(androidView.layout_marginTop, "");
            properties.Properties.Add(androidView.layout_marginRight, "");
            properties.Properties.Add(androidView.layout_marginBottom, "");
            properties.Properties.Add(androidView.padding, "");
            properties.Properties.Add(androidView.paddingLeft, "");
            properties.Properties.Add(androidView.paddingTop, "");
            properties.Properties.Add(androidView.paddingRight, "");
            properties.Properties.Add(androidView.paddingBottom, "");
        }
        
        private void initListView()
        {

            DataTable dt = new DataTable();//建立个数据表

            dt.Columns.Add(new DataColumn("属性", typeof(string)));//在表中添加int类型的列

            dt.Columns.Add(new DataColumn("值", typeof(string)));//在表中添加string类型的Name列
             
            DataRow dr;//行

            this.Width = 350;

          
            string key = "";
            key = androidView.layout_width;
            dr = dt.NewRow();
            dr["属性"] = key;
            dr["值"] = properties.Properties[key].ToString();
            dt.Rows.Add(dr);//在表的对象的行里添加此行

           
            key = androidView.layout_height;
            dr = dt.NewRow();
            dr["属性"] = key;
            dr["值"] = properties.Properties[key].ToString();
            dt.Rows.Add(dr);//在表的对象的行里添加此行

            key = androidView.layout_margin;
            dr = dt.NewRow();
            dr["属性"] = key;
            dr["值"] = properties.Properties[key].ToString();
            dt.Rows.Add(dr);//在表的对象的行里添加此行

            key = androidView.layout_marginLeft;
            dr = dt.NewRow();
            dr["属性"] = key;
            dr["值"] = properties.Properties[key].ToString();
            dt.Rows.Add(dr);//在表的对象的行里添加此行

            key = androidView.layout_marginRight;
            dr = dt.NewRow();
            dr["属性"] = key;
            dr["值"] = properties.Properties[key].ToString();
            dt.Rows.Add(dr);//在表的对象的行里添加此行

            key = androidView.layout_marginTop;
            dr = dt.NewRow();
            dr["属性"] = key;
            dr["值"] = properties.Properties[key].ToString();
            dt.Rows.Add(dr);//在表的对象的行里添加此行

            key = androidView.layout_marginBottom;
            dr = dt.NewRow();
            dr["属性"] = key;
            dr["值"] = properties.Properties[key].ToString();
            dt.Rows.Add(dr);//在表的对象的行里添加此行


            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[0].ReadOnly = true;
        }
        
    }
}
