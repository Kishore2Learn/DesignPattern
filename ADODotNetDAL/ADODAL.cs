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

        public TemplateADO(string _connectionString) : base(_connectionString)
        {
            
        }

        public void Open()
        {
            objConn = new SqlConnection(ConnectionString);
            objConn.Open();
            objCommand = new SqlCommand();
            objCommand.Connection = objConn;
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

    public class CustomerDAL : TemplateADO<ICustomer>
    {
        public CustomerDAL(string _connectionString) : base(_connectionString)
        {
        }

        public override List<ICustomer> ExecuteCommand()
        {
            objCommand.CommandText = "select * from dbo.tblcust";
            SqlDataReader objReader = objCommand.ExecuteReader();
            List<ICustomer> objCustomers = new List<ICustomer>();
            while (objReader.Read())
            {
                ICustomer obj = Factory<ICustomer>.Create("Customer");
                obj.CustomerName = objReader["CustomerName"].ToString();
                objCustomers.Add(obj);
            }
            return objCustomers;
        }

        public override void ExecuteCommand(ICustomer obj)
        {
            objCommand.CommandText = "insert into tblcust values('"
                                    + obj.CustomerName +
                                    "','" + obj.PhoneNumber
                                    + "'," + obj.BillAmount
                                    + ",'" + obj.BillDate + "','" +
                                    obj.Address + "','"
                                    + obj.Type + "')";
            objCommand.ExecuteNonQuery();
        }
    }
}
