using Asmens_kodas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Asmens_kodas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonalCodeModel _PCM;

        public PersonalCodeModel PCM
        {
            get { return _PCM; }
            set { 
                _PCM = value;
                getDate.Text = PCM.getDate().ToString("yyyy-MM-dd");
                getYear.Text = PCM.getYear().ToString();
                getMonth.Text = PCM.getMonth().ToString();
                getDay.Text = PCM.getDay().ToString();
                getSex.Text = PCM.getSex().ToString();
                getNumber.Text = PCM.getNumber().ToString();
                getCheckSum.Text = PCM.getCheckSum().ToString();
                getID.Text = PCM.Code.ToString();
            }
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EilesNr.Text.Count() == 3)
                {
                    if(BirthDate.SelectedDate != null)
                    {
                        if ((bool)RadioMale.IsChecked)
                        {
                            PCM = new PersonalCodeModel((DateTime)BirthDate.SelectedDate, GenderEnum.Male, int.Parse(EilesNr.Text));
                        }
                        else
                        {
                            PCM = new PersonalCodeModel((DateTime)BirthDate.SelectedDate, GenderEnum.Male, int.Parse(EilesNr.Text));
                        }
                    }else
                    {
                        MessageBox.Show("Please select date");
                    }
                    
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void EilesNr_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9]");
            if (!reg.IsMatch(e.Text) && (sender as TextBox).Text.Length < 3)
            {
                e.Handled = false;
            }else
            {
                e.Handled = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(Kodas.Text))
                    PCM = new PersonalCodeModel(long.Parse(Kodas.Text));

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Kodas_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9]");
            if (!reg.IsMatch(e.Text) && (sender as TextBox).Text.Length < 11)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
