using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

public partial class Yonetim_Haberler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnKaydet_Click(object sender, EventArgs e)
    {
        SqlParameter[] pCollection = new SqlParameter[]
             {
                  /*0*/new SqlParameter("@ID",SqlDbType.Int),
                  /*1*/new SqlParameter("@Baslik",SqlDbType.NVarChar, 250),
                  /*2*/new SqlParameter("@Aciklama",SqlDbType.Text),
                  /*3*/new SqlParameter("@Etiket",SqlDbType.NVarChar, 50),
             };

        foreach (SqlParameter item in pCollection)
        {
            item.Value = DBNull.Value;
        }

        if (BtnKaydet.Text == "Kaydet")
        { // kaydet


            /*Baslik*/
            pCollection[1].Value = TxtBaslik.Text;
            /*Aciklama*/
            pCollection[2].Value = TxtAciklama.Text;
            /*Etiket*/
            pCollection[3].Value = TxtEtiket.Text;

            if ("-1" == AKBclass.DBMudahale.SQLIsle("INSERT INTO Haberler_Tbl(Baslik,Aciklama,Etiket) VALUES (@Baslik,@Aciklama,@Etiket)", pCollection))
                AKBclass.DigerIslemler.MesajVerNew("Hata Oluştu ve Kaydedilemedi");
            else
            {
                AKBclass.DigerIslemler.MesajVerNew("Kaydedildi.");
                Doldur("");
            }
        }
        else
        { // güncelle

            /*ID*/
            pCollection[0].Value = int.Parse(HfID.Value);
            /*Baslik*/
            pCollection[1].Value = TxtBaslik.Text;
            /*Aciklama*/
            pCollection[2].Value = TxtAciklama.Text;
            /*Etiket*/
            pCollection[3].Value = TxtEtiket.Text;

            if ("-1" == AKBclass.DBMudahale.SQLIsle("UPDATE Haberler_Tbl SET Baslik = @Baslik,Aciklama = @Aciklama,Etiket = @Etiket WHERE ID = @ID", pCollection))
                AKBclass.DigerIslemler.MesajVerNew("Hata Oluştu ve Güncellenemedi");
            else
            {
                AKBclass.DigerIslemler.MesajVerNew("Güncellendi");
                Doldur("");
            }

        }
        DataList1.DataBind();
    }

    void Doldur(string ID)
    {
        if (string.IsNullOrEmpty(ID))
        {
            // kayıtları boşalt
            BtnKaydet.Text = "Kaydet";

            TxtBaslik.Text = "";
            TxtAciklama.Text = "";
            TxtEtiket.Text = "";
            HfID.Value = "";

        }
        else
        {
            Hashtable ht = AKBclass.DBMudahale.TekKayitDondurHT("Haberler_Tbl", "Baslik,Aciklama,Etiket", "WHERE ID = " + ID);

            TxtBaslik.Text = (ht["Baslik"].ToString() == "-1" ? "" : ht["Baslik"].ToString());
            TxtAciklama.Text = (ht["Aciklama"].ToString() == "-1" ? "" : ht["Aciklama"].ToString());
            TxtEtiket.Text = (ht["Etiket"].ToString() == "-1" ? "" : ht["Etiket"].ToString());

            HfID.Value = ID;
            BtnKaydet.Text = "Güncelle";

        }



    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        { // sil
            AKBclass.DBMudahale.SQLIsle("DELETE FROM Haberler_Tbl WHERE ID = " + e.CommandArgument.ToString());
            AKBclass.DigerIslemler.MesajVerNew("Silindi");
            DataList1.DataBind();

        }
        else
        { // güncelle 
            Doldur(e.CommandArgument.ToString());

        }

    }
}