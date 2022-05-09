using SW.Services.Stamp;
using System.Threading.Tasks;

namespace Test_SW.Helpers
{
    public class IssueJson : BaseStamp
    {
        BuildSettings Build = new BuildSettings();
        SW.Services.Issue.IssueJson issue;

        public IssueJson(bool isToken = false)
        {
            if (isToken)
                issue = new SW.Services.Issue.IssueJson(Build.Url, Build.Token);
            else
                issue = new SW.Services.Issue.IssueJson(Build.Url, Build.User, Build.Password);
        }

        internal override async Task<StampResponseV1> StampResponseV1(string fileName, string stampVersion)
        {
            return (StampResponseV1)await issue.TimbrarJsonV1Async(SignTools.GetXml(fileName, Build.Pfx, Build.PfxPassword));
        }

        internal override async Task<StampResponseV2> StampResponseV2(string fileName, string stampVersion)
        {
            return (StampResponseV2)await issue.TimbrarJsonV2Async(SignTools.GetXml(fileName, Build.Pfx, Build.PfxPassword));
        }

        internal override async Task<StampResponseV3> StampResponseV3(string fileName, string stampVersion)
        {
            return (StampResponseV3)await issue.TimbrarJsonV3Async(SignTools.GetXml(fileName, Build.Pfx, Build.PfxPassword));
        }

        internal override async Task<StampResponseV4> StampResponseV4(string fileName, string stampVersion)
        {
            return (StampResponseV4)await issue.TimbrarJsonV4Async(SignTools.GetXml(fileName, Build.Pfx, Build.PfxPassword));
        }
    }
}
