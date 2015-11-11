# Edi.UWP.Helpers
Helpers and Utils for Windows 10 UWP Projects

NuGet URL: https://www.nuget.org/packages/Edi.UWP.Helpers/

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