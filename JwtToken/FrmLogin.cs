using JwtToken.JWT;
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

namespace JwtToken
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=KAAN;Initial Catalog=JWTokenProject;Integrated Security=True");

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            TokenGenerator tokenGenerator = new TokenGenerator();
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("Select * from TblUser where Username=@username and Password=@password", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@username", txtUsername.Text);
            sqlCommand.Parameters.AddWithValue("@password", txtPassword.Text);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                string token = tokenGenerator.GenerateJWTToken2(txtUsername.Text);

                FrmEmployee frmEmployee = new FrmEmployee();
                frmEmployee.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
                txtPassword.Clear();
                txtUsername.Clear();
                txtPassword.Focus();
            }
            sqlConnection.Close();

        }
    }
}
