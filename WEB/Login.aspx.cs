using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
			protected void Page_Load(object sender, EventArgs e)
			{

			}

			protected void Entrar_Click(object sender, EventArgs e)
			{
						if (LoginOk(Nome.Text, Senha.Text))
						{
									// Inicializa a classe de autenticação do usuário
									FormsAuthentication.Initialize();
									// Define os dados do ticket de autenticação 
									FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Nome.Text, DateTime.Now, DateTime.Now.AddMinutes(30), false, Nome.Text, FormsAuthentication.FormsCookiePath);
									// Grava o ticket no cookie de autenticação
									Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,
													FormsAuthentication.Encrypt(ticket)));
									// Redireciona para a página do usuário
									Response.Redirect(FormsAuthentication.GetRedirectUrl(Nome.Text, false));
						}
						else
						{
								MsgErro.Text = "Credenciais inválidas";
						}
			}

			protected bool LoginOk(string nome, string senha)
			{
						// CLASSE DE TRANSAÇÃO NO BANCO DE DADOS ACCESS
						AppDatabase.OleDBTransaction db = new Conexao().GetConnection();

						DataTable tb = (DataTable)db.Query("SELECT * FROM Usuarios WHERE Nome='" + Nome.Text + "' AND Senha='" + Senha.Text + "' AND Status=1;");

						if (tb.Rows.Count == 1)
						{
									// Armazena o nome do usuário na variável de sessão 
									Session["Usuario"] = tb.Rows[0]["Nome"];
									Session["NomeUsuario"] = tb.Rows[0]["Nome"];
									return true;
						}
						else
						{
									return false;
						}
			}

}