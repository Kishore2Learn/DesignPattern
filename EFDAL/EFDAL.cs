using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InterfaceDAL;
using InterfaceCustomer;

namespace EFDAL
{
    public class AbstractTemplateEF<AnyType> : DbContext, IDAL<AnyType>
        where AnyType : class
    {
        public AbstractTemplateEF()
            : base("name=Conn")
        {

        }

        public void Add(AnyType obj)
        {
            Set<AnyType>().Add(obj);
        }

        public void Save()
        {
            SaveChanges();
        }

        public List<AnyType> Search()
        {
            return Set<AnyType>().AsQueryable<AnyType>().ToList<AnyType>();
        }

        public void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomerEFDAL:AbstractTemplateEF<CustomerBase>
    {
        public CustomerEFDAL()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerBase>().ToTable("dbo.tblCust");
        }
    }
}
