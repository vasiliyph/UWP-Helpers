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

### Windows 10 Tasks

// TODO

### Selector Wrapper

// TODO

### Other Utility Functions

// TODO

### Extension Methods

// TODO