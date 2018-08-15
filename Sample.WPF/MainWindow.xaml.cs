using JsonConfiger;
using JsonConfiger.Models;
using JsonConfiger.Utils;
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

namespace Sample.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JCrService service = new JCrService();
        UserControl control;
        string path = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "test.json");
        string descPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "test.desc.json");
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var data = await JsonHelper.JsonDeserializeFromFileAsync<object>(path);
            var dataDesc = await JsonHelper.JsonDeserializeFromFileAsync<object>(descPath);
            control = service.GetView(data, dataDesc);
            //control = service.GetView(data, null);

            grid.Children.Insert(0, control);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = control.DataContext as JsonConfierViewModel;
            var data = service.GetData(vm.Nodes);
            await JsonHelper.JsonSerializeAsync(data, path);
            //grid.Children.RemoveAt(0);
        }
    }
}
