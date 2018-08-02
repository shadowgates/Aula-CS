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

namespace Aulas
{
    /// <summary>
    /// Lógica interna para Controles.xaml
    /// </summary>
    public partial class Controles : Window
    {
        #region Código
        public Controles()
        {
            InitializeComponent();
        }
        #region Mudar Texto
        private void Nome_TextChanged(object sender, TextChangedEventArgs e)
        {
            Resultado.Content = Nome.Text;
        }
        #endregion

        #region Limpar
        private void Limpar_Click(object sender, RoutedEventArgs e)
        {
            Nome.Text = "";
        }
        #endregion

        #region Cores
        private void Vermelho_Checked(object sender, RoutedEventArgs e)
        {
            Resultado.Foreground = Brushes.Red;
        }

        private void Verde_Checked(object sender, RoutedEventArgs e)
        {
            Resultado.Foreground = Brushes.Green;
        }

        private void Azul_Checked(object sender, RoutedEventArgs e)
        {
            Resultado.Foreground = Brushes.Blue;
        }
        #endregion

        #region Localização
        private void Paises_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cb = (ComboBoxItem)Paises.SelectedItem;
            Resultado.Content = cb.Content;
        }
        #endregion

        #region Fechar
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
    }
    #endregion
}
