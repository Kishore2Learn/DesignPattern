using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfaceCustomer;
using FactoryCustomer;
using FactoryDAL;
using InterfaceDAL;


namespace WinFormCustomer
{
    public partial class frmCustomer : Form
    {
        private CustomerBase _cust;
        private string _DALtype;
        private IDAL<CustomerBase>  dal;

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void setCustomer()
        {
            try
            {
                _cust.CustomerName = txtCustomerName.Text;
                _cust.PhoneNumber = txtPhoneNumber.Text;
                _cust.BillAmount = Convert.ToDecimal(txtBillAmount.Text == string.Empty ? "0" : txtBillAmount.Text);
                _cust.BillDate = dtpBillDate.Value;
                _cust.Address = txtAddress.Text;
                _cust.CustomerType = cbCustType.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("One or more details missing : "+ ex.Message);
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            setCustomer();
            try
            {
                _cust.Validate();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            setCustomer();
            try
            {
                _cust.Validate();
                dal.Add(_cust);
                dal.Save();
                LoadGrid();
                MessageBox.Show("New "+cbCustType.Text + " added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadGrid()
        {
            try
            {
                dtgCustomers.DataSource = dal.Search();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load data in grid : " + ex.Message);
            }
        }

        private void cbCustType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cust = Factory<CustomerBase>.Create(cbCustType.Text);
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DALtype = comboBox1.Text;
            try
            {
                dal = FactoryDAL<IDAL<CustomerBase>>.getDal(_DALtype);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to create DAL : "+ ex.Message);
            }
            LoadGrid();
        }
    }
}
