using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesainUI_Application
{
    public partial class fr_tariktunai : Form
    {
        private DatabaseManager dbManager;
        private SQLiteConnection connection;

        public fr_tariktunai()
        {
            InitializeComponent();
            dbManager = DatabaseManager.GetInstance();
            connection = dbManager.GetConnection();
        }

        public void SetBalanceLabel(string balance)
        {
            lblsaldo.Text = balance;
        }
        public void SetIdNasabah(string idNasabah)
        {
            lbl_id.Text = idNasabah;
        }
        public void SetAccountNumberLabel(string accountNumber)
        {
            lblnorekening.Text = accountNumber;
            string idNasabah = GetIDNasabah(accountNumber);
            //lbl_idnasabah.Text = idNasabah;
            lblsaldo.Text = GetBalance(idNasabah);
        }

        private string GetIDNasabah(string accountNumber)
        {
            try
            {
                dbManager.OpenConnection();

                string query = "SELECT id_nasabah FROM Nasabah WHERE norekening = @accountNumber";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@accountNumber", accountNumber);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["id_nasabah"].ToString();
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

        private string GetBalance(string idNasabah)
        {
            try
            {
                dbManager.OpenConnection();

                string query = "SELECT saldo FROM Nasabah WHERE id_nasabah = @idNasabah";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idNasabah", idNasabah);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["saldo"].ToString();
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

        private void fr_tariktunai_Load(object sender, EventArgs e)
        {

        }

        private void btnTarik_Click(object sender, EventArgs e)
        {
            
        }

        private bool NumericOnly(KeyPressEventArgs e)
        {
            var strValid = "0123456789";
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                // inputan selain angka
                if (strValid.IndexOf(e.KeyChar) < 0)
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }
      

        private void btnKembali_Click(object sender, EventArgs e)
        {
            
        }

        private void txtNominal_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNominal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnKembali_Click_1(object sender, EventArgs e)
        {
            this.Close();


            fr_menuutama menu = (fr_menuutama)Application.OpenForms["fr_menuutama"];

            if (menu != null)
            {
                menu.Show();
            }
            else
            {
                fr_menuutama newMenu = new fr_menuutama();
                newMenu.Show();
            }
        }

        private void btnLanjut_Click(object sender, EventArgs e)
        {
            decimal nominalTarik = string.IsNullOrEmpty(txtNominal.Text) ? 0 : Convert.ToDecimal(txtNominal.Text);

            if (string.IsNullOrEmpty(txtNominal.Text))
            {
                MessageBox.Show("Masukan Nominal terlebih dahulu", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txtNominal.Focus();
                return;
            }


            if (int.TryParse(lbl_id.Text, out int id_nasabah))
            {
                fr_pinTarik pinTarik = new fr_pinTarik();

                pinTarik.SetTransferData(new Transfer
                {
                    TanggalWaktuTransfer = DateTime.Now,
                    NominalTarik = nominalTarik,
                    IdNasabah = id_nasabah,


                });
                this.Hide();
                pinTarik.ShowDialog();



            }
            else
            {
                // Handle the case where lbl_id.Text cannot be converted to an integer
                MessageBox.Show("Invalid ID format. Please enter a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
