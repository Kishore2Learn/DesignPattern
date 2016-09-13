using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDAL;
using InterfaceDAL;
using System.Data;
using System.Data.SqlClient;
using InterfaceCustomer;
using FactoryCustomer;

namespace ADODotNetDAL
{
    public abstract class TemplateADO<AnyType> : AbstractDAL<AnyType>
    {
        protected SqlConnection objConn = null;
        protected SqlCommand objCommand = null;

        public TemplateADO() : base()
        {
            
        }

        public void Open()
        {
            try
            {
                objConn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DbCustomer;Integrated Security=True");
                objConn.Open();
                objCommand = new SqlCommand();
                objCommand.Connection = objConn;
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
        }

        public abstract void ExecuteCommand(AnyType obj);
        public abstract List<AnyType> ExecuteCommand();

        public void Close()
        {
            objConn.Close();
        }

        // Design Pattern : Template Pattern

        public void Execute(AnyType obj) // Fixed sequence
        {
            Open();
            ExecuteCommand(obj);
            Close();
        }

        public List<AnyType> Execute()
        {
            List<AnyType> objTypes = null;
            Open();
            objTypes = ExecuteCommand();
            Close();
            return objTypes;
        }

        public override void Save()
        {
            foreach (AnyType item in AnyTypes)
            {
                Execute(item);
            }
        }

        public override List<AnyType> Search()
        {
            return Execute();
        }
    }

    public class CustomerDAL : TemplateADO<CustomerBase>
    {
        public CustomerDAL(string _connectionString) : base()
        {
        }

        public override List<CustomerBase> ExecuteCommand()
        {
            objCommand.CommandText = "select * from dbo.tblcust";
            SqlDataReader objReader = objCommand.ExecuteReader();
            List<CustomerBase> objCustomers = new List<CustomerBase>();
            while (objReader.Read())
            {
                CustomerBase obj = Factory<CustomerBase>.Create("Customer");
                obj.Id = (int)objReader["Id"];
                obj.CustomerName = objReader["CustomerName"].ToString();
                objCustomers.Add(obj);
            }
            return objCustomers;
        }

        public override void ExecuteCommand(CustomerBase obj)
        {
            objCommand.CommandText = "insert into tblcust values('"
                                    + obj.CustomerName +
                                    "','" + obj.PhoneNumber
                                    + "'," + obj.BillAmount
                                    + ",'" + obj.BillDate + "','" +
                                    obj.Address + "','"
                                    + obj.CustomerType + "')";
            objCommand.ExecuteNonQuery();
        }
    }
}
