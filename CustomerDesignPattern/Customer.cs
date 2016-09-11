using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceCustomer;

namespace MiddleLayer
{
    public class CustomerBase:ICustomer
    {
        private IValidation<ICustomer> validation = null;

        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }

    public CustomerBase(IValidation<ICustomer> obj)
        {
            validation = obj;
        }

        public virtual void Validate()
        {
            validation.Validate(this);
        }

    }
    public class Customer: CustomerBase
    {
        public Customer(IValidation<ICustomer> obj) :base(obj)
        {

        }
    }
    public class Lead:CustomerBase
    {
        // Dependency Injection
        public Lead(IValidation<ICustomer> obj) :base(obj)
        {

        }
    }
}
