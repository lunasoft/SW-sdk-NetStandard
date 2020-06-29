using System;
using SW.Helpers;

namespace SW.Services.Storage
{
    internal class StorageResponseHandler : ResponseHandler<StorageResponse>
    {
        public override StorageResponse HandleException(Exception ex)
        {
            return ex.ToStorageResponse();
        }
    }
}
