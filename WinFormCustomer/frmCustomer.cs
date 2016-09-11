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
        private ICustomer _cust;

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void setCustomer()
        {
            _cust.CustomerName = txtCustomerName.Text;
            _cust.PhoneNumber = txtPhoneNumber.Text;
            _cust.BillAmount = Convert.ToDecimal(txtBillAmount.Text==string.Empty?"0": txtBillAmount.Text);
            _cust.BillDate = dtpBillDate.Value;
            _cust.Address = txtAddress.Text;
            _cust.Type = cbCustType.Text;
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

                IDAL<ICustomer> customerDAL  = FactoryDAL<IDAL<ICustomer>>.Create("ADODAL");
                customerDAL.Add(_cust);
                customerDAL.Save();
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
            IDAL<ICustomer> customerDAL = FactoryDAL<IDAL<ICustomer>>.Create("ADODAL");
            dtgCustomers.DataSource= customerDAL.Search();
        }

        private void cbCustType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cust = Factory<ICustomer>.Create(cbCustType.Text);
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
