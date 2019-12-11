namespace SW.Services.Issue
{
    public class IssueJson : BaseStampJson
    {
        public IssueJson(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, "issue/json", proxyPort, proxy)
        {
        }
        public IssueJson(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, "issue/json", proxyPort, proxy)
        {
        }
    }
}
