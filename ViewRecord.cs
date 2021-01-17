using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Outfitters
{
    public partial class ViewRecord : Form
    {
        DataAccess dataAccess;
        List<CustomerClass> customers;
        public ViewRecord()
        {
            InitializeComponent();
            dataAccess = new DataAccess();
            customers = dataAccess.getallCustomers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void ViewRecord_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = customers;
        }
    }
}
