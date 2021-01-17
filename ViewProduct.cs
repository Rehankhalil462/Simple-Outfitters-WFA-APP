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
    public partial class ViewProduct : Form
    {
        DataAccess dataAcces;
        List<ProductClass> supplementClasses;
        public ViewProduct()
        {
            InitializeComponent();
            dataAcces = new DataAccess();
            supplementClasses = dataAcces.getAllShirts();
        }

        private void ViewProduct_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = supplementClasses;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 dashboard = new Form1();
            dashboard.Show();
        }
    }
}
