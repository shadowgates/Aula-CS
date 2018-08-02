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

using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using AppManager;

namespace Aulas
{
    /// <summary>
    /// Lógica interna para Arquivo.xaml
    /// </summary>

    #region Codigo
    public partial class Arquivo : Window
    {
        #region Inicialização
        private OpenFileDialog DialogoAbrir = null;
        private SaveFileDialog DialogoSalvar = null;
        private bool flag = false;
        private string caminho = "";


        public Arquivo()
        {
            InitializeComponent();

            DialogoAbrir = new OpenFileDialog();
            DialogoAbrir.Filter = "txt|*.txt";
            DialogoAbrir.AddExtension = true;
            DialogoAbrir.FileOk += AbrirArquivoOk;

            DialogoSalvar = new SaveFileDialog();
            DialogoSalvar.Filter = "txt|*.txt";
            DialogoSalvar.AddExtension = true;
            DialogoSalvar.FileOk += GravarArquivoOk;

        }

        #endregion

        #region Abrir
        private void AbrirArquivoOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                caminho = DialogoAbrir.FileName;

                NomeArquivo.Text = DialogoAbrir.FileName;
                FileInfo arquivo = new FileInfo(DialogoAbrir.FileName);
                Conteudo.Text = "";

                TextReader reader = null;
                reader = arquivo.OpenText();

                string line = reader.ReadLine();
                while (line != null)
                {
                    Conteudo.Text += line + "\n";
                    line = reader.ReadLine();
                }
                reader.Close();
                flag = false;
                Salvar.IsEnabled = false;

                throw new System.ArgumentException("Teste", "original");
            }
            catch (Exception ex)
            {
                AppManager.AppExceptionsTxt exc = new AppExceptionsTxt();
                exc.SalvarExcecao(ex);
            }

        }
        private void Abrir_Click(object sender, RoutedEventArgs e)
        {
            DialogoAbrir.ShowDialog();
        }
        #endregion

        #region Salvar
        private void GravarArquivoOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            caminho = DialogoSalvar.FileName;
            SalvarArquivo();
        }
        private void SalvarComo_Click(object sender, RoutedEventArgs e)
        {
            DialogoSalvar.ShowDialog();

        }
        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            SalvarArquivo();
        }
        protected void SalvarArquivo()
        {
            try
            {
                if (caminho.Trim() == "")
                {
                    DialogoSalvar.ShowDialog();
                }
                else
                {
                    File.WriteAllText(caminho, Conteudo.Text, Encoding.UTF8);
                    flag = false;
                    Salvar.IsEnabled = false;
                    SalvarComo.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                AppManager.AppExceptionsTxt exc = new AppExceptionsTxt();
                exc.PathSaveException = "C:";
                exc.SalvarExcecao(ex,caminho);
            }

        }
        #endregion

        #region Editar
        private void Conteudo_TextChanged(object sender, TextChangedEventArgs e)
        {
            Salvar.IsEnabled = true;
            SalvarComo.IsEnabled = true;
            flag = true;
        }
        #endregion

        #region Fechar
        private void Window_Closig(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (flag == true)
            {
                MessageBoxResult mbr = MessageBox.Show("Quer salvar antes de sair? <3", "Tchau o/", MessageBoxButton.YesNoCancel);
                if (mbr == MessageBoxResult.Yes)
                {
                    if (DialogoSalvar.ShowDialog() == true) SalvarArquivo();
                    else e.Cancel = true;
                }
                else if (mbr == MessageBoxResult.No)
                {

                }
                else
                {
                    e.Cancel = true;
                }
            }

        }
        private void Fechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

       
    }
    #endregion

}
