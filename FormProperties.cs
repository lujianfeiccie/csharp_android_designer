using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace csharp_android_designer_tool
{
    public partial class FormProperties : Form
    {
        static FormProperties mFormProperties = null;

        private FormProperties()
        {
            InitializeComponent();
        }

        public static FormProperties getInstance()
        {
            if (mFormProperties == null)
            {
                mFormProperties = new FormProperties();
            }
            return mFormProperties;
        }

        private void FormProperties_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
