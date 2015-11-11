# Edi.UWP.Helpers
Helpers and Utils for Windows 10 UWP Projects

NuGet URL: [https://www.nuget.org/packages/Edi.UWP.Helpers/](https://www.nuget.org/packages/Edi.UWP.Helpers/)

Author's Blog: [http://edi.wang](http://edi.wang)

---
## Features

### Chinese Character Encoding

- big5.bin
- gb2312.bin
- DBCSEncoding.cs

#### Usage:

<pre>
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(ServiceEndpointUrl);
    var content = new FormUrlEncodedContent(new[] 
    {
        ...
    });
    var result = await client.PostAsync("", content);
    var resultContent = await result.Content.ReadAsByteArrayAsync();
    return DBCSEncoding.GetDBCSEncoding("gb2312").GetString(resultContent, 0,resultContent.Length - 1);
}
</pre>

### Windows Phone System Status Bar

internally reference: "Windows Mobile Extensions for the UWP"

namespace: Edi.UWP.Helpers.Mobile

// TODO

<pre>
Edi.UWP.Helpers.Mobile.SetWindowsMobileStatusBarColor(Color.FromArgb(255, 0, 114, 188), Colors.White);
</pre>

### UI Helpers

// TODO

<pre>
Edi.UWP.Helpers.UI.SetWindowLaunchSize(720, 360);
</pre>

<pre>
void ApplyColorToTitleBar()
{
    Edi.UWP.Helpers.UI.ApplyColorToTitleBar(
        Color.FromArgb(255, 0, 114, 188), 
        Colors.White, 
        Colors.LightGray, 
        Colors.Gray);

    Edi.UWP.Helpers.UI.ApplyColorToTitleButton(
        Color.FromArgb(255, 0, 114, 188), Colors.White, 
        Color.FromArgb(255, 51, 148, 208), Colors.White,
        Color.FromArgb(255, 0, 114, 188), Colors.White, 
        Colors.LightGray, Colors.Gray);
}
</pre>

### Value Converters

// TODO
##### BitmapImageConverter
##### BooleanToVisibilityConverter
##### ColorHexStringToBrushConverter
##### ColorHexStringToColorConverter
##### ColorToCMYKStringConverter
##### ColorToHexStringConverter
##### ColorToRgbStringConverter
##### ColorToSolidColorBrushValueConverter
##### DateTimeToOffsetConverter
##### StringFormatConverters

<pre>
&lt;Application
    ...
    xmlns:converters=&quot;using:Edi.UWP.Helpers.Converters&quot;&gt;
    &lt;Application.Resources&gt;
        ...
        &lt;converters:DateTimeToOffsetConverter x:Key=&quot;DateTimeToOffsetConverter&quot; /&gt;
        &lt;converters:StringFormatConverter x:Key=&quot;StringFormatConverter&quot; /&gt;
        &lt;converters:BooleanToVisibilityConverter x:Key=&quot;BooleanToVisibilityConverter&quot; /&gt;
        ...
    &lt;/Application.Resources&gt;
&lt;/Application&gt;
</pre>

### Windows 10 Tasks

// TODO

<pre>
private async void BtnReview_OnClick(object sender, RoutedEventArgs e)
{
    await Edi.UWP.Helpers.Tasks.OpenStoreReviewAsync();
}
</pre>

### Selector Wrapper

// TODO

### Other Utility Functions

// TODO

### Extension Methods

// TODO