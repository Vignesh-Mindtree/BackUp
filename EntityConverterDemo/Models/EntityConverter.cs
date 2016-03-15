using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Models
{
    public static class EntityConverter
    {
        public static T ConvertTypeStoTypeT<T, S>(S input) where T : new() where S : new()
        {
            var output = new T();
            PropertyInfo[] propOfT = output.GetType().GetProperties();

            foreach(PropertyInfo prop in propOfT)
            {
               if(prop.CanWrite)
                {
                    PropertyInfo inputProps = input.GetType().GetProperty(prop.Name);
                    if(inputProps != null && prop.PropertyType == inputProps.PropertyType)
                    {
                        prop.SetValue(output, inputProps.GetValue(input,null), null);
                    }
                }
            }
            return output;
        }
    }
}
