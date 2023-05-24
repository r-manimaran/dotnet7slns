using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFeatures
{
    public static class ExtensionHelper
    {
        public static T Parse<T>(this string input, IFormatProvider format = null) where T: IParsable<T>
        {
            return T.Parse(input, format);
        }
    }
}
