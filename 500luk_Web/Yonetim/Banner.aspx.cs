using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_Banner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Literal1.Text = "<img src='../TR/resimler/som.jpg'>";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath(@"../TR/resimler/som.jpg"));
            Literal1.Text = "<img src='../TR/resimler/som.jpg?aa=" + AKBclass.DigerIslemler.Benzersiz() + "'>";
            AKBclass.DigerIslemler.MesajVerNew("Resim yüklendi");
        }
        else
        {
            AKBclass.DigerIslemler.MesajVerNew("Resim Seçiniz");
        }

    }
}