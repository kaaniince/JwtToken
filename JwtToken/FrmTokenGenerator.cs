using JwtToken.JWT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JwtToken
{
    public partial class FrmTokenGenerator : Form
    {
        public FrmTokenGenerator()
        {
            InitializeComponent();
        }

        private void btnCreateToken_Click(object sender, EventArgs e)
        {
            TokenGenerator tokenGenerator = new TokenGenerator();
            string username = txtUsername.Text;
            string mail = txtMail.Text;
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string token = tokenGenerator.GenerateJWTToken(username,mail, name,surname);
            richTextBox1.Text = token;
        }
    }
}
