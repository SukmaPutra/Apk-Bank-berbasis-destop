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
    public partial class fr_transfer : Form
    {
        private SQLiteConnection connection;
        private DatabaseManager dbManager;

        public void SetIdNasabah(string idNasabah)
        {
            lbl_id.Text = idNasabah;
        }

        public fr_transfer()
        {
            InitializeComponent();
            dbManager = DatabaseManager.GetInstance();
            connection = dbManager.GetConnection();
            this.Load += fr_transfer_Load;
            txt_biayaadmin.ReadOnly = true;
            txt_totaltransfer.ReadOnly = true;
        }

        private void fr_transfer_Load(object sender, EventArgs e)
        {
            btnKembali.Parent = pictureBox1;
            btnKembali.BackColor= Color.Transparent;



            comboBox_namaBank.Items.Clear(); // Menghapus item sebelum menambahkan yang baru
            foreach (var bankName in kodebank.Keys)
            {
                comboBox_namaBank.Items.Add(bankName);
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

        private void HitungTotalTransfer()
        {
            // Menghitung total transfer setelah memilih bank
            decimal nominalTransfer = string.IsNullOrEmpty(txt_nominaltransfer.Text) ? 0 : Convert.ToDecimal(txt_nominaltransfer.Text);
            decimal biayaAdmin = string.IsNullOrEmpty(txt_biayaadmin.Text) ? 0 : Convert.ToDecimal(txt_biayaadmin.Text);
            decimal totalTransfer = nominalTransfer + biayaAdmin;

            txt_totaltransfer.Text = totalTransfer.ToString();
        }

        private Dictionary<string, string> kodebank = new Dictionary<string, string>
        {
            {"Bank BCA", "014"},
            {"Bank BRI", "002"},
            {"Bank MANDIRI", "008"},
            {"Bank MUAMALAT", "147"},
            {"Bank SA", "016"}
            // Add more banks as needed
        };

        private Dictionary<string, decimal> BiayaAdmin = new Dictionary<string, decimal>
        {
            {"Bank BCA", 2500m},
            {"Bank BRI", 2500m},
            {"Bank MANDIRI", 6500m},
            {"Bank MUAMALAT", 7000m},
            {"Bank SA", 0m}

        };

        private void lbl_id_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_namaBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            string namabank = comboBox_namaBank.SelectedItem.ToString();

            // Check if the selected bank is in the dictionary
            if (kodebank.ContainsKey(namabank))
            {
                // If yes, set the corresponding bank code to the text box
                txt_RekeningTujuan.Text = kodebank[namabank] + " - ";

                if (BiayaAdmin.ContainsKey(namabank))
                {
                    decimal biayaAdmin = BiayaAdmin[namabank];
                    txt_biayaadmin.Text = biayaAdmin.ToString();

                    // Menghitung total transfer setelah memilih bank
                    HitungTotalTransfer();
                }
            }
            else
            {
                // If not, you can handle the case where the bank code is not found
                MessageBox.Show("Bank code not found for the selected bank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_RekeningTujuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_RekeningTujuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        

        private void txtNamaTujuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_nominaltransfer_TextChanged(object sender, EventArgs e)
        {
            HitungTotalTransfer();
        }

        private void txt_nominaltransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void txt_biayaadmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_totaltransfer_TextChanged(object sender, EventArgs e)
        {

        }

        private bool AlphabeticOnly(KeyPressEventArgs e)
        {
            var strValid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                // inputan selain alfabet
                if (strValid.IndexOf(e.KeyChar) < 0)
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        private void btnLanjut_Click(object sender, EventArgs e)
        {
            
        }

        

        private void txtNamaTujuan_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = AlphabeticOnly(e);
        }

        private void btnLanjut_Click_1(object sender, EventArgs e)
        {
            decimal nominalTransfer = string.IsNullOrEmpty(txt_nominaltransfer.Text) ? 0 : Convert.ToDecimal(txt_nominaltransfer.Text);
            decimal biayaAdmin = string.IsNullOrEmpty(txt_biayaadmin.Text) ? 0 : Convert.ToDecimal(txt_biayaadmin.Text);
            decimal totalTransfer = nominalTransfer + biayaAdmin;
            string nama_rekening_tujuan = txtNamaTujuan.Text;
            string no_rekening_tujuan = txt_RekeningTujuan.Text;
            string namabank_tujuan = comboBox_namaBank.SelectedItem?.ToString();
            string kodebank_tujuan = kodebank.ContainsKey(namabank_tujuan) ? kodebank[namabank_tujuan] : string.Empty;

            if (string.IsNullOrEmpty(txtNamaTujuan.Text))
            {
                MessageBox.Show("Nama Tujuan harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txtNamaTujuan.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txt_nominaltransfer.Text))
            {
                MessageBox.Show("Nominal harus diisi !!!", "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txt_nominaltransfer.Focus();
                return;
            }

            if (int.TryParse(lbl_id.Text, out int id_nasabah))
            {
                fr_pinTransfer pintransfer = new fr_pinTransfer();
                pintransfer.SetTransferData(new Transfer
                {
                    NamaRekeningTujuan = nama_rekening_tujuan,
                    NoRekeningTujuan = no_rekening_tujuan,
                    NamaBankTujuan = namabank_tujuan,
                    KodeBankTujuan = kodebank_tujuan,
                    TanggalWaktuTransfer = DateTime.Now,
                    NominalTransfer = nominalTransfer,
                    BiayaAdmin = biayaAdmin,
                    IdNasabah = id_nasabah,
                    Total = totalTransfer
                });
                this.Hide();
                pintransfer.ShowDialog();
            }
            else
            {
                // Handle the case where lbl_id.Text cannot be converted to an integer
                MessageBox.Show("Invalid ID format. Please enter a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
