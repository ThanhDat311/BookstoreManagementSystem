using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreManagementSystem
{
    public partial class frmManageProductcs : Form
    {
        
        public frmManageProductcs()
        {
            InitializeComponent();
        }

  

        private void btnBookManagement_Click(object sender, EventArgs e)
        {
            frmBookManagement mainForm = new frmBookManagement();
            this.Hide();
            mainForm.Show();
        }

        private void btnGenreManagement_Click(object sender, EventArgs e)
        {
            frmGenreManagement mainForm = new frmGenreManagement();
            this.Hide(); mainForm.Show();
        }

        private void btnCustomerManagement_Click(object sender, EventArgs e)
        {
            frmCustomerManagement mainForm = new frmCustomerManagement();
            this.Hide(); mainForm.Show();
        }

        public void btnEmployeesManagement_Click(object sender, EventArgs e)
        {
     
            frmEmployeeManagement mainForm = new frmEmployeeManagement();
            this.Hide(); mainForm.Show();
        }

        public void btnAccountManagement_Click(object sender, EventArgs e)
        {
            frmEmployeeAccount mainForm = new frmEmployeeAccount();
            this.Hide(); mainForm.Show();
        }

        private void frmManageProductcs_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnStatistical_Click(object sender, EventArgs e)
        {
            frmStatistical mainForm = new frmStatistical();
            this.Hide(); mainForm.Show();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            frmCreateAnInvoice mainForm = new frmCreateAnInvoice();
            this.Hide(); mainForm.Show();
        }
    }
}
