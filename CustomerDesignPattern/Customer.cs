using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceCustomer;

namespace MiddleLayer
{
    public class Customer: CustomerBase
    {
        public Customer()
        {

        }

        public Customer(IValidation<ICustomer> obj) :base(obj)
        {

        }
    }
    public class Lead:CustomerBase
    {
        // Dependency Injection
        public Lead()
        {

        }
        public Lead(IValidation<ICustomer> obj) :base(obj)
        {

        }
    }
}
