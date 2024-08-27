using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDapper.Data.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>>GetData<T,P>(string spName,P parameters,string ConnectionId= "DefaultConnection");

        Task SaveData<T>(string spName,T parameters,string ConnectionId= "DefaultConnection");


    }
}
