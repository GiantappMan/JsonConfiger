using DZY.DotNetUtil.Helpers;
using JsonConfiger;
using JsonConfiger.Models;
using MultiLanguageManager;
using Newtonsoft.Json.Linq;
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
        string defaultPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "test.default.json");
        string descPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "test.desc.json");
        public MainWindow()
        {
            InitializeComponent();

            string path = System.IO.Path.Combine(Environment.CurrentDirectory, "Data\\Languages");
            LanService.Init(new JsonDB(path), true);

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //path = @"C:\Users\zy\AppData\Roaming\EyeNurse\Configs\setting.json";
            //descPath = @"E:\mscoder\github\EyeNurse\EyeNurse.Client\bin\Debug\Configs\setting.desc.json";
            var data = await JsonHelper.JsonDeserializeFromFileAsync<object>(path);
            var defaultData = await JsonHelper.JsonDeserializeFromFileAsync<object>(defaultPath);
            var dataDesc = await JsonHelper.JsonDeserializeFromFileAsync<object>(descPath);

            List<dynamic> extraDescObjs = new List<dynamic>();

            extraDescObjs.Add(new
            {
                lan = string.Format($"禁用"),
                value = -1
            });
            for (int i = 0; i < System.Windows.Forms.Screen.AllScreens.Length; i++)
            {
                extraDescObjs.Add(new
                {
                    lan = string.Format($"屏幕{i}"),
                    value = i
                });
            }

            service.InjectDescObjs("$screen", extraDescObjs);

            data = JCrService.CheckDefault(data as JObject, defaultData as JObject);

            control = service.GetView(data as JObject, dataDesc as JObject);
            control.BorderBrush = new SolidColorBrush(Colors.Red);
            //control = service.GetView(data, null);

            grid.Children.Insert(0, control);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = control.DataContext as JsonConfierViewModel;
            var data = service.GetData(vm.Nodes);
            var test = await JsonHelper.JsonSerializeAsync(data, path);
            //grid.Children.RemoveAt(0);
        }
    }
}
