using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Yonetim_Urunler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CbxUrunDoldur();
            LbxKategoriDoldur();
            Panel1.Visible = false;
            Panel2.Visible = false;
        }
        if (Request.QueryString["Sil"]!=null)
        {
            ResimSil(Request.QueryString["Sil"].ToString(), Request.QueryString["BResim"].ToString(), Request.QueryString["KResim"].ToString());
        }
    }
    void CbxUrunDoldur()
    {
        AKBclass.DBMudahale.ComboBoxDoldur(ref CbxUrunler, "SELECT ID,Ad FROM Urun_Tbl ORDER BY Ad", "--Ürün Seçiniz--", "Ad");
    }
    void LbxKategoriDoldur()
    {
        AKBclass.DBMudahale.ListBoxDoldur(ref LbxKategori, "SELECT ID,Ad FROM Urun_Tbl ORDER BY Ad", "Ad");
    }
    void ResimGuncellemeAc()
    {
        Panel2.Visible = true;
        LblAd.Text = AKBclass.DBMudahale.TekDegerDondur("SELECT Ad FROM Urun_Tbl WHERE ID = " + HfID.Value);

    
    }
    protected void BtnResimYukle_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile && FileUpload2.HasFile)
        {

            string BResim = AKBclass.DigerIslemler.Benzersiz() + Path.GetExtension(FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath("../Foto/UrunResim/") + BResim);
            string KResim = AKBclass.DigerIslemler.Benzersiz() + Path.GetExtension(FileUpload2.FileName);
            FileUpload2.SaveAs(Server.MapPath("../Foto/UrunResim/") + KResim);

            SqlParameter[] pCollection = new SqlParameter[]
             {
                  /*0*/new SqlParameter("@ID",SqlDbType.Int),
                  /*1*/new SqlParameter("@UrunID",SqlDbType.Int),
                  /*2*/new SqlParameter("@BResim",SqlDbType.NVarChar, 50),
                  /*3*/new SqlParameter("@KResim",SqlDbType.NVarChar, 50),
             };

            foreach (SqlParameter item in pCollection)
            {
                item.Value = DBNull.Value;
            }

            
            /*ID*/
            pCollection[0].Value = DBNull.Value;
            /*UrunID*/
            pCollection[1].Value = int.Parse(HfID.Value);
            /*BResim*/
            pCollection[2].Value = BResim;
            /*KResim*/
            pCollection[3].Value = KResim;

            AKBclass.DBMudahale.SQLIsle("  INSERT INTO UrunResim_Tbl(UrunID,BResim,KResim) VALUES (@UrunID,@BResim,@KResim)", pCollection);

            AKBclass.DigerIslemler.MesajVerNew("Resim kaydedildi");

            DataList1.DataBind();
        
        }
        else
            AKBclass.DigerIslemler.MesajVerNew("Resim seçiniz.");
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {

        SqlParameter[] pCollection = new SqlParameter[]
         {
              /*0*/new SqlParameter("@ID",SqlDbType.Int),
              /*1*/new SqlParameter("@Ad",SqlDbType.NVarChar, 250),
              /*2*/new SqlParameter("@Aciklama",SqlDbType.Text),
              /*3*/new SqlParameter("@Etiket",SqlDbType.NVarChar, 50),
              /*4*/new SqlParameter("@Spot",SqlDbType.Text),
         };

        foreach (SqlParameter item in pCollection)
        {
            item.Value = DBNull.Value;
        }


        if (BtnKaydet.Text == "Kaydet")
        { // ürün kaydet 


            
            /*Ad*/
            pCollection[1].Value = TxtAd.Text;
            /*Aciklama*/
            pCollection[2].Value = TxtAciklama.Text;
            /*Etiket*/
            pCollection[3].Value = TxtEtiket.Text ;
            /*Spot*/
            pCollection[4].Value = TxtSpot.Text;

          string ID =   AKBclass.DBMudahale.TekDegerDondur("INSERT INTO Urun_Tbl(Ad,Aciklama,Etiket,Spot) VALUES (@Ad,@Aciklama,@Etiket,@Spot)   SELECT @@IDENTITY AS ID  ", pCollection);

          if (ID == "-1")
          {
              AKBclass.DigerIslemler.MesajVerNew("Ürün Ekleme işleminde Hata Oluştu");
              return;
          }
          else
          {
              pCollection = new SqlParameter[]
              {
                 
                  /*0*/new SqlParameter("@UrunID",SqlDbType.Int),
                  /*1*/new SqlParameter("@KategoriID",SqlDbType.Int),
              };

              foreach (SqlParameter item in pCollection)
              {
                  item.Value = DBNull.Value;
              }

              /*UrunID*/
              pCollection[1].Value = int.Parse(ID);
              
              foreach (ListItem item in LbxKategori.Items)
              {
                  if (item.Selected)
                  {
                      
                      /*KategoriID*/
                      pCollection[2].Value = int.Parse(item.Value);

                      AKBclass.DBMudahale.SQLIsle("INSERT INTO UrunKategori_Tbl(UrunID,KategoriID) VALUES (@UrunID,@KategoriID)", pCollection);

                  }
              }
          
          }

          AKBclass.DigerIslemler.MesajVerNew("Ürün Eklendi.");
          CbxUrunDoldur();

          Panel1.Visible = false;
          Panel2.Visible = false;

        }
        else
        { // ürün güncelle 

            /*ID*/
            pCollection[0].Value = int.Parse(HfID.Value);
            /*Ad*/
            pCollection[1].Value = TxtAd.Text;
            /*Aciklama*/
            pCollection[2].Value = TxtAciklama.Text;
            /*Etiket*/
            pCollection[3].Value = TxtEtiket.Text;
            /*Spot*/
            pCollection[4].Value = TxtSpot.Text;


            if ("-1" == AKBclass.DBMudahale.SQLIsle("UPDATE Urun_Tbl SET Ad = @Ad,Aciklama = @Aciklama,Etiket = @Etiket,Spot = @Spot WHERE ID = @ID", pCollection))
            {
                AKBclass.DigerIslemler.MesajVerNew("Ürün Güncelleme işleminde Hata Oluştu.");
                return;
            }
            else
            {

                pCollection = new SqlParameter[]
                {
                 
                  /*0*/new SqlParameter("@UrunID",SqlDbType.Int),
                  /*1*/new SqlParameter("@KategoriID",SqlDbType.Int),
                };

                foreach (SqlParameter item in pCollection)
                {
                    item.Value = DBNull.Value;
                }

                /*UrunID*/
                pCollection[1].Value = int.Parse(ID);

                AKBclass.DBMudahale.SQLIsle("DELETE FROM UrunKategori_Tbl WHERE UrunID = @UrunID", pCollection);
               
                foreach (ListItem item in LbxKategori.Items)
                {
                    if (item.Selected)
                    {
                      
                        /*KategoriID*/
                        pCollection[2].Value = int.Parse(item.Value);

                        AKBclass.DBMudahale.SQLIsle("INSERT INTO UrunKategori_Tbl(UrunID,KategoriID) VALUES (@UrunID,@KategoriID)", pCollection);

                    }
                }


            }

            AKBclass.DigerIslemler.MesajVerNew("Ürün Güncellendi.");
            CbxUrunDoldur();

            Panel1.Visible = false;
            Panel2.Visible = false;

        }



    }
    protected void BtnUrunIptal_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;

    }
    protected void BtnResim_Click(object sender, EventArgs e)
    {
        if (CbxUrunler.SelectedIndex != -1)
        {
            HfID.Value = CbxUrunler.SelectedItem.Value;
            ResimGuncellemeAc();
        }
        else
            AKBclass.DigerIslemler.MesajVerNew("Ürün Seçiniz");
        

    }
    protected void BtnSil_Click(object sender, EventArgs e)
    {
        if (CbxUrunler.SelectedIndex != -1)
        {
            if ("-1" == AKBclass.DBMudahale.SQLIsle("DELETE FROM Urun_Tbl WHERE ID = " + CbxUrunler.SelectedItem.Value))
            {
                AKBclass.DigerIslemler.MesajVerNew("Ürün Silme işleminde Hata Oluştu. ");
            }
            else
                AKBclass.DigerIslemler.MesajVerNew("Ürün Silindi.");
        }
        else
            AKBclass.DigerIslemler.MesajVerNew("Ürün Seçiniz");
    }
    protected void BtnGuncelle_Click(object sender, EventArgs e)
    {
        if (CbxUrunler.SelectedIndex != -1)
            UrunDoldur(CbxUrunler.SelectedItem.Value);
        else
            AKBclass.DigerIslemler.MesajVerNew("Ürün Seçiniz");
    }
    protected void BtnYeniUrun_Click(object sender, EventArgs e)
    {
        UrunDoldur("");
    }
    void UrunDoldur(string ID)
    {
       
        if (string.IsNullOrEmpty(ID))
        { // yeni Urun
            BtnKaydet.Text = "Kaydet";
            TxtAd.Text = "";
            TxtEtiket.Text = "";
            TxtAciklama.Text = "";
            LbxKategori.SelectedIndex = -1;
            TxtSpot.Text = "";

            HfID.Value = "";

            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        else
        { // ürün güncelle

            BtnKaydet.Text = "Güncelle";

            Hashtable ht = AKBclass.DBMudahale.TekKayitDondurHT("Urun_Tbl", "Ad,Aciklama,Etiket,Spot", "WHERE ID = " + ID);

            TxtAd.Text = ht["Ad"].ToString();
            TxtAciklama.Text = ht["Aciklama"].ToString();
            TxtEtiket.Text = ht["Etiket"].ToString();
            TxtSpot.Text = ht["Spot"].ToString();

            TxtAd.Text = TxtAd.Text == "-1" ? "" : TxtAd.Text;
            TxtAciklama.Text = TxtAciklama.Text == "-1" ? "" : TxtAciklama.Text;
            TxtEtiket.Text = TxtEtiket.Text == "-1" ? "" : TxtEtiket.Text;
            TxtSpot.Text = TxtSpot.Text == "-1" ? "" : TxtSpot.Text;

            HfID.Value = ID;

            LbxKategori.SelectedIndex = -1;

            DataTable dt = AKBclass.DBMudahale.TabloDoldur("SELECT ID FROM UrunKategori_Tbl WHERE UrunID = " + ID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                foreach (ListItem item in LbxKategori.Items)
                {
                    if (item.Value == dt.Rows[i]["ID"].ToString())
                        item.Selected = true;
                }
            }

            Panel1.Visible = true;
            Panel2.Visible = false;

            DataList1.DataBind();

        }

    }
    void ResimSil(string ResimID, string BResim,string KResim)
    {
        if ("-1" == AKBclass.DBMudahale.SQLIsle("DELETE FROM UrunResim_Tbl WHERE ID = " + ResimID))
        {
            AKBclass.DigerIslemler.MesajVerNew("Resim Silinirken Hata Oluştu!");
            return;
        }
        else
        {
            File.Delete(Server.MapPath("~/Foto/UrunResim/") + BResim);
            File.Delete(Server.MapPath("~/Foto/UrunResim/") + KResim);
            AKBclass.DigerIslemler.MesajVerNew("Resim Silindi.");
        }
    }


 
}