using JsonConfiger.Models;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace JsonConfiger.UWP
{
    public sealed partial class JsonConfierControl : UserControl
    {
        NameConveter _nameConveter = new NameConveter();
        Dictionary<TreeViewNode, CNode> _data = new Dictionary<TreeViewNode, CNode>();
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
            result.Content = _nameConveter.Convert(item, null, null, null);
            _data[result] = item;
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

        private void tree_ItemInvoked(TreeView sender, TreeViewItemInvokedEventArgs args)
        {
            var node = args.InvokedItem as TreeViewNode;
            itemsControl.ItemsSource = _data[node].Properties;
        }
    }
}
