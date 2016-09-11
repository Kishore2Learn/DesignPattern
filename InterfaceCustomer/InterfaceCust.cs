using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCustomer
{
    public interface ICustomer
    {
        string CustomerName { get; set; }
        string PhoneNumber { get; set; }
        decimal BillAmount { get; set; }
        DateTime BillDate { get; set; }
        string Address { get; set; }
        string Type { get; set; }

        void Validate();
    }

    // Design Pattern : Stratergy Pattern
    public interface IValidation<AnyType>
    {
        void Validate(AnyType obj);
    }
}
