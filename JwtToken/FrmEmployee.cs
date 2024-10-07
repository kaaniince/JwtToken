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
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection("Data Source=KAAN;Initial Catalog=JWTokenProject;Integrated Security=True");
        private void FrmEmployee_Load(object sender, EventArgs e)
        {

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TblEmployee", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }
    }
}
