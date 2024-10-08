﻿using SW.Services.Stamp;
using System.Threading.Tasks;

namespace Test_SW.Helpers
{
    public class StampV4 : BaseStamp
    {
        BuildSettings Build = new BuildSettings();
        SW.Services.Stamp.StampV4 stamp;

        public StampV4(bool isToken = false)
        {
            if (isToken)
                stamp = new SW.Services.Stamp.StampV4(Build.Url, Build.Token);
            else
                stamp = new SW.Services.Stamp.StampV4(Build.Url, Build.User, Build.Password);
        }

        internal override async Task<StampResponseV1> StampResponseV1(string fileName, string stampVersion)
        {
            return (StampResponseV1)await stamp.TimbrarV1Async(SignTools.GetXml(fileName, Build.Pfx, Build.PfxPassword));
        }

        internal override async Task<StampResponseV2> StampResponseV2(string fileName, string stampVersion)
        {
            return (StampResponseV2)await stamp.TimbrarV2Async(SignTools.GetXml(fileName, Build.Pfx, Build.PfxPassword));
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
