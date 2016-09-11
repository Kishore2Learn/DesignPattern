using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL
{
    // Design Pattern : Generic Repository Pattern
    public interface IDAL <AnyType>
    {
        void Add(AnyType obj); // Inmemory Addition
        void Update(AnyType obj); // Inmemory Updation
        List<AnyType> Search();
        void Save(); // Physical Commit
    }
}
