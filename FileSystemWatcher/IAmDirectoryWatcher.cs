namespace FileSystemWatcher
{
    internal interface IAmDirectoryWatcher
    {
        void NewFileCreatedAt(string path);
    }
}