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

    public partial class UserModuleForm : Form
    {
    //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\OS 10\Documents\dbMS2.mdf"";Integrated Security=True;Connect Timeout=30");
      //  SqlCommand cm = new SqlCommand();
        public UserModuleForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text != txtRepass.Text)
                {
                    MessageBox.Show("Password did not Match:", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                {
                    
                }
                if (MessageBox.Show("Are you sure you want to save this user?", "Saving Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\OS 10\Documents\dbMS2.mdf"";Integrated Security=True;Connect Timeout=30"))
                    {
                        using (SqlCommand cm = new SqlCommand("INSERT INTO tbUser(username,fullname,password,phone)VALUES(@username,@fullname,@password,@phone)", con))
                        {
                            cm.Parameters.AddWithValue("@username", txtUserName.Text);
                            cm.Parameters.AddWithValue("@fullname", txtFullName.Text);
                            cm.Parameters.AddWithValue("@password", txtPass.Text); // Consider hashing the password
                            cm.Parameters.AddWithValue("@phone", txtPhone.Text);

                            con.Open();
                            cm.ExecuteNonQuery();
                            MessageBox.Show("User has been successfully saved!");
                            Clear();
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


        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtUserName.Enabled = true;
        }
        public void Clear()
        {
            txtUserName.Clear();
            txtFullName.Clear();
            txtPass.Clear();
            txtRepass.Clear();
            txtPhone.Clear();
        }

        private void UserModuleForm_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text != txtRepass.Text)
                {
                    MessageBox.Show("Password did not Match:", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to update this user?", "updating Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\OS 10\Documents\dbMS2.mdf"";Integrated Security=True;Connect Timeout=30"))
                    {
                        using (SqlCommand cm = new SqlCommand("UPDATE tbUser SET  fullname = @fullname,password = @password,phone =@phone WHERE username LIKE '"+txtUserName.Text+"'", con))
                        {
                            //cm.Parameters.AddWithValue("@username", txtUserName.Text);
                            cm.Parameters.AddWithValue("@fullname", txtFullName.Text);
                            cm.Parameters.AddWithValue("@password", txtPass.Text); // Consider hashing the password
                            cm.Parameters.AddWithValue("@phone", txtPhone.Text);

                            con.Open();
                            cm.ExecuteNonQuery();
                            MessageBox.Show("User has been successfully update!");
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
