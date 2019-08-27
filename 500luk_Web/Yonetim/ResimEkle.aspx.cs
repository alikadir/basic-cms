using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Yonetim_ResimEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Sil"] != null)
            {
                ResimSil(Request.QueryString["Sil"].ToString(), Request.QueryString["KucukResim"].ToString(),Request.QueryString["KucukResim"].ToString());
            }
        }
    }
    void ResimSil(string ID, string KucukResim,string BuyukResim)
    {
        try
        {
            int _ID = int.Parse(ID);

            File.Delete(Server.MapPath("~/Foto/Galeri/") + KucukResim);
            File.Delete(Server.MapPath("~/Foto/Galeri/") + BuyukResim);

            AKBclass.DBMudahale.SQLIsle("DELETE FROM Resim_Tbl WHERE ID =" + ID);

            Response.Redirect("ResimEkle.aspx");

        }
        catch
        {
            AKBclass.DigerIslemler.MesajVerNew("Resim Silinemedi!");
        }

    }
    protected void BtnYukle_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile && FileUpload2.HasFile)
        {
            string DosyaAd1 = AKBclass.DigerIslemler.Benzersiz() + Path.GetExtension(FileUpload1.FileName);
            string DosyaAd2 = AKBclass.DigerIslemler.Benzersiz() + Path.GetExtension(FileUpload2.FileName);
            FileUpload1.SaveAs(Server.MapPath("../Foto/Galeri/") + DosyaAd1);
            FileUpload2.SaveAs(Server.MapPath("../Foto/Galeri/") + DosyaAd2);

           
                AKBclass.DBMudahale.SQLIsle("INSERT INTO Resim_Tbl (KucukResim,BuyukResim,Etiket) VALUES('" + DosyaAd1 + "','" + DosyaAd2 + "','" + Cbx1.SelectedValue + "')");

            AKBclass.DigerIslemler.MesajVerNew("Resim Yüklendi.");
            
            DataList1.DataBind();
        }
        else
        {
            AKBclass.DigerIslemler.MesajVerNew("Resim Seçiniz!");
        }
    }
}