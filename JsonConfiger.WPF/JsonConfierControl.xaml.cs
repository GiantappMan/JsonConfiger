using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JsonConfiger.WPF
{
    /// <summary>
    /// Interaction logic for JsonConfierControl.xaml
    /// </summary>
    public partial class JsonConfierControl : UserControl
    {
        public JsonConfierControl()
        {
            InitializeComponent();
        }

        private void tree_Loaded(object sender, RoutedEventArgs e)
        {
            var firstNode = tree.ItemContainerGenerator.ContainerFromIndex(0) as TreeViewItem;
            if (firstNode == null)
                return;

            firstNode.IsSelected = true;
            firstNode.IsExpanded = true;
        }
    }
}
