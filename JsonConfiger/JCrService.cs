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
        private ObservableCollection<NodeObj> ResolveJson(JObject data)
        {
            var result = new ObservableCollection<NodeObj>();

            if (data != null)
                foreach (var x in data)
                {
                    var node = new NodeObj();
                    node.Name = x.Key;

                    if (x.Value is JValue)
                    {
                        var value = x.Value as JValue;
                        switch (value.Type)
                        {
                            case JTokenType.String:
                                break;
                        }
                    }
                    else
                        node.Children = ResolveJson(x.Value as JObject);

                    result.Add(node);
                }

            return result;
        }

        public UserControl GetControl(object data)
        {
            var json = data as JObject;
            if (json == null)
                return null;

            var vm = new JsonConfierViewModel();
            vm.Nodes = ResolveJson(data as JObject);
            var control = new JsonConfierControl();
            control.DataContext = vm;
            return control;
        }
    }
}
