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
    public partial class FormXmlOutput : Form
    {
        public void setText(string msg)
        {
            richTextBox1.Text = msg;
        }
        public FormXmlOutput()
        {
            InitializeComponent();
        }

        private void FormXmlOutput_Load(object sender, EventArgs e)
        {
            this.TopLevel = true;
        }
    }
}
