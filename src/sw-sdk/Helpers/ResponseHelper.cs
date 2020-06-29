﻿using SW.Services.AcceptReject;
using SW.Services.Account;
using SW.Services.Authentication;
using SW.Services.Cancelation;
using SW.Services.Csd;
using SW.Services.Pdf;
using SW.Services.Pendings;
using SW.Services.Relations;
using SW.Services.Stamp;
using SW.Services.Storage;
using SW.Services.Validate;
using sw_sdk.Services.Resend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Helpers
{
    internal static class ResponseHelper
    {
        internal static AuthResponse ToAuthResponse(this Exception ex)
        {
            return new AuthResponse()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static AccountResponse ToAccountResponse(this Exception ex)
        {
            return new AccountResponse()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static CancelationResponse ToCancelationResponse(this Exception ex)
        {
            return new CancelationResponse()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static StampResponseV1 ToStampResponseV1(this Exception ex)
        {
            return new StampResponseV1()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static StampResponseV2 ToStampResponseV2(this Exception ex)
        {
            return new StampResponseV2()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static StampResponseV3 ToStampResponseV3(this Exception ex)
        {
            return new StampResponseV3()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static StampResponseV4 ToStampResponseV4(this Exception ex)
        {
            return new StampResponseV4()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static ValidateXmlResponse ToValidateXmlResponse(this Exception ex)
        {
            return new ValidateXmlResponse()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static ValidateLcoResponse ToValidateLcoResponse(this Exception ex)
        {
            return new ValidateLcoResponse()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static ValidateLrfcResponse ToValidateLrfcResponse(this Exception ex)
        {
            return new ValidateLrfcResponse()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static string GetErrorDetail(this Exception ex)
        {
            if (ex.InnerException != null)
                return ex.InnerException.Message;
            else
                return "";
        }
        internal static AcceptRejectResponse ToAcceptRejectResponse(this Exception ex)
        {
            return new AcceptRejectResponse()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static RelationsResponse ToRelationsResponse(this Exception ex)
        {
            return new RelationsResponse()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static PendingsResponse ToPendingsResponse(this Exception ex)
        {
            return new PendingsResponse()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static PdfResponse ToPdfResponse(this Exception ex)
        {
            return new PdfResponse()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static ResendResponse ToResendResponse(this Exception ex)
        {
            return new ResendResponse()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static UploadCsdResponse ToCargaCsdResponse(this Exception ex)
        {
            return new UploadCsdResponse()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
        internal static StorageResponse ToStorageResponse(this Exception ex)
        {
            return new StorageResponse()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.GetErrorDetail()
            };
        }
    }
}
