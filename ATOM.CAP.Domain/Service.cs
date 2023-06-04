using ATOM.CAP.Core;

namespace ATOM.Domain
{
    public abstract class Service
    {
        public Service(IAppSetting appSetting , IRequestInfo requestInfo)
        {
            _appSetting  = appSetting;
            _requestInfo = requestInfo;
        }

        protected readonly IRequestInfo _requestInfo;
        protected readonly IAppSetting _appSetting;


    }


}
