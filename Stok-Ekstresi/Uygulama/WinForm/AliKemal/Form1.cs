using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliKemal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            grd_Liste.Visible = false;
        }

        private void btn_Getir_Click(object sender, EventArgs e)
        {
            Baglanti b = new Baglanti(); // Veritabanına bağlanmak için nesne oluşturuldu.
            //Sorgu için gerekli parametreler eklendi
            b.ParametreEkle("@MALKODU", txt_MalKodu.Text);
            b.ParametreEkle("@BASLANGIC_TARIHI", dt_Baslangic.Value); 
            b.ParametreEkle("@BITIS_TARIHI", dt_Bitis.Value);

            DataSet ds = b.SorguGetir("prosedur"); //Prosedürü çağırdık.

            // Gelen verileri tablomuza aktarmak için bir DataTable oluşturduk
            DataTable dt = new DataTable();
            dt.Columns.Add("Sıra No"); 
            dt.Columns.Add("İşlem Tür");
            dt.Columns.Add("Evrak No");
            dt.Columns.Add("Tarih");
            dt.Columns.Add("Giriş Miktar");
            dt.Columns.Add("Çıkış Miktar");
            dt.Columns.Add("Stok");

            decimal toplam = 0;

            foreach (DataRow dr in ds.Tables[0].Rows)   //DataSet'in satırları arasında dolaşıyoruz
            {
                // DataTable'dan bir DataRow oluşturduk.
                DataRow dk = dt.NewRow();
                dk["Sıra No"] = dr["SiraNo"].ToString();
                dk["İşlem Tür"] = dr["IslemTur"].ToString();
                dk["Evrak No"] = dr["EvrakNo"].ToString();
                dk["Tarih"] = dr["Tarih"].ToString();
                dk["Giriş Miktar"] = dr["GirisMiktar"].ToString();
                dk["Çıkış Miktar"] = dr["CikisMiktar"].ToString();

                // Stok Formülü
                toplam = toplam + Convert.ToDecimal(dr["GirisMiktar"].ToString()) - Convert.ToDecimal(dr["CikisMiktar"].ToString());
                dk["Stok"] = Decimal.Round(toplam,0); // tam sayı haline getirdik.
                
                dt.Rows.Add(dk); //Satırı tablomuza ekliyoruz.
            }

            // Tablomuzu DataGridView'e aktardık.
            grd_Liste.AutoGenerateColumns = true;
            grd_Liste.DataSource = dt;
            grd_Liste.Visible = true;
        }

        
    }
}
