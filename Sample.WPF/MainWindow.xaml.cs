using JsonConfiger;
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
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            JCrService service = new JCrService();
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "test.json");
            var data = await JsonHelper.JsonDeserializeFromFileAsync<object>(path);
            UserControl control = service.GetControl(data);

            grid.Children.Insert(0, control);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid.Children.RemoveAt(0);
        }
    }
}
