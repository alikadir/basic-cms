using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class XMLci : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request.QueryString["I"])
        {
            case"Flash":
                FlashBanner();
                break;
            case "Galeri":
                Galeri();
                break;
        }
    }


    void Galeri()
    {

        string Donen = "<?xml version='1.0' encoding='utf-8'?><root>";


        DataTable dt = AKBclass.DBMudahale.TabloDoldur("SELECT * FROM  Resim_Tbl WHERE Etiket = 'Galeri'");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Donen += "<resim><B>../Foto/Galeri/" + dt.Rows[i]["BuyukResim"].ToString() + "</B><K>../Foto/Galeri/" + dt.Rows[i]["KucukResim"].ToString() + "</K></resim>";
        }


        Donen += "</root>";

        Response.ContentType = "text/xml";

        Response.Clear();
        Response.Write(Donen);
        Response.End();
    
    }

    void FlashBanner()
    {
        string Donen = "<?xml version='1.0' encoding='utf-8'?><root>";


        DataTable dt = AKBclass.DBMudahale.TabloDoldur("SELECT * FROM  FlashBanner_Tbl");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Donen += "<resim>../Foto/FlashBanner/" + dt.Rows[i]["Resim"].ToString() + "</resim>";
        }


        Donen += "</root>";

        Response.ContentType = "text/xml";

        Response.Clear();
        Response.Write(Donen);
        Response.End();
    }
}