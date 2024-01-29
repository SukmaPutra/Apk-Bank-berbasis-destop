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
    public partial class fr_menuutama : Form
    {
        public void SetAccountNumberLabel(string accountNumber, string username)
        {
            lblnorekening.Text = accountNumber;
            string idNasabah = GetIDNasabah(accountNumber);
            lbl_idnasabah.Text = idNasabah;
            lblsaldo.Text = GetBalance(idNasabah);
            lbl_username.Text = username;

        }


        
        private SQLiteConnection connection;
        private DatabaseManager dbManager;
        /*private Transfer transferData;*/


        public fr_menuutama()
        {
            InitializeComponent();
            dbManager = DatabaseManager.GetInstance();
            connection = dbManager.GetConnection(); 
        }

        /*private string GetUsername(string idNasabah)
        {
            try
            {
                dbManager.OpenConnection();

                string query = "SELECT username FROM Nasabah WHERE id_nasabah = @idNasabah";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idNasabah", idNasabah);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["username"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
            finally
            {
                dbManager.CloseConnection();
            }

            return null;
        }*/
     
        // Modify the UpdateTotalPengeluaranLabel method
        public void UpdateTotalPengeluaranLabel()
{
            string idNasabah = lbl_idnasabah.Text;

            try
            {
                dbManager.OpenConnection();

                string query = "SELECT SUM(total) AS TotalPengeluaran FROM Catatan_Pengeluaran WHERE id_nasabah = @IdNasabah";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IdNasabah", idNasabah);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        decimal totalPengeluaran = Convert.ToDecimal(result);
                        label9.Text = "- " + totalPengeluaran.ToString("C");
                    }
                    else
                    {
                        label9.Text = "- Rp 0"; // or any default value
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Total Pengeluaran: " + ex.Message);
            }
            finally
            {
                dbManager.CloseConnection();
            }
        }



        private int currentIdNasabah;
        public void SetIdNasabah(int idNasabah)
        {
            currentIdNasabah = idNasabah;
            // Lakukan apa pun yang diperlukan dengan ID nasabah yang diterima di sini
            // Misalnya, simpan nilai ke properti kelas untuk digunakan dalam operasi lain
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
            finally
            {
                dbManager.CloseConnection();
            }
            return null;
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr_transfer transfer = new fr_transfer();
            transfer.ShowDialog();
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
            finally
            {
                dbManager.CloseConnection();
            }
            return null;
        }

        private string GenerateRandomAccountNumber()
        {
            Random random = new Random();
            int accountNumber = random.Next(100000000, 999999999); // Generate a random 9-digit number

            return accountNumber.ToString();
        }

        private void pictureBox_transfer_Click(object sender, EventArgs e)
        {
            this.Hide();
            fr_transfer transfer = new fr_transfer();
            transfer.SetIdNasabah(lbl_idnasabah.Text); // Pass the id_nasabah value
            transfer.ShowDialog();
        }

        private void pictureBox_Tarik_Click(object sender, EventArgs e)
        {
            fr_tariktunai tarik = new fr_tariktunai();
            tarik.SetIdNasabah(lbl_idnasabah.Text);
            tarik.SetBalanceLabel(lblsaldo.Text);
            tarik.SetAccountNumberLabel(lblnorekening.Text);
            this.Hide();
            tarik.ShowDialog(); ;

        }
        private void pictureBox_CK_Click(object sender, EventArgs e)
        {
            if (int.TryParse(lbl_idnasabah.Text, out int idNasabah))
            {
                // Pass the idNasabah value to Fr_CatatanPengeluaran constructor
                fr_catatanKeuangan catatanKeuangan = new fr_catatanKeuangan(idNasabah);
                this.Hide();
                catatanKeuangan.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid account ID");
            }

        }

        private void lbl_idnasabah_Click(object sender, EventArgs e)
        {

        }

        private void lblnorekening_Click(object sender, EventArgs e)
        {

        }

        private void lblsaldo_Click(object sender, EventArgs e)
        {

        }
        private void LoadNasabahData()
        {
            string query = "SELECT * FROM Nasabah";
            DataTable dataTable = DatabaseManager.GetInstance().ExecuteQuery(query);

            // Now use the dataTable to update your UI or perform any other necessary actions
            // dataGridView1.DataSource = dataTable; // Example for a DataGridView
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("are you sure want to exit?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                // Menutup aplikasi jika pengguna mengonfirmasi logout
                fr_login fr_Login = new fr_login();
                fr_Login.ShowDialog();
                this.Close();

            }
        }

       
        public void UpdateSaldoLabel(decimal newSaldo)
        {
            lblsaldo.Text = newSaldo.ToString();
        }
        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {

        }

        private void fr_menuutama_Load(object sender, EventArgs e)
        {
            UpdateTotalPengeluaranLabel();
            //decimal nominalTarik = transferData.NominalTarik;*/
            LoadNasabahData();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            infoakun akun = new infoakun();
            akun.SetIdNasabah(lbl_idnasabah.Text);
            akun.SetAccountNumberLabel(lblnorekening.Text);
            akun.ShowDialog();
            
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            about about = new about();
            about.ShowDialog();

        }
    }
}
