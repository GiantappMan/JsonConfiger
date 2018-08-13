using JsonConfiger.Models;
using JsonConfiger.WPF;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace JsonConfiger
{
    public class JCrService
    {
        private (ObservableCollection<CNode> Nodes, ObservableCollection<CProperty> Properties) ResolveJson(JObject data)
        {
            var childNodes = new ObservableCollection<CNode>();
            var properties = new ObservableCollection<CProperty>();

            if (data != null)
                foreach (var x in data)
                {
                    if (x.Value is JValue)
                    {
                        var value = x.Value as JValue;
                        CProperty property = ConverterToNodeProperty(value);
                        property.Name = x.Key;
                        if (property != null)
                            properties.Add(property);
                    }
                    else
                    {
                        var node = new CNode();
                        node.Name = x.Key;
                        node.Children = ResolveJson(x.Value as JObject).Nodes;
                        node.Properties = properties;
                        childNodes.Add(node);
                    }
                }

            return (childNodes, properties);
        }

        private CProperty ConverterToNodeProperty(JValue value)
        {
            if (value == null)
                return null;

            CProperty result = new CProperty();
            result.Value = value.Value;
            bool ok = Enum.TryParse<CPropertyType>(value.Type.ToString(), out CPropertyType Type);
            if (!ok)
                return null;

            result.CType = Type;
            return result;
        }

        public UserControl GetControl(object data)
        {
            var json = data as JObject;
            if (json == null)
                return null;

            var vm = new JsonConfierViewModel();
            vm.Nodes = ResolveJson(data as JObject).Nodes;
            var control = new JsonConfierControl();
            control.DataContext = vm;
            return control;
        }
    }
}
