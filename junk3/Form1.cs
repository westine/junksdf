using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace junk3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new JunkSampleEntities())
                {
                    string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    string connectionString = dbContext.Database.Connection.ConnectionString;
                    connectionString = connectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);

                    dbContext.Database.Connection.ConnectionString = connectionString;

                    dbContext.Database.Connection.Open();

                    var account = dbContext.Accounts.FirstOrDefault(ac => ac.Id == 1);
                    textBox1.Text = account.LastName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new JunkSampleEntities())
                {
                    string connectionString = dbContext.Database.Connection.ConnectionString;
                    connectionString = connectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);

                    dbContext.Database.Connection.ConnectionString = connectionString;

                    dbContext.Database.Connection.Open();

                    var account = dbContext.Accounts.FirstOrDefault(ac => ac.Id == 1);
                    textBox1.Text = account.FirstName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
