using JsonConfiger.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace JsonConfiger.UWP
{
    public sealed partial class JsonConfierControl : UserControl
    {
        NameConveter nameConveter = new NameConveter();
        public JsonConfierControl()
        {
            InitializeComponent();
            DataContextChanged += JsonConfierControl_DataContextChanged;
        }

        private void JsonConfierControl_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            DataContextChanged -= JsonConfierControl_DataContextChanged;
            var vm = DataContext as JsonConfierViewModel;
            if (vm == null)
                return;

            foreach (var item in vm.Nodes)
            {
                TreeViewNode node = GetNode(item);
                tree.RootNodes.Add(node);
            }
        }

        private TreeViewNode GetNode(CNode item)
        {
            TreeViewNode result = new TreeViewNode();
            result.IsExpanded = item.Selected;
            result.Content = nameConveter.Convert(item, null, null, null);
            if (item.Children != null)
            {
                foreach (var sub in item.Children)
                {
                    TreeViewNode subNode = GetNode(sub);
                    result.Children.Add(subNode);
                }
            }
            return result;
        }
    }
}
