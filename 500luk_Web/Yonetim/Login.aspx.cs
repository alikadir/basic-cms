using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Yonetim_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnGirıs_Click(object sender, EventArgs e)
    {
        SqlParameter[] pCollection = new SqlParameter[]
         {       
       
              /*0*/new SqlParameter("@Eposta",SqlDbType.NVarChar, 50),
              /*1*/new SqlParameter("@Sifre",SqlDbType.NVarChar, 50),
              /*2*/new SqlParameter("@AktifMi",SqlDbType.Bit),
         };

        pCollection[0].Value = TxtEposta.Text;
        pCollection[1].Value = TxtSifre.Text;
        pCollection[2].Value = true;

        string ID = AKBclass.DBMudahale.TekDegerDondur("SELECT ID FROM Uye_Tbl WHERE Eposta = @Eposta AND Sifre = @Sifre AND AktifMi = @AktifMi", pCollection);

        if (ID == "-1")
        {
            AKBclass.DigerIslemler.MesajVerNew("Giriş bilgileri hatalı. Kullanıcı bulunamadı!");

        }
        else
        {
            Session["UyeID"] = ID;

            if (Request.QueryString["Sayfa"] != null)
                Response.Redirect(Request.QueryString["Sayfa"].ToString());
            else
                Response.Redirect("Default.aspx");
        
        }

    }
}