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
using Microsoft.Win32;
using System.IO;


namespace Aulas
{
    /// <summary>
    /// Lógica interna para Imagens.xaml
    /// </summary>
    public partial class Imagens : Window
    {
        #region Código
        private OpenFileDialog SelecionaImagem = null;

        public Imagens()
        {
            InitializeComponent();
            //define o metodo que sera executado para ler a imagem e atribuir ao objeto imagem
            SelecionaImagem = new OpenFileDialog();
            SelecionaImagem.FileOk += CarregarImagem;
        }
        #region Carregar
        private void CarregarImagem(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //cololacar a imagem
            try
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(SelecionaImagem.FileName.ToString());
                img.EndInit();
                Imagem.Source = img;

                // informações da imagem
                FileInfo info = new FileInfo(SelecionaImagem.FileName.ToString());
                Informacoes.Content = "Nome: " + info.Name + "\n";
                Informacoes.Content += "Tamanho: " + info.Length.ToString() + "Bytes\n";
                Informacoes.Content += "Criação " + info.CreationTime.ToString() + "\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Apenas arquivos de imagem\n"+ex.Message);
                //throw;
            }            
        }
        #endregion

        #region Abrir
        private void Abrir_Click(object sender, RoutedEventArgs e)
        {
            SelecionaImagem.Filter = "Imagens (*.jpg, *jpeg, *png)|*.jpg; *jpeg; *png";
            SelecionaImagem.ShowDialog();
        }
        #endregion

        #region Sair
        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Quer realmente me dar tchau? <3", "Tchau o/", MessageBoxButton.YesNoCancel);
            if (mbr == MessageBoxResult.Yes)
            {
                //salva sai

            }
            else if (mbr == MessageBoxResult.No)
            {
                //não salva e sai
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #endregion
    }
}