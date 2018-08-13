using JsonConfiger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JsonConfiger.WPF
{
    class TemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var nodeObj = item as CNode;
            if (nodeObj == null)
                return null;

            return base.SelectTemplate(item, container);
        }
    }
}
