using JsonConfiger.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

#if WINDOWS_UWP
using Windows.UI.Xaml.Data;
#else
using System.Windows.Data;
#endif
namespace JsonConfiger
{
    public class NameConveter : IValueConverter
    {
#if WINDOWS_UWP
        public object Convert(object value, Type targetType, object parameter, string language)
#else
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
#endif
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
#if WINDOWS_UWP
        public object ConvertBack(object value, Type targetType, object parameter, string language)
#else
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
#endif
        {
            throw new NotImplementedException();
        }
    }
}
