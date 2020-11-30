using SW.Services.Stamp;

namespace SW.Services.Issue
{
    public class IssueV4 : BaseStampV4
    {
        public IssueV4(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, "issue", proxy, proxyPort)
        {
        }
        public IssueV4(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, "issue", proxy, proxyPort)
        {
        }
    }
}
