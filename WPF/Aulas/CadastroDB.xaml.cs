/**************************************************************************
 * exemplo de código para insert, delete, update, em um banco de dados
 * passo 1: define a string de conecção com o bancoo de dados
 * referencia:http://www.connectionstrongs.com
 * server=mySeverAddress;Database=myDB; uid=myUserName; pwd=myPassword
 * myServerAddress: endereço do servidor
 * myDataBase: nome do DB
 * uid: nome do usuario
 * pwd: senha do usuario
 * 
 * passo 2: define a string de comando sql
 * passo 3:conecta no banco de dados
 * passo 4: envia a string com o comando SQL
 * passo 5: obtem o resultado da consulta
 *          resultado para um data table se comando select
 *          ou verifica numero de linhas afetadas se insert, delete, update
***************************************************************************/
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


namespace Aulas
{
    /// <summary>
    /// Lógica interna para CadastroDB.xaml
    /// </summary>
    public partial class CadastroDB : Window
    {
        #region Código
        public CadastroDB()
        {
            InitializeComponent();
        }

        #region Fechar
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void Fechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Salvar
        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            //validar os dados 
            if (Nome.Text.Trim() == "")
            {
                MessageBox.Show("Entre com o nome");
            }
            else if (Email.Text.Trim() == "")
            {
                MessageBox.Show("Entre com o nome");
            }
            else
            {
                //Passo 1
                string conexao = "Server=localhost; Database=vendas2; Uid=root;Pwd=b53c7124";
                //Passo 2
                string comando = "INSERT INTO clientes (Nome,Email,Telefone) VALUES ('" + Nome.Text + "','" + Email.Text + "','" + Telefone.Text + "');";

                AppDatabase.MySqlTransaction db = new MySqlTransaction();
                //Passo 3
                db.ConnectionString = conexao;
                //Passo 4 e 5
                int n = (int) db.Query(comando);
                if (n == 0)
                    MessageBox.Show("Houve uma falaha ao inserir o registro.");
                else
                    MessageBox.Show("Registro inserido com sucesso!");
            }
        }
        #endregion

        #endregion
    }
}
