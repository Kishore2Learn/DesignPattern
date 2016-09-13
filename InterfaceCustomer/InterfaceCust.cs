using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCustomer
{
    
    public interface ICustomer
    {
        int Id { get; set; }
        string CustomerName { get; set; }
        string PhoneNumber { get; set; }
        decimal BillAmount { get; set; }
        DateTime BillDate { get; set; }
        string Address { get; set; }
        string CustomerType { get; set; }

        void Validate();
    }
    
    // Design Pattern : Stratergy Pattern
    public interface IValidation<AnyType>
    {
        void Validate(AnyType obj);
    }

    public class CustomerBase : ICustomer
    {
        private IValidation<ICustomer> validation = null;
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }
        public string CustomerType { get; set; }

        public CustomerBase()
        {

        }

        public CustomerBase(IValidation<ICustomer> obj)
        {
            validation = obj;
        }

        public virtual void Validate()
        {
            validation.Validate(this);
        }
    }
}
