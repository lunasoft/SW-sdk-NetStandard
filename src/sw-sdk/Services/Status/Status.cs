﻿using ExternalServices.ConsultaCFDIService;

namespace SW.Services.Status
{
    public class Status : StatusService
    {
        public Status(string url, int receiveTimeoutInSeconds = 60) : base(url, receiveTimeoutInSeconds)
        {
        }
        internal override Acuse StatusRequest(string rfcEmisor, string rfcReceptor, string total, string uuid)
        {
            return this.RequestStatus(rfcEmisor, rfcReceptor, total, uuid);
        }
        public Acuse GetStatusCFDI(string rfcEmisor, string rfcReceptor, string Total, string uuid)
        {
            return StatusRequest(rfcEmisor, rfcReceptor, Total, uuid);
        }
    }
}
