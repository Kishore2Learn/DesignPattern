using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiddleLayer;
using Microsoft.Practices.Unity;
using InterfaceCustomer;
using ValidateCustomer;
using CommonDAL;
using InterfaceDAL;

namespace FactoryCustomer
{
    //class CustomerObjects<AnyType>
    //{
    //    private static IUnityContainer _custs = null;

    //    public CustomerObjects()
    //    {
    //    }
    //        _custs = new UnityContainer();

    //        _custs.RegisterType<ICustomer, Customer>(
    //            "Customer"
    //            ,new InjectionConstructor(new CustomerValidation()));

    //        _custs.RegisterType<ICustomer, Lead>(
    //            "Lead"
    //            , new InjectionConstructor(new LeadValidation()));

    //        _custs.RegisterType<IDAL<ICustomer>, CustomerDAL>("ADODAL");

    //    public AnyType GetObjectType(string Type)
    //    {
    //        return _custs.Resolve<AnyType>(Type);
    //    }
    //}

    //public static class Factory<AnyType>
    //{
    //    private static Lazy<CustomerObjects<AnyType>> _lazy;

    //    static Factory()
    //    {
    //       _lazy = new Lazy<CustomerObjects<AnyType>>();
    //    }         

    //    public static AnyType Create(string Type)
    //    {
    //        CustomerObjects<AnyType> objects = _lazy.Value;
    //        return objects.GetObjectType(Type);
    //    }
    //}

    public static class Factory<AnyType>
    {
        private static IUnityContainer _custs = null;

        static Factory()
        {
            _custs = new UnityContainer();

            _custs.RegisterType<ICustomer, Customer>(
                "Customer"
                , new InjectionConstructor(new CustomerValidation()));

            _custs.RegisterType<ICustomer, Lead>(
                "Lead"
                , new InjectionConstructor(new LeadValidation()));

        }

        public static AnyType Create(string Type)
        {
            return _custs.Resolve<AnyType>(Type);
        }
    }
}
