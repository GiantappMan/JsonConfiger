# JsonConfiger
根据JSON生成WPF/UWP配置界面

## 目的

根据JSON动态生成配置界面，节省枯燥的配置界面编写环节。适用于对界面自定义要求不高，满足用户可以通过GUI修改配置的场景

## 用法
* **定义默认配置**
 ```
  //Configs/default_config.json 编译时拷贝到目录
{
  "general": {
    "startupWithWindows": true
  }
}

 ```
 * **控件引用**
 ```xaml
 /* wpf */
 <Window
 ...
 xmlns:wpf="clr-namespace:JsonConfiger.WPF;assembly=JsonConfiger.WPF">
     <wpf:JsonConfierControl  DataContext="{Binding JsonConfierViewModel}" />
</Window>
 ```
 
 * **ViewModel**
 ```csharp
 var config = await JsonHelper.JsonDeserializeFromFileAsync<dynamic>(todo.ConfigFilePath);
 string descPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Resources\\Configs\\setting.desc.json");
 var descConfig = await JsonHelper.JsonDeserializeFromFileAsync<dynamic>(descPath);
 JsonConfierViewModel = _jcrService.GetVM(config, descConfig);
 ```
## 注意事项：
* lanKey区分大小写，定义时K不要写成小写了
