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
    public partial class ProductModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\OS 10\Documents\dbMS2.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public ProductModuleForm()
        {
            InitializeComponent();
            LoadProduct();
        }
        public void LoadProduct()
        {
            comboCat.Items.Clear();
            cm = new SqlCommand("SELECT catname from tbCategory", con);
            con.Open();
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                comboCat.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                {

                }
                if (MessageBox.Show("Are you sure you want to save this Product?", "Saving Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\OS 10\Documents\dbMS2.mdf"";Integrated Security=True;Connect Timeout=30"))
                    {
                        using (SqlCommand cm = new SqlCommand("INSERT INTO tbProduct(pname, pqty, pprice, pdescription, pcategory)VALUES(@pname, @pqty, @pprice, @pdescription, @pcategory)", con))
                        {
                            cm.Parameters.AddWithValue("@pname", txtPName.Text);
                            cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtPQty.Text));
                            cm.Parameters.AddWithValue("@pprice", txtPPrice.Text); // Consider hashing the password
                            cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                            cm.Parameters.AddWithValue("@pcategory", comboCat.Text);


                            con.Open();
                            cm.ExecuteNonQuery();
                            MessageBox.Show("Product has been successfully saved!");
                            ClearEverything();
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
        public void ClearEverything()
        {
            txtPName.Clear();
            txtPQty.Clear();
            txtPPrice.Clear();
            txtPDes.Clear();
            comboCat.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearEverything();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this product?", "updating Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\OS 10\Documents\dbMS2.mdf"";Integrated Security=True;Connect Timeout=30"))
                    {
                        using (SqlCommand cm = new SqlCommand("UPDATE tbProduct SET  pname = @pname,pqty = @pqty,pprice=@pprice,pdescription = @pdescription, pcategory=@pcategory WHERE pid LIKE '" + lblPid.Text + "'", con))
                        {
                            //cm.Parameters.AddWithValue("@username", txtUserName.Text);
                            cm.Parameters.AddWithValue("@pname", txtPName.Text);
                            cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtPQty.Text));
                            cm.Parameters.AddWithValue("@pprice", txtPPrice.Text); // Consider hashing the password
                            cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                            cm.Parameters.AddWithValue("@pcategory", comboCat.Text);

                            con.Open();
                            cm.ExecuteNonQuery();
                            MessageBox.Show("Product has been successfully update!");
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
