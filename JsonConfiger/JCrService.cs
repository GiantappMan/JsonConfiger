using JsonConfiger.Models;

#if WINDOWS_UWP
using Windows.UI.Xaml.Controls;
using JsonConfiger.UWP;

#else
using System.Windows.Controls;
using JsonConfiger.WPF;
#endif
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace JsonConfiger
{
    public class JCrService
    {
        private (ObservableCollection<CNode> Nodes, ObservableCollection<CProperty> Properties) ResolveJson(JObject data, JObject descObj)
        {
            var childNodes = new ObservableCollection<CNode>();
            var properties = new ObservableCollection<CProperty>();
            dynamic descInfo = null;
            if (data != null)
                foreach (var x in data)
                {
                    if (descObj != null)
                        descInfo = descObj[x.Key];
                    if (x.Value is JValue)
                    {
                        var value = x.Value as JValue;
                        CProperty property = ConverterToNodeProperty(value);
                        if (property == null)
                            continue;
                        if (descInfo != null)
                        {
                            bool ok = Enum.TryParse(descInfo.type.ToString(), true, out CPropertyType cType);
                            if (ok)
                                property.CType = cType;

                            FillObj(property, descInfo);

                            if (descInfo.cbItems != null)
                            {
                                var tempList = new List<CProperty>();
                                foreach (var item in descInfo.cbItems)
                                {
                                    var tmp = new CProperty();
                                    FillObj(tmp, item);
                                    tmp.Value = item.value.ToString();
                                    tempList.Add(tmp);
                                }
                                property.ItemsSource = tempList;
                                property.Selected = tempList.FirstOrDefault
                                    (m => m.Value != null && property.Value != null
                                    && m.Value.ToString() == property.Value.ToString());
                            }
                        }

                        property.Name = x.Key;

                        if (property != null)
                            properties.Add(property);
                    }
                    else
                    {
                        var node = new CNode();
                        if (descInfo != null)
                        {
                            FillObj(node, descInfo);
                        }
                        node.Name = x.Key;

                        var (Nodes, Properties) = ResolveJson(x.Value as JObject, descInfo as JObject);
                        node.Children = Nodes;
                        node.Properties = Properties;
                        childNodes.Add(node);
                    }
                }

            return (childNodes, properties);
        }

        private void FillObj(CBaseObj property, dynamic descInfo)
        {
            property.Lan = descInfo.lan;
            property.LanKey = descInfo.lanKey;
            property.Desc = descInfo.desc;
            property.DescLanKey = descInfo.descLanKey;
            property.UID = descInfo.uid;
        }

        private CProperty ConverterToNodeProperty(JValue value)
        {
            if (value == null)
                return null;

            CProperty result = new CProperty
            {
                Value = value.Value
            };
            bool ok = Enum.TryParse(value.Type.ToString(), out CPropertyType Type);
            if (ok)
                result.CType = Type;
            return result;
        }

        public JsonConfierViewModel GetVM(object config, object descConfig)
        {
            if (!(config is JObject json))
                return null;

            var vm = new JsonConfierViewModel
            {
                Nodes = ResolveJson(config as JObject, descConfig as JObject).Nodes
            };
            vm.Nodes[0].Selected = true;
            return vm;
        }

        public UserControl GetView(object config, object desc)
        {
            var control = new JsonConfierControl
            {
                DataContext = GetVM(config, desc)
            };
            return control;
        }

        public object GetData(ObservableCollection<CNode> nodes)
        {
            var result = new ExpandoObject() as IDictionary<string, Object>;
            foreach (var nodeItem in nodes)
            {
                var tempNodeObj = GetDataFromNode(nodeItem);

                foreach (var subNode in nodeItem.Children)
                {
                    var subNodeObj = GetDataFromNode(subNode);
                    tempNodeObj.Add(subNode.Name, subNodeObj);
                }
                result.Add(nodeItem.Name, tempNodeObj);
            }
            return result;
        }

        private IDictionary<string, Object> GetDataFromNode(CNode nodeItem)
        {
            var tempNodeObj = new ExpandoObject() as IDictionary<string, Object>;
            foreach (var propertyItem in nodeItem.Properties)
            {
                tempNodeObj.Add(propertyItem.Name, propertyItem.Value);
            }
            return tempNodeObj;
        }
    }
}
