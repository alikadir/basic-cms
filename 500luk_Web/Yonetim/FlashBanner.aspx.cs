using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Yonetim_FlashBanner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Sil"] != null)
            {
                ResimSil(Request.QueryString["Sil"].ToString(),Request.QueryString["Resim"].ToString());
            }
        }
    }
    void ResimSil( string ID,string Resim)
    {
        try 
        { 
            int _ID = int.Parse(ID);

            File.Delete(Server.MapPath("~/Foto/FlashBanner/")+Resim);

            AKBclass.DBMudahale.SQLIsle("DELETE FROM FlashBanner_Tbl WHERE ID =" + ID);

            Response.Redirect("FlashBanner.aspx");

        }
        catch 
        {
            AKBclass.DigerIslemler.MesajVerNew("Resim Silinemedi!");
        }
    
    }
    protected void BtnYukle_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string DosyaAd = AKBclass.DigerIslemler.Benzersiz() + Path.GetExtension(FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath("../Foto/FlashBanner/") + DosyaAd);

            if (string.IsNullOrEmpty(TxtEtiket.Text))
                AKBclass.DBMudahale.SQLIsle("INSERT INTO FlashBanner_Tbl (Resim) VALUES('" + DosyaAd + "')");
            else
                AKBclass.DBMudahale.SQLIsle("INSERT INTO FlashBanner_Tbl (Resim,Etiket) VALUES('" + DosyaAd + "','" + TxtEtiket.Text + "')");

            AKBclass.DigerIslemler.MesajVerNew("Resim Yüklendi.");
            TxtEtiket.Text = "";
            DataList1.DataBind();
        }
        else
        {
            AKBclass.DigerIslemler.MesajVerNew("Resim Seçiniz!");
        }
    }
}