using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Storage;

namespace Edi.UWP.Helpers
{
    public class JsonDataRepository<T> where T : class
    {
        public string JsonFileName { get; set; }

        public JsonDataRepository(string jsonfilename)
        {
            JsonFileName = jsonfilename;
        }

        public async Task SaveDataAsync(T data)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (Stream stream = await ApplicationData.Current.LocalFolder
                                         .OpenStreamForWriteAsync(JsonFileName, CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, data);
            }
        }

        public async Task<T> LoadDataAsync()
        {
            try
            {
                Stream ms = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JsonFileName);
                var serializer = new DataContractJsonSerializer(typeof(T));
                object obj = serializer.ReadObject(ms);
                var ids = obj as T;
                return ids;
            }
            catch (FileNotFoundException)
            {
                return default(T);
            }
        }
    }
}
