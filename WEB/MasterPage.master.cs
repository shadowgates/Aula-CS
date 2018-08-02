using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["NomeUsuario"] != null)
        {
            // USUÁRIO FOI AUTENTICADO
            Cadastro.Visible = true;
            Login.Visible = false;
            Logout.Visible = true;
        }
        else
        {
            Cadastro.Visible = false;
            Login.Visible = true;
            Logout.Visible = false;
        }
    }
}
