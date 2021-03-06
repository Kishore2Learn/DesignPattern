﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using InterfaceCustomer;
using InterfaceDAL;
using ADODotNetDAL;
using EFDAL;

namespace FactoryDAL
{

    public static class FactoryDAL<AnyType>
    {
        private static IUnityContainer _custs = null;

        static FactoryDAL()
        {
            _custs = new UnityContainer();

            _custs.RegisterType<IDAL<CustomerBase>, CustomerDAL>("ADODAL");
            _custs.RegisterType<IDAL<CustomerBase>, CustomerEFDAL>("EFDAL");

        }

        public static AnyType getDal(string Type)
        {
            return _custs.Resolve<AnyType>(Type
                , new ResolverOverride[]
                {
                    new ParameterOverride("_connectionString",
                    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DbCustomer;Integrated Security=True")
                }
                );
        }
    }
}
