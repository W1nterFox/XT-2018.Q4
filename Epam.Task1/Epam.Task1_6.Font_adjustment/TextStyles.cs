using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_6.Font_adjustment
{
    [Flags]
    enum TextStyles : byte
    {
        None = 0,
        Bold = 1,
        Italic = 2,
        Underline = 4
    }
}
