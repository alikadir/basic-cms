using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class TR_ASCX_YorumEkle : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnGonder_Click(object sender, EventArgs e)
    {
        SqlParameter[] pCollection = new SqlParameter[]
     {
          /*0*/new SqlParameter("@ID",SqlDbType.Int),
          /*1*/new SqlParameter("@Baslik",SqlDbType.NVarChar, 255),
          /*2*/new SqlParameter("@Aciklama",SqlDbType.Text),
          /*3*/new SqlParameter("@Eposta",SqlDbType.NVarChar, 150),
          /*4*/new SqlParameter("@Ad",SqlDbType.NVarChar, 150),
          /*5*/new SqlParameter("@GorunsunMu",SqlDbType.Bit),
     };

        foreach (SqlParameter item in pCollection)
        {
            item.Value = DBNull.Value;
        }

      
        /*Baslik*/
        pCollection[1].Value = DBNull.Value;
        /*Aciklama*/
        pCollection[2].Value = TxtAciklama.Text;
        /*Eposta*/
        pCollection[3].Value = TxtEposta.Text;
        /*Ad*/
        pCollection[4].Value = TxtAd.Text;
        /*GorunsunMu*/
        pCollection[5].Value = false;

        AKBclass.DBMudahale.SQLIsle("INSERT INTO Yorum_Tbl(Baslik,Aciklama,Eposta,Ad,GorunsunMu) VALUES (@Baslik,@Aciklama,@Eposta,@Ad,@GorunsunMu)", pCollection);


        AKBclass.DigerIslemler.MesajVerNew(@"Kaydedildi..\nYönetici onayı bekliyor");

        TxtAd.Text = "";
        
        TxtEposta.Text = "";
        TxtAciklama.Text = "";

     
    }
}