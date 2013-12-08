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
    public partial class FormToolBar : Form
    {
        static FormToolBar mFormToolBar = null;
        public delegate void onResolutionReceiveDelegate(string text);

        public onResolutionReceiveDelegate m_onResolutionReceiveDelegate=null;


        private FormToolBar()
        {
            InitializeComponent();
        }

        public static FormToolBar getInstance(){
            if (mFormToolBar == null)
            {
                mFormToolBar = new FormToolBar();
            }
            return mFormToolBar;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (m_onResolutionReceiveDelegate != null)
            {
                m_onResolutionReceiveDelegate("wokao");
            }
        }

        private void FormToolBar_Load(object sender, EventArgs e)
        {
     
        }
    }
}
