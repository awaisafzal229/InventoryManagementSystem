using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    public partial class CustomerModuleForm : Form
    {
      
        public CustomerModuleForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Customer?", "Saving Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\OS 10\Documents\dbMS2.mdf"";Integrated Security=True;Connect Timeout=30"))
                    {
                        using (SqlCommand cm = new SqlCommand("INSERT INTO tbCustomer(cname,cphone)VALUES(@cname,@cphone)", con))
                        {
                            cm.Parameters.AddWithValue("@cname", txtCName.Text);
                            cm.Parameters.AddWithValue("@cphone", txtCPhone.Text);
                            con.Open();
                            cm.ExecuteNonQuery();
                            MessageBox.Show("Customer has been successfully saved!");
                            Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void Clear()
        {
            txtCName.Clear();
            txtCPhone.Clear();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try { 
            if (MessageBox.Show("Are you sure you want to update this customer?", "updating Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\OS 10\Documents\dbMS2.mdf"";Integrated Security=True;Connect Timeout=30"))
                {
                    using (SqlCommand cm = new SqlCommand("UPDATE tbCustomer SET  cName = @cName,cPhone = @cPhone  WHERE cId LIKE '" + lblCId.Text + "'", con))
                    {
                        //cm.Parameters.AddWithValue("@username", txtUserName.Text);
                        cm.Parameters.AddWithValue("@cName", txtCName.Text);
                        //cm.Parameters.AddWithValue("@password", txtPass.Text); // Consider hashing the password
                        cm.Parameters.AddWithValue("@cPhone", txtCPhone.Text);

                        con.Open();
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Customer has been successfully updated!");
                        this.Dispose();
                    }
                }
            }
        }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                // Log the exception for debugging purposes
            }
}
    }
  }
           

