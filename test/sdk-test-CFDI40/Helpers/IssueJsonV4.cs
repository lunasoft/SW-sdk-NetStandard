using SW.Services.Stamp;
using System.Threading.Tasks;

namespace Test_SW.Helpers
{
    public class IssueJsonV4 : BaseStamp
    {
        BuildSettings Build = new BuildSettings();
        SW.Services.Issue.IssueJsonV4 issue;

        public IssueJsonV4(bool isToken = false)
        {
            if (isToken)
                issue = new SW.Services.Issue.IssueJsonV4(Build.Url, Build.Token);
            else
                issue = new SW.Services.Issue.IssueJsonV4(Build.Url, Build.User, Build.Password);
        }

        internal override async Task<StampResponseV1> StampResponseV1(string fileName, string stampVersion)
        {
            return (StampResponseV1)await issue.TimbrarJsonV1Async(SignTools.GetJson(fileName));
        }

        internal override async Task<StampResponseV2> StampResponseV2(string fileName, string stampVersion)
        {
            return (StampResponseV2)await issue.TimbrarJsonV2Async(SignTools.GetJson(fileName));
        }

        internal override async Task<StampResponseV3> StampResponseV3(string fileName, string stampVersion)
        {
            return (StampResponseV3)await issue.TimbrarJsonV3Async(SignTools.GetJson(fileName));
        }

        internal override async Task<StampResponseV4> StampResponseV4(string fileName, string stampVersion)
        {
            return (StampResponseV4)await issue.TimbrarJsonV4Async(SignTools.GetJson(fileName));
        }
    }
}
