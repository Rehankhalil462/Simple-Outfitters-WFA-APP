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
    public partial class Product : Form
    {
        FileInfo file;
        StreamWriter writer;
        string date_time;
        DataAccess dataAccess;
        public Product()
        {
            InitializeComponent();
            dataAccess = new DataAccess();
            file = new FileInfo(@"C:\Users\Qasim\Desktop\Outfitters\Log.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sname = SNametextBox.Text;
            string sdescription = SDescriptionrichTextBox.Text;
            int sprice = int.Parse(SPricetextBox.Text);

            int received = dataAccess.InsertintoShirts(sname, sdescription, sprice);
            if (received == 1)
            {
                date_time = DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString();
                writer = file.AppendText();
                writer.WriteLine("Shirt is  Saved At " + date_time);
                writer.Close();
                MessageBox.Show("Shirt is saved Succesfully");
            }
            else
            {
                MessageBox.Show("Submission Failed");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SNametextBox.Clear();
            SDescriptionrichTextBox.Clear();
            SPricetextBox.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 dashboard = new Form1();
            dashboard.Show();
        }
    }
}
