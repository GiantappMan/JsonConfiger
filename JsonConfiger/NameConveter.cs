using JsonConfiger.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace JsonConfiger
{
    public class NameConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CProperty)
            {
                var cp = value as CProperty;
                if (!string.IsNullOrEmpty(cp.Lan))
                    return cp.Lan;

                return cp.Name;
            }

            if (value is CNode)
            {
                var cn = value as CNode;
                if (!string.IsNullOrEmpty(cn.Lan))
                    return cn.Lan;

                return cn.Name;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
