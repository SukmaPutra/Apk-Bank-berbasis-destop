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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesainUI_Application
{
    public partial class fr_login : Form
    {
        public string AccountNumber { get; private set; }
        public string Username { get; private set; }
        private SQLiteConnection connection;
        private DatabaseManager dbManager;
        /*private string dbName = @"D:\PUTRA\KULIAH\Semester 3\Pemmrog\LASTTYOKK\final\DBbank.db";*/



        public fr_login()
        {
            InitializeComponent();
            /*sqliteConnection = new SQLiteConnection($"Data Source={dbName};Version=3;");*/
            dbManager = DatabaseManager.GetInstance();
            connection = dbManager.GetConnection();
        }

        

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Btnclose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("are you sure want to exit?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Menutup aplikasi jika pengguna mengonfirmasi logout
                this.Close();
            };
        }

        private bool Login(string username, string password)
        {
            try
            {
                dbManager.OpenConnection();
                string query = "SELECT norekening FROM Nasabah WHERE username = @username AND password = @password";


                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);


                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            AccountNumber = dataTable.Rows[0]["norekening"].ToString();
                            Username = username;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        /* return dataTable.Rows.Count > 0;*/
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            finally
            {
                dbManager.CloseConnection();
            }
        }




        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txt_Username.Text;
            string password = txt_Password.Text;

            if (Login(username, password))
            {
                MessageBox.Show("Login berhasil!");


                this.Hide();
                fr_menuutama fr_Menuutama = new fr_menuutama();
                fr_Menuutama.SetAccountNumberLabel(AccountNumber, username);
                fr_Menuutama.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username atau password salah. Silakan coba lagi.");
            }




        }

        private string GenerateRandomAccountNumber()
        {
            Random random = new Random();
            int accountNumber = random.Next(100000000, 999999999); // Generate a random 9-digit number

            return accountNumber.ToString();
        }

        private void CheckBox_Password_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_Password.Checked == true)
            {
                txt_Password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_Password.UseSystemPasswordChar = true;
            }
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void txt_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void fr_login_Load(object sender, EventArgs e)
        {

        }

        private void linklbl_daftar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Fr_Daftar formDaftar = new Fr_Daftar();
            formDaftar.ShowDialog();
            this.Close();
        }
    }
}
