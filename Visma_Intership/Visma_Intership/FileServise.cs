﻿using Newtonsoft.Json;

namespace Visma_Intership
{
    public class FileServise : IFileService
    {
        public T ReadFile<T>(string filename)
        {
            var backingFile = Path.GetFullPath(filename);
            if (!File.Exists(backingFile))
            {
                return default;
            }

            var text = File.ReadAllText(backingFile);
            var result = JsonConvert.DeserializeObject<T>(text, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            if (result == null)
            {
                return default;
            }

            return result;
        }

        public void SaveFile<T>(T items, string filename)
        {
            var backingFile = Path.GetFullPath(filename);

            using (StreamWriter file = File.CreateText(backingFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, items);
            }
        }

        public void DeleteFile(string filename)
           => File.Delete(Path.Combine(FileSystem.AppDataDirectory, filename));
    }
}
