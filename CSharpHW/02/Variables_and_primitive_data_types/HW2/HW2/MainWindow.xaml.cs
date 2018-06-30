using System.Globalization;
using System.Windows;

namespace HW2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Calc(string operation)
        {
            if (operand1.Text == string.Empty || operand2.Text == string.Empty)
            {
                return;
            }

            if (!double.TryParse(operand1.Text, out var a) || !double.TryParse(operand2.Text, out var b))
            {
                operand1.Text = "0";
                operand2.Text = "0";
                resultextbox.Text = string.Empty;

                return;
            }

            switch (operation)
            {
                case "+":
                    a += b;
                    break;
                case "-":
                    a -= b;
                    break;
                case "*":
                    a *= b;
                    break;
                case "/":
                    if (b == 0)
                    {
                        MessageBox.Show("Division by zero!");
                        resultextbox.Text = string.Empty;
                        return;
                    }
                    a /= b;
                    break;
                default:
                    resultextbox.Text = string.Empty;
                    return;
            }

            resultextbox.Text = string.Format(CultureInfo.CurrentCulture, "{0:f}", a);
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Calc("+");
        }

        private void SubtractClick(object sender, RoutedEventArgs e)
        {
            Calc("-");
        }

        private void MultiplyClick(object sender, RoutedEventArgs e)
        {
            Calc("*");
        }

        private void DivideClick(object sender, RoutedEventArgs e)
        {
            Calc("/");
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
