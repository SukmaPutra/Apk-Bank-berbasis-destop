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
    public partial class fr_catatanKeuangan : Form
    {
        private DatabaseManager dbManager;
        private SQLiteConnection connection;
        

        public fr_catatanKeuangan(int idNasabah)
        {
            InitializeComponent();
            InisialisasiListView();
            dbManager = DatabaseManager.GetInstance();
            connection = dbManager.GetConnection();           
            LoadCatatanPengeluaran(idNasabah);
            
        }


        
        private void InisialisasiListView()
        {
            lvwPengeluaran1.View = View.Details;
            lvwPengeluaran1.FullRowSelect = true;
            lvwPengeluaran1.GridLines = true;
            lvwPengeluaran1.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwPengeluaran1.Columns.Add("Tanggal Transaksi", 170, HorizontalAlignment.Left);
            lvwPengeluaran1.Columns.Add("Jenis Transaksi", 170, HorizontalAlignment.Center);
            lvwPengeluaran1.Columns.Add("Nominal", 130, HorizontalAlignment.Center);
            lvwPengeluaran1.Columns.Add("Biaya Admin", 170, HorizontalAlignment.Center);
            lvwPengeluaran1.Columns.Add("Total", 170, HorizontalAlignment.Center);

        }

        private void LoadCatatanPengeluaran(int idNasabah)
        {
            try
            {
                dbManager.OpenConnection();

                string query = "SELECT id_catatan_pengeluaran, tanggalwaktu_transfer, jenis_transaksi, Total_pengeluaran, biaya_admin, total FROM Catatan_Pengeluaran WHERE id_nasabah = @IdNasabah ORDER BY tanggalwaktu_transfer DESC";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IdNasabah", idNasabah);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        int index = 0;
                        while (reader.Read())
                        {
                            index++;
                            ListViewItem item = new ListViewItem(index.ToString());

                            item.SubItems.Add(reader["tanggalwaktu_transfer"].ToString());
                            item.SubItems.Add(reader["jenis_transaksi"].ToString());
                            item.SubItems.Add(reader["Total_pengeluaran"].ToString());
                            string biayaAdmin = reader["biaya_admin"].ToString();
                            item.SubItems.Add(biayaAdmin == "0" ? "-" : biayaAdmin);

                            item.SubItems.Add(reader["total"].ToString());

                            lvwPengeluaran1.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Catatan Pengeluaran: " + ex.Message);
            }
            finally
            {
                dbManager.CloseConnection();
            }
        }



        private void fr_catatanKeuangan_Load(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
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

        private void lvwPengeluaran1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
