using SW.Services.Stamp;
using System.Threading.Tasks;

namespace Test_SW.Helpers
{
    public abstract class BaseStamp
    {
        internal abstract Task<StampResponseV1> StampResponseV1(string fileName, string stampVersion);

        internal abstract Task<StampResponseV2> StampResponseV2(string fileName, string stampVersion);

        internal abstract Task<StampResponseV3> StampResponseV3(string fileName, string stampVersion);

        internal abstract Task<StampResponseV4> StampResponseV4(string fileName, string stampVersion);
    }
}
