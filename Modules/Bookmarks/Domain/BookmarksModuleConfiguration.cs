namespace ReadLater.Bookmarks.Init
{
    public class BookmarksConfiguration
    {
        public string ConnectionString { get; }

        public BookmarksConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
