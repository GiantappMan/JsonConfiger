using JsonConfiger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JsonConfiger
{
    class TemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var cp = item as CProperty;
            if (cp == null)
                return null;

            string key = $"{cp.CType.ToString()}Editor";
            var template = ((FrameworkElement)container).FindResource(key) as DataTemplate;
            return template;
        }
    }
}
