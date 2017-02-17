# Edi.UWP.Helpers
Helpers and Utils for Windows 10 UWP Projects. 
This document is not always keep updated with the library. 
Please check sample app also (also not always updated)

## Install

Install by NuGet:

```
PM> Install-Package Edi.UWP.Helpers
```

## Sample App

[Download from Windows Store](https://www.microsoft.com/en-US/store/apps/ediuwphelpers-sample-app/9wzdncrdxf3z)

---
## Features

### Chinese Character Encoding

```
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
```

### Windows Phone System Status Bar

##### Set Background and Foreground Color

```
Edi.UWP.Helpers.Mobile.SetWindowsMobileStatusBarColor(Color.FromArgb(255, 0, 114, 188), Colors.White);
```

#### Hide Status Bar

Hide System Status Bar on Phone, make App full screen

```
Edi.UWP.Helpers.HideWindowsMobileStatusBar();
```

##### Show Text and Progress on Status Bar

```
Edi.UWP.Helpers.ShowSystemTrayAsync(Color backgroundColor, Color foregroundColor, double opacity = 1, string text = "", bool isIndeterminate = false, bool showProgress = false);
```

### UI Helpers

##### Set App Window Launch Size

```
Edi.UWP.Helpers.UI.SetWindowLaunchSize(720, 360);
```

##### Set Color to App Title Bar

```
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
```

### Value Converters

Recommend to add the coverters to App.xaml in order to use them across all Xaml pages in your application

```
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
```

##### Usage

e.g. StringFormatConverters
```
&lt;TextBlock Text=&quot;{Binding Date,Converter={StaticResource ResourceKey=StringFormat}, ConverterParameter=&#39;Last Update {0}&#39;}&quot; /&gt;
```

Other Converters:

- BitmapImageConverter
- BooleanToVisibilityConverter
- ColorHexStringToBrushConverter
- ColorHexStringToColorConverter
- ColorToCMYKStringConverter
- ColorToHexStringConverter
- ColorToRgbStringConverter
- ColorToSolidColorBrushValueConverter
- DateTimeToOffsetConverter

### Windows 10 Tasks

##### Redirect the user to Windows Store and open Review window for current App

```
private async void BtnReview_OnClick(object sender, RoutedEventArgs e)
{
    await Edi.UWP.Helpers.Tasks.OpenStoreReviewAsync();
}
```

##### Open Email Composing

### Selector Wrapper

// TODO

Edi.UWP.Helpers.WrapperBase&lt;T&gt;

Edi.UWP.Helpers.SelectorWrapper&lt;T&gt; : WrapperBase&lt;T&gt;, INotifyPropertyChanged

### Other Utility Functions

##### Copy string to ClipBoard

```
Edi.UWP.Helpers.CopyToClipBoard("Hello");
```

##### Check if device is connected to the Internet

```
bool isConnected = Edi.UWP.Helpers.Utils.HasInternetConnection();
if (!isConnected)
{
    var dig = new MessageDialog("Please Check Internet Connection", "Are you TM kidding me?");
    await dig.ShowAsync();
    return;
}
```

##### Save InkCanvas strokes to .ink File

##### Load strokes from .ink file to InkCanvas

##### Convert ImageObject to Byte Array

##### Get Current App Version

```
public string Version => Edi.UWP.Helpers.Utils.GetAppVersion();
```

##### Get Current App Logo Image Uri

```
public Uri Logo => Edi.UWP.Helpers.Utils.GetAppLogoUri();
...
&lt;Image Source=&quot;{Binding Logo}&quot; Stretch=&quot;None&quot; /&gt;
```

##### Get Current App Display Name

```
public string DisplayName => Edi.UWP.Helpers.Utils.GetAppDisplayName();
```

##### Get Current App Publisher Name

```
public string Publisher => Edi.UWP.Helpers.Utils.GetAppPublisher();
```

### Extension Methods

// TODO

## License

The MIT License (MIT)

Copyright (c) 2016 edi.wang

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.