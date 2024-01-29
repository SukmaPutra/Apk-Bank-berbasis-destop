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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DesainUI_Application
{
    public partial class fr_pinTarik : Form
    {
        private SQLiteConnection connection;
        private DatabaseManager dbManager;
        public string AccountNumber { get; private set; }
        public string Username { get; private set; }
        private Transfer transferData;
       // private decimal transferAmount = 0;


        public fr_pinTarik()
        {
            InitializeComponent();
            dbManager = DatabaseManager.GetInstance();
            connection = dbManager.GetConnection();

        }

        public void SetTransferData(Transfer transferData)
        {
            this.transferData = transferData;
            lbltgl.Text = transferData.TanggalWaktuTransfer.ToString();
            lblNominalTarik.Text = "Rp. " + transferData.NominalTarik.ToString(); // Correct assignment
            lbl_id.Text = "ID Nasabah : " + transferData.IdNasabah.ToString();

        }



        private void fr_pinTarik_Load(object sender, EventArgs e)
        {

        }

        private void btnKonfirmasi2_Click(object sender, EventArgs e)
        {
           
        }

        private void InsertTransferDataIntoDatabase()
        {
            try
            {
                dbManager.OpenConnection();

                string insertQuery = "INSERT INTO Tarik_Tunai (id_nasabah, tanggalwaktu_transfer, nominal_tarik ) " +
                                     "VALUES (@IdNasabah, @TanggalWaktuTransfer, @NominalTarik )";

                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection))
                {

                    cmd.Parameters.AddWithValue("@IdNasabah", transferData.IdNasabah);
                    cmd.Parameters.AddWithValue("@TanggalWaktuTransfer", transferData.TanggalWaktuTransfer.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@NominalTarik", transferData.NominalTarik);
                    


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

        private bool IsNumeric(string input)
        {
            return decimal.TryParse(input, out _);
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
                dbManager.CloseConnection() ;
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
                int idNasabah = transferData.IdNasabah; //KARO NAMBAHI IKI

                string queryIdNasabah = "SELECT id_nasabah FROM Nasabah WHERE pinATM = @pinATM";

                using (SQLiteCommand cmdIdNasabah = new SQLiteCommand(queryIdNasabah, connection))
                {
                    cmdIdNasabah.Parameters.AddWithValue("@pinATM", txt_pinTarik.Text);
                   // int retrievedIdNasabah = Convert.ToInt32(cmdIdNasabah.ExecuteScalar()); // IKI DIPATENI NING NK ORA RAPOPO

                    // Update saldo for the specific id_nasabah
                    string updateSaldoQuery = "UPDATE Nasabah SET saldo = saldo - @nominal WHERE id_nasabah = @idNasabah";

                    using (SQLiteCommand cmd = new SQLiteCommand(updateSaldoQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@nominal", transferData.NominalTarik); // Gunakan NominalTarik dari transferData
                        cmd.Parameters.AddWithValue("@idNasabah", transferData.IdNasabah); //IKI SEK DIGANTI

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

        

        private void txt_pinTarik_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void btnKonfirmasi_Click(object sender, EventArgs e)
        {
            string enteredPin = txt_pinTarik.Text;

            if (string.IsNullOrEmpty(txt_pinTarik.Text))
            {
                MessageBox.Show("Masukan PIN terlebih dahulu", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txt_pinTarik.Focus();
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

                    decimal nominal = transferData.NominalTarik;
                    if (UpdateSaldo(nominal)) // Menggunakan nominal sebagai parameter untuk UpdateSaldo
                    {
                        // Jika pembaruan berhasil, tampilkan pesan sukses dan perbarui label saldo

                        MessageBox.Show($"Penarikan tunai sejumlah {nominal} berhasil.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fr_menuutama menu = (fr_menuutama)Application.OpenForms["Fr_menuutama"];
                        if (menu != null)
                        {
                            CreateCatatanPengeluaran();
                            menu.UpdateSaldoLabel(nominal);
                            menu.SetAccountNumberLabel(AccountNumber, Username);
                            menu.UpdateTotalPengeluaranLabel();
                        }
                        
                        this.Close();
                        menu.Show();

                        
                        
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

        // Inside fr_tariktunai form

        // Assuming this method is called after a successful withdrawal operation
       


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
                    cmd.Parameters.AddWithValue("@TotalPengeluaran", transferData.NominalTarik);
                    cmd.Parameters.AddWithValue("@JenisTransaksi", "Tarik Tunai");
                    if (transferData.BiayaAdmin == 0)
                        cmd.Parameters.AddWithValue("@BiayaAdmin", "-");
                    else
                        cmd.Parameters.AddWithValue("@BiayaAdmin", transferData.BiayaAdmin);
                    cmd.Parameters.AddWithValue("@Total", transferData.NominalTarik);




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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
