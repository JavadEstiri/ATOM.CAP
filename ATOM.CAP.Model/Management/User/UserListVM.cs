using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOM.CAP.Model
{
    public class UserListVM : Model
    {
        public int PersonID { get; set; }

        public UserType UserType { get; set; }

        public UserStatusType StatusType { get; set; }
    }
}
