using SW.Services.Stamp;
using System.Threading.Tasks;

namespace Test_SW.Helpers
{
    public class StampV1 : BaseStamp
    {
        BuildSettings Build = new BuildSettings();
        Stamp stamp;

        public StampV1(bool isToken = false)
        {
            if(isToken)
                stamp = new Stamp(Build.Url, Build.Token);
            else
                stamp = new Stamp(Build.Url, Build.User, Build.Password);
        }

        internal override async Task<StampResponseV1> StampResponseV1(string fileName, string stampVersion)
        {
            return (StampResponseV1)await stamp.TimbrarV1Async(SignTools.GetXml(fileName, Build.Pfx, Build.PfxPassword));
        }

        internal override async Task<StampResponseV2> StampResponseV2(string fileName, string stampVersion)
        {
            return (StampResponseV2) await stamp.TimbrarV2Async(SignTools.GetXml(fileName, Build.Pfx, Build.PfxPassword));
        }

        internal override async Task<StampResponseV3> StampResponseV3(string fileName, string stampVersion)
        {
            return (StampResponseV3)await stamp.TimbrarV3Async(SignTools.GetXml(fileName, Build.Pfx, Build.PfxPassword));
        }

        internal override async Task<StampResponseV4> StampResponseV4(string fileName, string stampVersion)
        {
            return (StampResponseV4)await stamp.TimbrarV4Async(SignTools.GetXml(fileName, Build.Pfx, Build.PfxPassword));
        }
    }
}
