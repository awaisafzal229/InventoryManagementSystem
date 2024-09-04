using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class CategoryModuleForm : Form
    {
        public CategoryModuleForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Category?", "Saving Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\OS 10\Documents\dbMS2.mdf"";Integrated Security=True;Connect Timeout=30"))
                    {
                        using (SqlCommand cm = new SqlCommand("INSERT INTO tbCategory(catname)VALUES(@catname)", con))
                        {
                            cm.Parameters.AddWithValue("@catname", txtCatName.Text);
                          //  cm.Parameters.AddWithValue("@cphone", txtCPhone.Text);
                            con.Open();
                            cm.ExecuteNonQuery();
                            MessageBox.Show("Category has been successfully saved!");
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
            txtCatName.Clear();
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
            try
            {
                if (MessageBox.Show("Are you sure you want to update this category?", "updating Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\OS 10\Documents\dbMS2.mdf"";Integrated Security=True;Connect Timeout=30"))
                    {
                        using (SqlCommand cm = new SqlCommand("UPDATE tbCategory SET  catname = @catname  WHERE catid LIKE '" + lblCatId.Text + "'", con))
                        {
                            //cm.Parameters.AddWithValue("@username", txtUserName.Text);
                            cm.Parameters.AddWithValue("@catname", txtCatName.Text);
                            //cm.Parameters.AddWithValue("@password", txtPass.Text); // Consider hashing the password
                            //cm.Parameters.AddWithValue("@cPhone", txtCPhone.Text);

                            con.Open();
                            cm.ExecuteNonQuery();
                            MessageBox.Show("Category has been successfully updated!");
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
