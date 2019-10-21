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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(EilesNr.Text.Count() == 3)
            {
                if ((bool)RadioMale.IsChecked)
                {
                    PersonalCodeModel pcm = new PersonalCodeModel((DateTime)BirthDate.SelectedDate, GenderEnum.Male, int.Parse(EilesNr.Text));
                }
                else
                {
                    PersonalCodeModel pcm = new PersonalCodeModel((DateTime)BirthDate.SelectedDate, GenderEnum.Male, int.Parse(EilesNr.Text));
                }
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
    }
}
