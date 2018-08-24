using JsonConfiger.Models;
using MultiLanguageManager;
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
            if (value is CBaseObj)
            {
                var cp = value as CBaseObj;
                if (!string.IsNullOrEmpty(cp.Lan))
                    return cp.Lan;

                if (!string.IsNullOrEmpty(cp.LanKey))
                {
                    string lan = LanService.Get(cp.LanKey).Result;
                    return lan;
                }
                return cp.Name;
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
