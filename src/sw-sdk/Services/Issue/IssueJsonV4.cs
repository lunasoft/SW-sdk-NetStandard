namespace SW.Services.Issue
{
    public class IssueJsonV4 : BaseStampJsonV4
    {
        public IssueJsonV4(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, "issue/json", proxyPort, proxy)
        {
        }
        public IssueJsonV4(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, "issue/json", proxyPort, proxy)
        {
        }
    }
}
