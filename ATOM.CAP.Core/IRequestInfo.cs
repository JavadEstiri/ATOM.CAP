using ATOM.CAP.Model;

namespace ATOM.CAP.Core
{
    public interface IRequestInfo
    {
        public int UserID { get; }

        public UserType UserType { get; }
        public string UserTypeName { get; }

        public string? CellPhone { get; }
        public string? FirstName { get; }
        public string? LastName { get; }
        public string? RemoteIP { get; }
        public string? AppURL { get; }
    }
}