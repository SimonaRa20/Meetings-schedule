using Newtonsoft.Json;

namespace Visma_Intership
{
    public class FileService : IFileService
    {
        public T ReadFile<T>(string filename)
        {
            if (!File.Exists(filename))
            {
                return default;
            }

            var text = File.ReadAllText(filename);
            var result = JsonConvert.DeserializeObject<T>(text, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            if (result == null)
            {
                return default;
            }

            return result;
        }

        public void SaveFile<T>(T items, string filename)
        {
            using (StreamWriter file = File.CreateText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, items);
            }
        }

        public void DeleteFile(string filename)
           => File.Delete(filename);
    }
}
