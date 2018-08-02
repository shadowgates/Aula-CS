using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AppDatabase;
using System.Data;

namespace Aulas
{
    /// <summary>
    /// Lógica interna para CadastroEdit.xaml
    /// </summary>
    public partial class CadastroEdit : Window
    {
        #region Código

        #region Inicialização
        public CadastroEdit()
        {
            InitializeComponent();
            LoadClentes();
        }

        //Passo 1
        string conexao = "Server=localhost; Database=vendas2; Uid=root;Pwd=b53c7124";
        AppDatabase.MySqlTransaction db = new MySqlTransaction();

        string id = "";

        private void LoadClentes()
        {
            //Passo 2
            string comando = "SELECT Id,Nome FROM clientes ORDER BY Nome ASC;";
            //Passo 3
            db.ConnectionString = conexao;
            //Passo 4 e 5
            DataTable tb = (DataTable)db.Query(comando);
            //DataTable tb = db.Select(comando);

            #region ComboBox
            Clientes.Items.Clear();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                ComboBoxItem it = new ComboBoxItem();
                it.Content = tb.Rows[i]["Nome"].ToString();
                it.ToolTip = tb.Rows[i]["Id"].ToString();
                Clientes.Items.Add(it);
            }
            #endregion
        }
        #endregion

        #region Excluir
        private void Excluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja realmente excluir este item", "Excluir", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                ComboBoxItem cb = (ComboBoxItem)Clientes.SelectedItem;
                //Passo 2
                string comando = "DELETE FROM Clientes WHERE Id=" + id + ";";
                //Passo 3
                db.ConnectionString = conexao;
                //Passo 4 e 5
                int n = (int)db.Query(comando);
                if (n == 0)
                    MessageBox.Show("Houve uma falaha ao deletar o registro.");
                else
                {
                    MessageBox.Show("Registro deletado com sucesso!");
                    LimparControles();
                }
            }

        }
        #endregion

        #region Fechar
        private void Fechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Salvar
        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cb = (ComboBoxItem)Clientes.SelectedItem;
            //Passo 2
            string comando = "UPDATE clientes SET Nome = '" + Nome.Text + "',Email='" + Email.Text + "', Telefone='" + Telefone.Text +
                "' WHERE Id=" + id + ";";
            //Passo 3
            db.ConnectionString = conexao;
            //Passo 4 e 5
            int n = (int)db.Query(comando);
            if (n == 0)
                MessageBox.Show("Houve uma falaha ao alterar o registro.");
            else
            {
                MessageBox.Show("Registro alterado com sucesso!");
                LimparControles();
            }
        }
        private void LimparControles()
        {
            id = "";
            Nome.Text = "";
            Email.Text = "";
            Telefone.Text = "";
            LoadClentes();
            Salvar.IsEnabled = false;
            Excluir.IsEnabled = false;
        }
        #endregion

        #region Buscar
        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cb = (ComboBoxItem)Clientes.SelectedItem;
            //Passo 2
            string comando = "SELECT Nome,Email,Telefone FROM clientes WHERE Id=" + cb.ToolTip.ToString() + ";";
            db.ConnectionString = conexao;
            //Passo 4 e 5
            DataTable tb = (DataTable)db.Query(comando);
            //DataTable tb = db.Select(comando);
            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("Registro não encontrado");
            }
            else
            {
                id = tb.Rows[0]["Id"].ToString();
                Nome.Text = tb.Rows[0]["Nome"].ToString();
                Email.Text = tb.Rows[0]["Email"].ToString();
                Telefone.Text = tb.Rows[0]["Telefone"].ToString();
                Salvar.IsEnabled = true;
                Excluir.IsEnabled = true;
            }
        }
    }
    #endregion

    #endregion
}

