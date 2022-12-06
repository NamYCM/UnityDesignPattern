namespace SaveSystem
{
    public interface IResetable
    {
        bool IsDeleteFile { get; }
        void Reset();
    }
}