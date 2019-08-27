using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_YorumOnayla : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Sil")
        {
            AKBclass.DBMudahale.SQLIsle("DELETE FROM Yorum_Tbl WHERE ID = " + e.CommandArgument);
        }
        else
        {
            AKBclass.DBMudahale.SQLIsle("UPDATE Yorum_Tbl SET GorunsunMu = 'True'  WHERE ID = " + e.CommandArgument);
        }

        DataList1.DataBind();
    }
}