using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TR_ASCX_YorumlarKisa : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string YorumKes(string Yorum)
    {
        int K = 30;

        if (Yorum.Length > K)
            return Yorum.Substring(0, K) + "...";
        else
            return Yorum;

       
    }
}