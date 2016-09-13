using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceDAL;

namespace CommonDAL
{
    public class AbstractDAL<AnyType> : IDAL<AnyType>
    {

        protected string ConnectionString = "";
        protected List<AnyType> AnyTypes = new List<AnyType>();

        public AbstractDAL()
        {
        }

        public virtual void Add(AnyType obj)
        {
            AnyTypes.Add(obj);
        }

        public virtual void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> Search()
        {
            throw new NotImplementedException();
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }


        
    }
}
