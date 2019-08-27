using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_ASCXler_UserInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            if (Session["UyeID"] != null)
            {
                LblInfo.Text = "Hoşgeldiniz: " + AKBclass.DBMudahale.TekDegerDondur("SELECT Ad FROM Uye_Tbl WHERE ID = " + Session["UyeID"].ToString());
                Panel1.Visible = true;
                    
            }
            else
              Panel1.Visible = false;
                    
            

        }

    }
}