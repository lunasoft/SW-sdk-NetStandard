using System;
using SW.Services.Stamp;
using System.Threading.Tasks;

namespace Test_SW.Helpers
{
    public class StampService : BaseStamp
    {
        private bool isToken;

        public StampService(bool isToken = false)
        {
            this.isToken = isToken;
        }

        internal override async Task<StampResponseV1> StampResponseV1(string fileName, string stampVersion)
        {
            switch (stampVersion)
            {
                case "V1":
                    StampV1 stampV1 = new StampV1(isToken);
                    return await stampV1.StampResponseV1(fileName, stampVersion);
                case "V2":
                    StampV2 stampV2 = new StampV2(isToken);
                    return await stampV2.StampResponseV1(fileName, stampVersion);
                case "V3":
                    throw new NotImplementedException();
                case "V4":
                    StampV4 stampV4 = new StampV4(isToken);
                    return await stampV4.StampResponseV1(fileName, stampVersion);
                case "IssueJson":
                    IssueJson issueJson = new IssueJson(isToken);
                    return await issueJson.StampResponseV1(fileName, stampVersion);
                case "IssueJsonV4":
                    IssueJsonV4 issueJsonV4 = new IssueJsonV4(isToken);
                    return await issueJsonV4.StampResponseV1(fileName, stampVersion);
                default:
                    throw new NotImplementedException();
            }
        }

        internal override async Task<StampResponseV2> StampResponseV2(string fileName, string stampVersion)
        {
            switch (stampVersion)
            {
                case "V1":
                    StampV1 stampV1 = new StampV1(isToken);
                    return await stampV1.StampResponseV2(fileName, stampVersion);
                case "V2":
                    StampV2 stampV2 = new StampV2(isToken);
                    return await stampV2.StampResponseV2(fileName, stampVersion);
                case "V3":
                    throw new NotImplementedException();
                case "V4":
                    StampV4 stampV4 = new StampV4(isToken);
                    return await stampV4.StampResponseV2(fileName, stampVersion);
                case "IssueJson":
                    IssueJson issueJson = new IssueJson(isToken);
                    return await issueJson.StampResponseV2(fileName, stampVersion);
                case "IssueJsonV4":
                    IssueJsonV4 issueJsonV4 = new IssueJsonV4(isToken);
                    return await issueJsonV4.StampResponseV2(fileName, stampVersion);
                default:
                    throw new NotImplementedException();
            }
        }

        internal override async Task<StampResponseV3> StampResponseV3(string fileName, string stampVersion)
        {
            switch (stampVersion)
            {
                case "V1":
                    StampV1 stampV1 = new StampV1(isToken);
                    return await stampV1.StampResponseV3(fileName, stampVersion);
                case "V2":
                    StampV2 stampV2 = new StampV2(isToken);
                    return await stampV2.StampResponseV3(fileName, stampVersion);
                case "V3":
                    throw new NotImplementedException();
                case "V4":
                    StampV4 stampV4 = new StampV4(isToken);
                    return await stampV4.StampResponseV3(fileName, stampVersion);
                case "IssueJson":
                    IssueJson issueJson = new IssueJson(isToken);
                    return await issueJson.StampResponseV3(fileName, stampVersion);
                case "IssueJsonV4":
                    IssueJsonV4 issueJsonV4 = new IssueJsonV4(isToken);
                    return await issueJsonV4.StampResponseV3(fileName, stampVersion);
                default:
                    throw new NotImplementedException();
            }
        }

        internal override async Task<StampResponseV4> StampResponseV4(string fileName, string stampVersion)
        {
            switch (stampVersion)
            {
                case "V1":
                    StampV1 stampV1 = new StampV1(isToken);
                    return await stampV1.StampResponseV4(fileName, stampVersion);
                case "V2":
                    StampV2 stampV2 = new StampV2(isToken);
                    return await stampV2.StampResponseV4(fileName, stampVersion);
                case "V3":
                    throw new NotImplementedException();
                case "V4":
                    StampV4 stampV4 = new StampV4(isToken);
                    return await stampV4.StampResponseV4(fileName, stampVersion);
                case "IssueJson":
                    IssueJson issueJson = new IssueJson(isToken);
                    return await issueJson.StampResponseV4(fileName, stampVersion);
                case "IssueJsonV4":
                    IssueJsonV4 issueJsonV4 = new IssueJsonV4(isToken);
                    return await issueJsonV4.StampResponseV4(fileName, stampVersion);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
