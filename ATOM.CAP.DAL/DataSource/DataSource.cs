using ATOM.CAP.Core;
using System.Data;

namespace ATOM.CAP.DAL
{
    public abstract class DataSource
    {
        public DataSource(IAppSetting appSetting, IRequestInfo requestInfo)
        {
            _appSetting = appSetting;
            _requestInfo = requestInfo;
        }
        protected readonly IAppSetting _appSetting;
        protected readonly IRequestInfo _requestInfo;

    }
}
