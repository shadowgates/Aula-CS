using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Adm_Usuarios : System.Web.UI.Page
{
    // CLASSE DE TRANSAÇÃO NO BANCO DE DADOS ACCESS
    private AppDatabase.OleDBTransaction dbase;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadGrid();
    }

    // EXIBE TODOS OS USUÁRIO NO GRID 
    protected void LoadGrid()
    {
        string sql = "SELECT UsuarioId,Nome,Email FROM Usuarios WHERE Status=1 ORDER BY Nome;";

        dbase = new Conexao().GetConnection();

        DataTable tb = (DataTable)dbase.Query(sql);
        if (tb.Rows.Count > 0)
        {
            Usuarios.DataSource = tb;
            Usuarios.DataBind();
        }
    }

    // SALVA OS DADOS NA TABELA USUÁRIOS
    protected void Salvar_Click(object sender, EventArgs e)
    {
        if (Nome.Text.Trim() == "")
        {
            MsgErro.Text = "Digite o nome";
        }
        if (Senha.Text.Trim() == "")
        {
            MsgErro.Text = "Digite o senha";
        }
        else
        {
            string sql = "";

            if (UsuarioId.Value != "")
            {
                // UPDATE
                sql = "UPDATE Usuarios SET Nome='" + Nome.Text + "',Email='" + Email.Text + "',Senha='" + Senha.Text + "',DateTimeUpdate=Now() WHERE UsuarioID=" + UsuarioId.Value;
            }
            else
            {
                sql = "INSERT INTO Usuarios(Nome,Email,Senha,DateTimeInsert,DateTimeUpdate,Status) VALUES('" + Nome.Text + "','" + Email.Text + "','" + Senha.Text + "',Now(),Now(),1);";
            }
            dbase = new Conexao().GetConnection();
            dbase.Query(sql);
        }
        LimparCampos();
    }

    protected void Usuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
                
        // Obtem o UsuarioId do item selecionado no gridview
        UsuarioId.Value = Usuarios.SelectedRow.Cells[1].Text;
        string sql = "SELECT * FROM Usuarios WHERE UsuarioId=" + UsuarioId.Value + " AND Status=1;";

        dbase = new Conexao().GetConnection();
        DataTable tb = (DataTable)dbase.Query(sql);

        // verifica se o registro foi encontrado na tabela
        if (tb.Rows.Count == 1)
        {
            Nome.Text = tb.Rows[0]["Nome"].ToString();
            Email.Text = tb.Rows[0]["Email"].ToString();
            Senha.Text = tb.Rows[0]["Senha"].ToString();

            // habilita o botão excluir
            Excluir.Enabled = true;
        }
        else
        {
            MsgErro.Text = "Usuario Não encontrado";
        }



    }

    protected void Excluir_Click(object sender, EventArgs e)
    {
        if (UsuarioId.Value == null)
        {
            MsgErro.Text = "Usuario Não encontrado";
        }
        else
        {
            string sql = "UPDATE Usuarios set Status = -1 where  UsuarioID = " + UsuarioId.Value;
            dbase = new Conexao().GetConnection();
            dbase.Query(sql);
            LimparCampos();
        }
    }

    public void LimparCampos()
    {
        Nome.Text = "";
        Email.Text = "";
        Senha.Text = "";

        LoadGrid();
    }
}