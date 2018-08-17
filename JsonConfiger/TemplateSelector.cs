using JsonConfiger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#else
using System.Windows.Controls;
#endif
namespace JsonConfiger
{
    class TemplateSelector : DataTemplateSelector
    {
#if WINDOWS_UWP

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
#else 
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
#endif
        {
            var cp = item as CProperty;
            if (cp == null)
                return null;

            string key = $"{cp.CType.ToString()}Editor";
#if WINDOWS_UWP
            var template = ((FrameworkElement)container).FindName(key) as DataTemplate;

#else
            var template = ((FrameworkElement)container).FindResource(key) as DataTemplate;
#endif
            return template;
        }
    }
}
