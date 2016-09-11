using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceCustomer;


namespace ValidateCustomer
{
    public class CustomerValidation : IValidation<ICustomer>
    {
        public void Validate(ICustomer obj)
        {
            if (obj.CustomerName.Trim().Length == 0)
            {
                throw new Exception("Customer : Customer Name is required");
            }
            if (obj.PhoneNumber.Trim().Length == 0)
            {
                throw new Exception("Customer : Customer Phone Number is required");
            }
            if (obj.Address.Trim().Length == 0)
            {
                throw new Exception("Customer : Customer Address is required");
            }
        }
    }

    public class LeadValidation : IValidation<ICustomer>
    {
        public void Validate(ICustomer obj)
        {
            if (obj.CustomerName.Trim().Length == 0)
            {
                throw new Exception("Lead : Customer Name is required");
            }
            if (obj.PhoneNumber.Trim().Length == 0)
            {
                throw new Exception("Lead :Customer Phone Number is required");
            }
        }
    }

}
