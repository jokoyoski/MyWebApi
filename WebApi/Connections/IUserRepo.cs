using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DataAccess;

namespace WebApi.Connections
{
    public interface IUserRepo
    {
        UserDb save(UserDb userDb);
        
            UserDb GetUserByEmail(UserDb userDb);
        //List<UserDb> save(UserDb userDb);
        List<UserDb> saveUser(UserDb userDb);
        //void saveUser(UserDb userDb);
        List<UserDb> GetUsers();
        UserDb GetUserById(int Id);
        void DeleteUser(int Id);
    }
}
