using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Specialized;

public partial class Yonetim_Kalip : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UyeID"] == null && !Path.GetFileName(Request.ServerVariables["SCRIPT_NAME"]).Equals("Login.aspx"))
        {
            Response.Redirect("Login.aspx?Sayfa=" + Path.GetFileName(Request.ServerVariables["SCRIPT_NAME"]));

        }
    }
}
