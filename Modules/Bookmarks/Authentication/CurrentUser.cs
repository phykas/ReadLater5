namespace ReadLater.Bookmarks.Authentication
{
    public class CurrentUser
    {
        public CurrentUser(string id, string username)
        {
            Id = id;
            Username = username;
        }

        public string Id { get; }
        public string Username { get; }

    }
}
