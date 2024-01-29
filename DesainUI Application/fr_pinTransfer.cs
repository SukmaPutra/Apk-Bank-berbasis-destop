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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesainUI_Application
{
    public partial class fr_pinTransfer : Form
    {
        private SQLiteConnection connection;
        private DatabaseManager dbManager;
        private Transfer transferData;
        private decimal transferAmount = 0;

        public string Username { get; private set; }
        public string AccountNumber { get; private set; }

        public fr_pinTransfer()
        {
            InitializeComponent();
            dbManager = DatabaseManager.GetInstance();
            connection = dbManager.GetConnection();
        }

        public void SetTransferData(Transfer transferData)
        {
            this.transferData = transferData;
            // You can then update your labels or perform any other actions with the transfer data
            string[] accountInfo = transferData.NoRekeningTujuan.Split('-');
            string bankCode = accountInfo[0];
            string accountNumber = accountInfo[1];

            // Displaying the information separately
            lbl_bank.Text = transferData.NamaBankTujuan + " - " + bankCode;
            lblnamabank.Text = accountNumber + " a/n " + transferData.NamaRekeningTujuan;

            lbltgl.Text = transferData.TanggalWaktuTransfer.ToString();
            lblNominalTransfer.Text = "Rp. " + transferData.NominalTransfer.ToString(); // Correct assignment
            lbl_biayaadmin.Text = "Rp. " + transferData.BiayaAdmin.ToString(); // Correct assignment
            lbltotalnominal.Text = "Rp. " + transferData.Total.ToString(); // Correct assignment
            lbl_id.Text = "ID Nasabah : " + transferData.IdNasabah.ToString();
        }

        private void InsertTransferDataIntoDatabase()
        {
            try
            {
                dbManager.OpenConnection();
                // Use a parameterized query to prevent SQL injection
                string insertQuery = "INSERT INTO Transfer (id_nasabah, tanggalwaktu_transfer, no_rekening_tujuan, nama_rekening_tujuan, kodebank_tujuan, nominal_transfer, biaya_admin, total, namabank_tujuan) " +
                                     "VALUES (@IdNasabah, @TanggalWaktuTransfer, @NoRekeningTujuan, @NamaRekeningTujuan, @KodeBankTujuan, @NominalTransfer, @BiayaAdmin, @Total, @NamaBankTujuan)";

                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection))
                {

                    string[] accountInfo = transferData.NoRekeningTujuan.Split('-');
                    string accountNumber = accountInfo[1];
                    // Replace @ParameterX with actual parameter names from your database
                    cmd.Parameters.AddWithValue("@IdNasabah", transferData.IdNasabah);
                    cmd.Parameters.AddWithValue("@TanggalWaktuTransfer", transferData.TanggalWaktuTransfer.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@NoRekeningTujuan", accountNumber);
                    cmd.Parameters.AddWithValue("@NamaRekeningTujuan", transferData.NamaRekeningTujuan);
                    cmd.Parameters.AddWithValue("@KodeBankTujuan", transferData.KodeBankTujuan);
                    cmd.Parameters.AddWithValue("@NominalTransfer", transferData.NominalTransfer);
                    cmd.Parameters.AddWithValue("@BiayaAdmin", transferData.BiayaAdmin);
                    cmd.Parameters.AddWithValue("@Total", transferData.Total);
                    cmd.Parameters.AddWithValue("@NamaBankTujuan", transferData.NamaBankTujuan);

                    // Execute the query
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting data into the database: " + ex.Message);
            }
            finally
            {
                dbManager.CloseConnection();
            }
        }

        private bool VerifyPIN(string enteredPin)
        {
            try
            {
                dbManager.OpenConnection();

                // Verify both PIN and id_nasabah
                string query = "SELECT COUNT(*) FROM Nasabah WHERE pinATM = @pinATM AND id_nasabah = @idNasabah";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@pinATM", enteredPin);
                    cmd.Parameters.AddWithValue("@idNasabah", transferData.IdNasabah);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error verifying PIN: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                dbManager.CloseConnection();
            }
        }

        private bool GetAccountNumberFromDatabase(string pinATM, out string accountNumber)
        {
            try
            {
                dbManager.OpenConnection();

                // Query to get the account number based on PIN
                string query = "SELECT norekening FROM Nasabah WHERE pinATM = @pinATM";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@pinATM", pinATM);

                    // Execute the query
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        // If the result is not null, set the accountNumber and return true
                        accountNumber = result.ToString();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving account number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbManager.CloseConnection();
            }

            // If there's an error or no account number is found, set accountNumber to null and return false
            accountNumber = null;
            return false;
        }

        private bool UpdateSaldo(decimal transferAmount)
        {
            try
            {
                dbManager.OpenConnection();

                // Fetch id_nasabah associated with the logged-in user
                string queryIdNasabah = "SELECT id_nasabah FROM Nasabah WHERE pinATM = @pinATM";

                using (SQLiteCommand cmdIdNasabah = new SQLiteCommand(queryIdNasabah, connection))
                {
                    cmdIdNasabah.Parameters.AddWithValue("@pinATM", txt_pinTransfer.Text);
                    transferData.IdNasabah = Convert.ToInt32(cmdIdNasabah.ExecuteScalar());
                }

                transferAmount = transferData.Total;
                // Update saldo for the specific id_nasabah
                string updateSaldoQuery = "UPDATE Nasabah SET saldo = saldo - @transferAmount WHERE id_nasabah = @idNasabah";

                using (SQLiteCommand cmd = new SQLiteCommand(updateSaldoQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@transferAmount", transferAmount);
                    cmd.Parameters.AddWithValue("@idNasabah", transferData.IdNasabah);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Gagal melakukan pembaruan saldo.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating saldo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                dbManager.CloseConnection();
            }
        }

        private void CreateCatatanPengeluaran()
        {
            try
            {
                dbManager.OpenConnection();

                // Query untuk menambahkan catatan pengeluaranid_nasabah
                string insertQuery = "INSERT INTO Catatan_Pengeluaran (id_nasabah, tanggalwaktu_transfer, Total_pengeluaran, jenis_transaksi, biaya_admin, total) " +
                                     "VALUES (@IdNasabah, @TanggalWaktuTransfer, @TotalPengeluaran, @JenisTransaksi, @BiayaAdmin, @Total)";

                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection))
                {

                    cmd.Parameters.AddWithValue("@IdNasabah", transferData.IdNasabah);
                    cmd.Parameters.AddWithValue("@TanggalWaktuTransfer", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@JenisTransaksi", "Transfer");
                    cmd.Parameters.AddWithValue("@TotalPengeluaran", transferData.NominalTransfer);
                    cmd.Parameters.AddWithValue("@BiayaAdmin", transferData.BiayaAdmin);
                    cmd.Parameters.AddWithValue("@Total", transferData.Total);




                    // Jalankan kueri
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating Catatan_Pengeluaran: " + ex.Message);
            }
            finally
            {
                dbManager.CloseConnection();
            }
        }

        private void lbltgl_Click(object sender, EventArgs e)
        {

        }

        private void lbl_id_Click(object sender, EventArgs e)
        {

        }

        private void lbl_bank_Click(object sender, EventArgs e)
        {

        }

        private void lblnamabank_Click(object sender, EventArgs e)
        {

        }

        private void lbl_biayaadmin_Click(object sender, EventArgs e)
        {

        }

        private void lblNominalTransfer_Click(object sender, EventArgs e)
        {

        }

        private void lbltotalnominal_Click(object sender, EventArgs e)
        {

        }

        private void txt_pinTransfer_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKonfirmasi_Click(object sender, EventArgs e)
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
        private void txt_pinTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void btnKonfirmasi_Click_1(object sender, EventArgs e)
        {
            string enteredPin = txt_pinTransfer.Text;

            if (string.IsNullOrEmpty(txt_pinTransfer.Text))
            {
                MessageBox.Show("Masukan PIN terlebih dahulu", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txt_pinTransfer.Focus();
                return;
            }


            if (VerifyPIN(enteredPin))
            {
                // Use an out parameter to get the account number from the database
                if (GetAccountNumberFromDatabase(enteredPin, out string accountNumber))
                {
                    // Set the AccountNumber property
                    AccountNumber = accountNumber;

                    InsertTransferDataIntoDatabase();

                    if (UpdateSaldo(transferAmount))
                    {
                        MessageBox.Show($"Transfer berhasil.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fr_menuutama menu = (fr_menuutama)Application.OpenForms["Fr_menuutama"];
                        if (menu != null)
                        {
                            CreateCatatanPengeluaran();
                            menu.UpdateTotalPengeluaranLabel();
                            menu.SetAccountNumberLabel( AccountNumber, Username); //loggedInUsername 
                        }
                        CreateCatatanPengeluaran();

                        this.Close();
                        menu?.Show();
                    }
                    else
                    {
                        MessageBox.Show("Gagal melakukan pembaruan saldo.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Gagal mendapatkan nomor rekening.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("PIN salah. Transaksi gagal.");
            }
        }

      //  private string loggedInUsername;

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
            fr_tariktunai tariktunai = (fr_tariktunai)Application.OpenForms["fr_tariktunai"];

            if (tariktunai != null)
            {
                tariktunai.Show();
            }
            else
            {
                fr_tariktunai newtariktunai = new fr_tariktunai();
                newtariktunai.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
