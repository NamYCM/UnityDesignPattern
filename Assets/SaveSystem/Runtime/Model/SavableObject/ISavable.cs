namespace SaveSystem
{
    public interface ISavable
    {
        string GetSaveData();
        void Load(string data);
    }
}