using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Yonetim_Kategori : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            MenuDoldur();

        
    }
    DataTable dt;
    void MenuDoldur()
    {

        TreeView1.Nodes.Clear();
        dt = AKBclass.DBMudahale.TabloDoldur("SELECT ID,Ad,UstKategoriID,Resim FROM Kategori_Tbl");

        TreeNode AnaNode;

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["UstKategoriID"].ToString() == "0")
            {

                if (!string.IsNullOrEmpty(dt.Rows[i]["Resim"].ToString()))
                AnaNode = new TreeNode(dt.Rows[i]["Ad"].ToString(), dt.Rows[i]["ID"].ToString(), "~/Foto/KategoriResim/" + dt.Rows[i]["Resim"].ToString());
                else
                    AnaNode = new TreeNode(dt.Rows[i]["Ad"].ToString(), dt.Rows[i]["ID"].ToString());
                

             

                MenuDalDoldur(ref AnaNode);
                TreeView1.Nodes.Add(AnaNode);


                AnaNode = null;
            }
        }
    }
    void MenuDalDoldur(ref TreeNode AnaNode)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["UstKategoriID"].ToString() == AnaNode.Value.ToString())
            {
               

                TreeNode YavruNode;

                if (!string.IsNullOrEmpty(dt.Rows[i]["Resim"].ToString()))
                    YavruNode = new TreeNode(dt.Rows[i]["Ad"].ToString(), dt.Rows[i]["ID"].ToString(), "~/Foto/KategoriResim/" + dt.Rows[i]["Resim"].ToString());
                else
                    YavruNode = new TreeNode(dt.Rows[i]["Ad"].ToString(), dt.Rows[i]["ID"].ToString());





                MenuDalDoldur(ref YavruNode);
                AnaNode.ChildNodes.Add(YavruNode);
            }
        }
    }
  
    void KategoriAc(bool Ekleme)
    {
        if (Ekleme)
        {// ekleme
            if (HfID.Value == "0")
            { // ana kategori


                LblKategoriAd.Text = "Yok. (Ana Kategori)";
                
            }
            else
            { // yavru Kategori
                LblKategoriAd.Text = TreeView1.SelectedNode.Text;

            }

            TxtKategoriAd.Text = "";
            CbxResim.Checked = true;
            TxtEtiket.Text = "";
            Image1.ImageUrl = "";
            BtnKaydet.Text = "Kaydet";
        }
        else
        {// güncelleme 

            LblKategoriAd.Text = AKBclass.DBMudahale.TekDegerDondur("SELECT Ad FROM Kategori_Tbl WHERE ID = (SELECT UstKategoriID FROM Kategori_Tbl WHERE ID = " + HfID.Value +")");

            LblKategoriAd.Text = LblKategoriAd.Text == "" ? "Yok. (Ana Kategori)" : LblKategoriAd.Text;

            TxtKategoriAd.Text = TreeView1.SelectedNode.Text;
            TxtEtiket.Text = AKBclass.DBMudahale.TekDegerDondur("SELECT Etiket FROM Kategori_Tbl WHERE ID = " + HfID.Value);
            Image1.ImageUrl = "~/Foto/KategoriResim/" + AKBclass.DBMudahale.TekDegerDondur("SELECT Resim FROM Kategori_Tbl WHERE ID = " + HfID.Value);

            LblKategoriAd.Text = LblKategoriAd.Text == "-1" ? "" : LblKategoriAd.Text;

            LblKategoriAd.Text = LblKategoriAd.Text == "" ? "Yok. (Ana Kategori)" : LblKategoriAd.Text;

            TxtKategoriAd.Text = TxtKategoriAd.Text == "-1" ? "" : TxtKategoriAd.Text;

            TxtEtiket.Text = TxtEtiket.Text == "-1" ? "" : TxtEtiket.Text;

            BtnKaydet.Text = "Güncelle";

        }
        Panel1.Visible = true;
    }


    protected void BtnAnaEkle_Click(object sender, EventArgs e)
    {
        HfID.Value = "0";
        KategoriAc(true);
    }
    protected void BtnIptal_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        SqlParameter[] pCollection = new SqlParameter[]
         {
              /*0*/new SqlParameter("@ID",SqlDbType.Int),
              /*1*/new SqlParameter("@Ad",SqlDbType.NVarChar, 100),
              /*2*/new SqlParameter("@UstKategoriID",SqlDbType.Int),
              /*3*/new SqlParameter("@Resim",SqlDbType.NVarChar, 50),
              /*4*/new SqlParameter("@Etiket",SqlDbType.NVarChar, 50),
         };

        foreach (SqlParameter item in pCollection)
        {
            item.Value = DBNull.Value;
        }     

        if (BtnKaydet.Text == "Kaydet")
        { // yeni Kayıt 

          
            /*Ad*/
            pCollection[1].Value = TxtKategoriAd.Text;
            /*UstKategoriID*/
            pCollection[2].Value = HfID.Value;
            if (!CbxResim.Checked)
            {
                if (FileUpload1.HasFile)
                {
                    string ResimAd = AKBclass.DigerIslemler.Benzersiz() + Path.GetExtension(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/Foto/KategoriResim/") + ResimAd);
                    /*Resim*/
                    pCollection[3].Value = ResimAd;
                }
                else
                {
                    AKBclass.DigerIslemler.MesajVerNew("Resim Seçiniz");
                    return;
                }
            }
            else
            {
                /*Resim*/
                pCollection[3].Value = DBNull.Value;
            }

                /*Etiket*/
            pCollection[4].Value = TxtEtiket.Text;

            if ("-1" == AKBclass.DBMudahale.SQLIsle("INSERT INTO Kategori_Tbl(Ad,UstKategoriID,Resim,Etiket) VALUES (@Ad,@UstKategoriID,@Resim,@Etiket)", pCollection))
                AKBclass.DigerIslemler.MesajVerNew("Kategori ekleme işleminde hata oluştu");
            else
            {
                AKBclass.DigerIslemler.MesajVerNew("Kategori Eklendi");
                Panel1.Visible = false;
            }
        }
        else
        { // güncelle 

            /*Resim*/
            pCollection[3].Value = AKBclass.DBMudahale.TekDegerDondur("SELECT Resim FROM Kategori_Tbl WHERE ID = " + HfID.Value);

            pCollection[3].Value = pCollection[3].Value.ToString() == "-1" ? DBNull.Value : pCollection[3].Value;

            /*ID*/
            pCollection[0].Value = int.Parse(HfID.Value);
            /*Ad*/
            pCollection[1].Value = TxtKategoriAd.Text;

            if (!CbxResim.Checked)
            {
                if (FileUpload1.HasFile)
                {
                    string ResimAd = AKBclass.DigerIslemler.Benzersiz() + Path.GetExtension(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/Foto/KategoriResim/") + ResimAd);
                    /*Resim*/
                    pCollection[3].Value = ResimAd;
                }
               
            }
            else
            {
                /*Resim*/
                pCollection[3].Value = DBNull.Value;
            }


            /*Etiket*/
            pCollection[4].Value = TxtEtiket.Text;

            if ("-1" == AKBclass.DBMudahale.SQLIsle("UPDATE Kategori_Tbl SET Ad = @Ad,Resim = @Resim,Etiket = @Etiket WHERE ID = @ID", pCollection))
                AKBclass.DigerIslemler.MesajVerNew("Kategori güncelleme işleminde hata oluştu");
            else
            {
                AKBclass.DigerIslemler.MesajVerNew("Kategori Güncellendi.");
                Panel1.Visible = false;
            }
        
        }
        MenuDoldur();
        
    }
    protected void BtnGuncelle_Click(object sender, EventArgs e)
    {
        if (TreeView1.SelectedNode == null)
            AKBclass.DigerIslemler.MesajVerNew("Kategori Seçiniz");
        else
        {
            HfID.Value = TreeView1.SelectedNode.Value;
            KategoriAc(false);
        }
    }
    protected void BtnSil_Click(object sender, EventArgs e)
    {
        if ("-1" == AKBclass.DBMudahale.Varmi("Kategori_Tbl", "WHERE UstKategoriID = " + TreeView1.SelectedNode.Value))
        { // sil
            if ("-1" == AKBclass.DBMudahale.Varmi("UrunKategori_Tbl", "WHERE KategoriID = " + TreeView1.SelectedNode.Value))
            { // sil
                if ("-1" == AKBclass.DBMudahale.SQLIsle("DELETE FROM Kategori_Tbl WHERE ID = " + TreeView1.SelectedNode.Value))
                    AKBclass.DigerIslemler.MesajVerNew("Hata Oluştu Kategori Silinemedi!");
                else
                    AKBclass.DigerIslemler.MesajVerNew("Kategori Silindi.");
            }
            else
            {
                AKBclass.DigerIslemler.MesajVerNew("Kategoriye Bağlı Ürün Var. Silinemez");
            }

        }
        else
        { // kayıt var
            AKBclass.DigerIslemler.MesajVerNew("Kategoriye Bağlı Alt Kategori Var. Silinemez");
        }
        MenuDoldur();
    }
    protected void BtnEkle_Click(object sender, EventArgs e)
    {
        if (TreeView1.SelectedNode == null)
            AKBclass.DigerIslemler.MesajVerNew("Kategori Seçiniz");
        else
        {
            HfID.Value = TreeView1.SelectedNode.Value;
            KategoriAc(true);
        }
    }
}