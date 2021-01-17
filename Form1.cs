using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Outfitters
{
   
    public partial class Form1 : Form
    {
        FileInfo file;
        StreamWriter writer;
        string date_time;
        public Form1()
        {
            InitializeComponent();
            file = new FileInfo(@"C:\Users\Qasim\Desktop\Outfitters\Log.txt");
            //file = new FileInfo(@"your directory pathname);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            date_time = DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString();
            writer = file.AppendText();
            writer.WriteLine("Add Shirts Form Opened At " + date_time);
            writer.Close();
            this.Hide();
            Product form = new Product();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            date_time = DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString();
            writer = file.AppendText();
            writer.WriteLine("Customer Registeration Form Opened At " + date_time);
            writer.Close();
            this.Hide();
            Customer customerRegistration = new Customer();
            customerRegistration.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            date_time = DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString();
            writer = file.AppendText();
            writer.WriteLine("View Shirts Form Opened At " + date_time);
            writer.Close();
            this.Hide();
            ViewProduct viewSupplements = new ViewProduct();
            viewSupplements.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            date_time = DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString();
            writer = file.AppendText();
            writer.WriteLine("View Record Form Opened At " + date_time);
            writer.Close();
            this.Hide();
            ViewRecord viewCustomer = new ViewRecord();
            viewCustomer.Show();
        }
    }
}
