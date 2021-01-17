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
    public partial class Customer : Form
    {
        FileInfo file;
        StreamWriter writer;
        string date_time;
        private DataAccess dataAccess;
        private List<ProductClass> Shirts;
        public Customer()
        {
            InitializeComponent();
            file = new FileInfo(@"C:\Users\Qasim\Desktop\Outfitters\Log.txt");
            dataAccess = new DataAccess();
            Shirts = dataAccess.getAllShirts();
            comboBox2.Items.Add("None");
            for (int i = 0; i < Shirts.Count; i++)
            {
                comboBox2.Items.Add(Shirts[i].SName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cname = textBox1.Text;
            string ccnic = maskedTextBox2.Text;
            string caddress = textBox2.Text;
            string cphone = maskedTextBox1.Text;
            string sname = comboBox2.SelectedItem.ToString();
            string squantity = textBox3.Text;
            int payment = int.Parse(textBox5.Text);
            int received = dataAccess.InsertintoCustomer(cname, ccnic, caddress, cphone, sname, squantity, payment);
            if (received == 1)
            {
                date_time = DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString();
                writer = file.AppendText();
                writer.WriteLine("Customer Registered Successfully At " + date_time);
                writer.Close();

                MessageBox.Show("Customer is registered Successfully.");
            }
            else
            {
                MessageBox.Show("Submission Failed.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            maskedTextBox2.Clear();

            textBox2.Clear();
            maskedTextBox1.Clear();

            textBox3.Clear();
            comboBox2.SelectedIndex = 0;
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 dashboard = new Form1();
            dashboard.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                textBox4.Text = "";
            }
            else
            {
                textBox4.Text = Shirts[comboBox2.SelectedIndex - 1].SPrice.ToString();
            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox3.Text != "0" && int.Parse(textBox3.Text) > 0)
            {
                int totalprice = int.Parse(textBox3.Text) * int.Parse(textBox4.Text);
                textBox5.Text = totalprice.ToString();
            }
        }
    }
}
