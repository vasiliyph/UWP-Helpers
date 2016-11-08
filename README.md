# Edi.UWP.Helpers
Helpers and Utils for Windows 10 UWP Projects. This document is not always keep updated with the library. Please check sample app also (also not always updated, what a big Ken it is!)

NuGet URL: [https://www.nuget.org/packages/Edi.UWP.Helpers/](https://www.nuget.org/packages/Edi.UWP.Helpers/)

Sample App: https://www.microsoft.com/zh-cn/store/apps/ediuwphelpers-sample-app/9wzdncrdxf3z

Author's Blog: [http://edi.wang](http://edi.wang)

## Install

To install Edi.UWP.Helpers, run the following command in the Package Manager Console

<pre>
PM> Install-Package Edi.UWP.Helpers
</pre>

## Features

### 1. Chinese Character Encoding
===
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

### 2. Windows 10 Mobile System Status Bar
===
#### Set Background and Foreground Color
<pre>
Edi.UWP.Helpers.Mobile.SetWindowsMobileStatusBarColor(Color.FromArgb(255, 0, 114, 188), Colors.White);
</pre>

#### Hide Status Bar
<pre>
Edi.UWP.Helpers.HideWindowsMobileStatusBar();
</pre>

#### Show Text and Progress on Status Bar
<pre>
Edi.UWP.Helpers.ShowSystemTrayAsync(Color backgroundColor, Color foregroundColor, double opacity = 1, string text = "", bool isIndeterminate = false, bool showProgress = false);
</pre>

### 3. UI Helpers
===
#### Set App Window Launch Size

<pre>
Edi.UWP.Helpers.UI.SetWindowLaunchSize(720, 360);
</pre>

#### Set Color to App Title Bar

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

### 4. Value Converters
===

Add the coverters to App.xaml in order to use them across all Xaml pages in your application

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

#### BitmapImageConverter
<pre>

</pre>

#### BooleanToVisibilityConverter
<pre>

</pre>

#### ColorHexStringToBrushConverter
<pre>

</pre>

#### ColorHexStringToColorConverter
<pre>

</pre>

#### ColorToCMYKStringConverter
<pre>

</pre>

#### ColorToHexStringConverter
<pre>

</pre>

#### ColorToRgbStringConverter
<pre>

</pre>

#### ColorToSolidColorBrushValueConverter
<pre>

</pre>

#### DateTimeToOffsetConverter
<pre>
&lt;DatePicker x:Uid=&quot;DpEndDate&quot; Date=&quot;{Binding EndDate, Mode=TwoWay, Converter={StaticResource DateTimeToOffsetConverter}}&quot; /&gt;
</pre>

#### StringFormatConverters
<pre>
&lt;TextBlock Text=&quot;{Binding Date,Converter={StaticResource ResourceKey=StringFormat}, ConverterParameter=&#39;Last Update {0}&#39;}&quot; /&gt;
</pre>

### Windows 10 Tasks
===
#### Redirect the user to Windows Store and open Review window for current App

<pre>
private async void BtnReview_OnClick(object sender, RoutedEventArgs e)
{
    await Edi.UWP.Helpers.Tasks.OpenStoreReviewAsync();
}
</pre>

#### Open Email Composing
<pre>

</pre>

### Selector Wrapper
===

<pre>

</pre>

Edi.UWP.Helpers.WrapperBase&lt;T&gt;

Edi.UWP.Helpers.SelectorWrapper&lt;T&gt; : WrapperBase&lt;T&gt;, INotifyPropertyChanged

### Other Utility Functions
===
#### Copy string to ClipBoard
<pre>
Edi.UWP.Helpers.CopyToClipBoard("Hello");
</pre>

#### Check if device is connected to the Internet
<pre>
bool isConnected = Edi.UWP.Helpers.Utils.HasInternetConnection();
if (!isConnected)
{
    var dig = new MessageDialog("Please Check Internet Connection", "Are you TM kidding me?");
    await dig.ShowAsync();
    return;
}
</pre>

#### Save InkCanvas strokes to .ink File
<pre>
public InkCanvas InkCanvas { get; set; }

public InkOperator(InkCanvas ink)
{
    InkCanvas = ink;
}

public async Task&lt;bool&gt; SaveToInkFile(PickerLocationId location)
{
    var response = await Edi.UWP.Helpers.Utils.SaveToInkFile(InkCanvas, location);
    return response.IsSuccess;
}
</pre>

#### Load strokes from .ink file to InkCanvas
<pre>
public async Task LoadInkFile(PickerLocationId location)
{
    await Edi.UWP.Helpers.Utils.LoadInkFile(InkCanvas, location);
}
</pre>

#### Convert ImageObject to Byte Array

// TODO

#### Get Current App Version
<pre>
public string Version => Edi.UWP.Helpers.Utils.GetAppVersion();
</pre>

#### Get Current App Logo Image Uri

<pre>
public Uri Logo => Edi.UWP.Helpers.Utils.GetAppLogoUri();
...
&lt;Image Source=&quot;{Binding Logo}&quot; Stretch=&quot;None&quot; /&gt;
</pre>

#### Get Current App Display Name
<pre>
public string DisplayName => Edi.UWP.Helpers.Utils.GetAppDisplayName();
</pre>

#### Get Current App Publisher Name
<pre>
public string Publisher => Edi.UWP.Helpers.Utils.GetAppPublisher();
</pre>

### Extension Methods
===

// TODO

### Tricks
===
Set Title Bar to System Accent Theme color:

<pre>
var accentColor = Edi.UWP.Helpers.UI.GetAccentColor();
var btnHoverColor = Color.FromArgb(128, 
    (byte)(accentColor.R + 30),
    (byte)(accentColor.G + 30),
    (byte)(accentColor.B + 30));

Edi.UWP.Helpers.UI.ApplyColorToTitleBar(
accentColor,
Colors.White,
Colors.LightGray,
Colors.Gray);

Edi.UWP.Helpers.UI.ApplyColorToTitleButton(
    accentColor, Colors.White,
    btnHoverColor, Colors.White,
    accentColor, Colors.White,
    Colors.LightGray, Colors.Gray);
</pre>

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
