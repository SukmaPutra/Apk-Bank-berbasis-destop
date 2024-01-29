using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace DesainUI_Application
{
    public partial class infoakun : Form
    {
        private SQLiteConnection connection;
        private DatabaseManager dbManager;

        public void RefreshInfoAkun()
        {
            // Tampilkan informasi akun sesuai dengan rekening terbaru
            SetAccountNumberLabel(lblrekening.Text);
        }

        public infoakun()
        {
            InitializeComponent();
            dbManager = DatabaseManager.GetInstance();
            connection = dbManager.GetConnection();

        }

        public void SetIdNasabah(string idNasabah)
        {
            lbl_id.Text = idNasabah;
        }
        public void SetAccountNumberLabel(string accountNumber)
        {
            lblrekening.Text = accountNumber;

            // Tampilkan informasi akun
            string akunInfo = GetAkun(accountNumber);
            if (akunInfo != null)
            {
                string[] akunInfoArray = akunInfo.Split('|');

                if (akunInfoArray.Length == 7)
                {
                    lbl_id.Text = akunInfoArray[0];
                    lblnama.Text = akunInfoArray[1];
                    lblnamaakun.Text = akunInfoArray[1];
                    lblemail.Text = akunInfoArray[2];
                    lblusername.Text = akunInfoArray[3];
                    lblpassword.Text = akunInfoArray[4];
                    lbltlpn.Text = akunInfoArray[5];
                    lblPin.Text = akunInfoArray[6];

                    // Set properti pada form editakun
                    editakun edit = new editakun(this, lbl_id.Text, lblnama.Text, lbltlpn.Text, lblemail.Text, lblusername.Text, lblpassword.Text, lblPin.Text);
                    edit.Nama = lblnama.Text;
                    edit.NoHp = lbltlpn.Text;
                    edit.Email = lblemail.Text;
                    edit.Username = lblusername.Text;
                    edit.Password = lblpassword.Text;
                    edit.Pin = lblPin.Text;
                    edit.ID = lbl_id.Text;
                    /*edit.Pin = lblPin.Text;*/

                }
            }
        }



        private string GetAkun(string accountNumber)
        {
            try
            {
                dbManager.OpenConnection();

                string query = "SELECT id_nasabah, nama, email, username, password, noHp, pinATM FROM Nasabah WHERE norekening = @accountNumber";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@accountNumber", accountNumber);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Menggunakan "|" sebagai pemisah untuk data yang akan ditampilkan di label
                            return $"{reader["id_nasabah"]}|{reader["nama"]}|{reader["email"]}|{reader["username"]}|{reader["password"]}|{reader["noHp"]}|{reader["pinATM"]}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
            finally { dbManager.CloseConnection(); }

            return null;
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblnama_Click(object sender, EventArgs e)
        {

        }

        private void lblnamaakun_Click(object sender, EventArgs e)
        {

        }

        private void lblemail_Click(object sender, EventArgs e)
        {

        }

        private void lblusername_Click(object sender, EventArgs e)
        {

        }

        private void lblpassword_Click(object sender, EventArgs e)
        {

        }

        private void lbltlpn_Click(object sender, EventArgs e)
        {

        }

        private void infoakun_Load(object sender, EventArgs e)
        {

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            SetAccountNumberLabel(lblrekening.Text);

            // Create an instance of the editakun form
            editakun edit = new editakun(this, lbl_id.Text, lblnama.Text, lbltlpn.Text, lblemail.Text, lblusername.Text, lblpassword.Text, lblPin.Text);


            this.Hide();
            edit.ShowDialog();
            this.Close();

            RefreshInfoAkun();
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            


            fr_menuutama menu = (fr_menuutama)Application.OpenForms["fr_menuutama"];
            menu.Show();
            this.Hide();



        }
    }
}
