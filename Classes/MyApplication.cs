using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csharp_android_designer_tool.Classes;

namespace csharp_android_designer_tool.Custom
{
    public class MyApplication
    {
        private static MyApplication instance;
        private PhoneSize _PhoneSize = new PhoneSize();
        private PhoneSize _EditViewSize = new PhoneSize();

        public PhoneSize EditViewSize
        {
            get { return _EditViewSize; }
            set { _EditViewSize = value; }
        } 
        public PhoneSize PhoneSize
        {
            get { return _PhoneSize; }
            set { _PhoneSize = value; }
        }

        private MyApplication() {

            _PhoneSize.width = 480;
            _PhoneSize.height = 800;
        }

        public static MyApplication getInstance() {
            if (instance == null) {
                instance = new MyApplication();
            }
            return instance;
        }
    }
}
