using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csharp_android_designer_tool.Classes;
using System.Windows.Forms;

namespace csharp_android_designer_tool.Custom
{
    public enum ViewType
    {
        Container,
        NotContainer,
        Other
    }
    public class BaseButton:Button
    {
        public ViewType viewType= ViewType.NotContainer;
    }
}
