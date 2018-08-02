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

using System.Windows.Threading;
using System.Globalization;

namespace Aulas
{
    /// <summary>
    /// Lógica interna para Calendario.xaml
    /// </summary>
    /// 

    public partial class Calendario : Window
    {
        #region Código

        #region Relogio
        DispatcherTimer th = new DispatcherTimer();
        DispatcherTimer ct = new DispatcherTimer();
        public Calendario()
        {
            InitializeComponent();

            th.Tick += new EventHandler(th_tick);
            th.Interval = new TimeSpan(0, 0, 0, 0, 1);
            th.Start();

            ct.Tick += new EventHandler(ct_tick);
            ct.Interval = new TimeSpan(0, 0, 0, 0, 1);
            ct.Start();
        }

        int x = 0;
        private void th_tick(object sende, EventArgs e)
        {
            HoraAtual.Content = DateTime.Now.ToString();
        }

        private void ct_tick(object sende, EventArgs e)
        {
            x += 1;
            Contador.Content = x;
        }
        #endregion

        #region Começar
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            th.Start();
            Stop.IsEnabled = true;
            Start.IsEnabled = false;
        }
        #endregion

        #region Parar
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            th.Stop();
            Stop.IsEnabled = false;
            Start.IsEnabled = true;
        }
        #endregion

        #region Calendario
        private void Calendario1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Dia.Content = "Dia: " + Calendario1.SelectedDate.Value.Day;
            Mes.Content = "Mes: " + Calendario1.SelectedDate.Value.Month;
            Ano.Content = "Ano: " + Calendario1.SelectedDate.Value.Year;
            DiaSemana.Content = "Dia da Semana: " + Calendario1.SelectedDate.Value.DayOfWeek;
            NomeMes.Content = "Mes: " + Calendario1.SelectedDate.Value.Date.ToString("MMMM");

            ExibeData();
        }
        #endregion

        #region Culturas
        private void Culturas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ExibeData();
        }

        private void ExibeData()
        {
            if (Culturas.SelectedIndex != 0 && Calendario1.SelectedDate.Value.ToString() != "")
            {
                ComboBoxItem cb = (ComboBoxItem)Culturas.SelectedItem;
                var culture = new CultureInfo(cb.Content.ToString());

                DataCultura.Content = Calendario1.SelectedDate.Value.Date.ToString(culture);
            }

        }
        #endregion
    }
        #endregion
}