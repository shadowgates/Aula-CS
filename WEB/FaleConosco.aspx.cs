using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// bibliotecas para enviar email
using System.Net;
using System.Net.Mail;

public partial class FaleConosco : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Enviar_Click(object sender, EventArgs e)
    {
        if (Nome.Text.Trim() == "")
        {
            MsgErro.Text = "O nome deve ser digitado";
        }
        else if (Email.Text.Trim() == "")
        {
            MsgErro.Text = "O email deve ser digitado";
        }
        else
        {
            SmtpClient smtp = new SmtpClient();
            MailMessage msg = new MailMessage();

            // Cria a mensagem do email
            msg.Subject = "FALE CONOSCO";
            msg.Body = Nome.Text + "\n\r" + Email.Text + "\n\r" + Mensagem.Text;
            msg.To.Add("contato@seudominio.com.br");
            MailAddress eFrom = new MailAddress("contato@seudominio.com.br");
            msg.From = eFrom;

            // Autentica no servidor smtp para enviar
            smtp.Host = "smtps.seudominio.com.br";
            smtp.Port = 587;
            smtp.EnableSsl = false;
            smtp.Credentials = new NetworkCredential("contato@seudominio.com.br", "suasenha");
            // Conecta no servidor e envia o email
            smtp.Send(msg);
        }
    }
}