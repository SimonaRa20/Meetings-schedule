using Newtonsoft.Json;

namespace Visma_Intership
{
    class InOutUtils
    {
        public static List<Meeting> ReadJsonFile(string fileName)
        {
            List<Meeting> list = new List<Meeting>();
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Meeting>>(json);
            }
            return list;
        }

        public T ReadFile<T>(string filename)
        {
            var backingFile = Path.Combine(FileSystem.AppDataDirectory, filename);
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

        public static void AddNewMeeting(List<Meeting> list, Meeting meeting, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            else
            {
                list.Add(meeting);
                using (StreamWriter file = File.CreateText(fileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, list);
                }
            }

        }
    }
}
