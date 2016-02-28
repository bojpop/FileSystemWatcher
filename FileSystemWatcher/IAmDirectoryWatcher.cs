namespace FileSystemWatcher
{
    public interface IAmDirectoryWatcher
    {
        void NewFileCreatedAt(string path);
    }
}