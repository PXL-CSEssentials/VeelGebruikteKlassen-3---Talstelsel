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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VeelGebruikteKlassen_3___Talstelsel
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

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            string hex = hexadecimalTextBox.Text;
            // Simpelere en efficiëntere manier om hexadecimaal getal om te zetten naar decimaal getal:
            // int dec = Convert.ToInt32(hex, 16);
            // Maar wij doen dit met een loop door de hex string...
            int dec = 0;
            for (int i = 0, j = hex.Length - 1; i < hex.Length; i++, j--)
            {
                int factor = (int)Math.Pow(16, j);

                if (char.IsDigit(hex[i]))
                {
                    dec += (int)char.GetNumericValue(hex[i]) * factor;
                }
                else
                {
                    switch (hex[i])
                    {
                        case 'A':
                        case 'a':
                            dec += 10 * factor;
                            break;
                        case 'B':
                        case 'b':
                            dec += 11 * factor;
                            break;
                        case 'C':
                        case 'c':
                            dec += 12 * factor;
                            break;
                        case 'D':
                        case 'd':
                            dec += 13 * factor;
                            break;
                        case 'E':
                        case 'e':
                            dec += 14 * factor;
                            break;
                        case 'F':
                        case 'f':
                            dec += 15 * factor;
                            break;
                        default:
                            MessageBox.Show(
                            "Geef een correct hexadecimaal getal in!",
                            "Foutieve invoer",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                            clearButton_Click(this, null);
                            return;
                    }
                }
            }
            decimalTextBox.Text = $"{dec:N0}";
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            hexadecimalTextBox.Clear();
            decimalTextBox.Clear();
            hexadecimalTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
