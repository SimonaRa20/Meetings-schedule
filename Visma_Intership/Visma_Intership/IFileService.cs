namespace Visma_Intership
{
    public interface IFileService
    {
        T ReadFile<T>(string filename);
        void SaveFile<T>(T items, string filename);
        void DeleteFile(string filename);
    }
}
