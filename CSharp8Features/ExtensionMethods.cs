using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharp8Features
{
    public static class ExtensionMethods
    {        
        public static bool IsValid(this Student student)
        {
            return student != null && !string.IsNullOrEmpty(student.FirstName);
        }

        public unsafe static PropertyInfo[] GetProps<T>(this T obj) where T : unmanaged
        {
            var t = obj.GetType();
            return t.GetProperties();
        }
    }
}
