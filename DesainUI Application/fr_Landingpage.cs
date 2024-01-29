using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesainUI_Application
{
    public partial class fr_Landingpage : Form
    {
        public fr_Landingpage()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            fr_login fr_Login = new fr_login();
            DialogResult dialogResult = fr_Login.ShowDialog();
            this.Close();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fr_Daftar fr_Daftar = new Fr_Daftar();
            fr_Daftar.ShowDialog();
            this.Close();
        }
    }
}
