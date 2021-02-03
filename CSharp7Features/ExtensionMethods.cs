using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp7Features
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Illustrate the use of a discard variable
        /// </summary>
        /// <param name="value">The string to check</param>
        /// <returns>True is a valid Integer, else False</returns>
        public static bool ToInt(this string value)
        {
            return int.TryParse(value, out var _);
        }
    }
}
