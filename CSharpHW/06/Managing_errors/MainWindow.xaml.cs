using System;
using System.Windows;

namespace HW1
{
    public partial class MainWindow : Window
    {
        Random _rand = new Random();
        int _programValue;
        int _tryLeft;

        public MainWindow()
        {
            InitializeComponent();

            _programValue = _rand.Next(0, 10);
            _tryLeft = 3;
        }

        private void TryBtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var value = int.Parse(ValueTextBox.Text);

                if (!(value >= 0 && value <= 10))
                {
                    throw new ArgumentOutOfRangeException("Value should be between 0 and 10");
                }

                if (value == _programValue)
                {
                    MessageBox.Show("Поздравляю! Вы угадали!");
                    _programValue = _rand.Next(0, 10);
                    _tryLeft = 3;
                    TryCount.Content = "Попытки: " + _tryLeft;
                }
                else
                {
                    _tryLeft--;
                    TryCount.Content = "Попытки: " + _tryLeft;
                }

                if (_tryLeft >= 1)
                {
                    return;
                }

                MessageBox.Show("Вы проиграли!");
                _programValue = _rand.Next(0, 10);
                _tryLeft = 3;
                TryCount.Content = "Попытки: " + _tryLeft;
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод.");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Введите число в диапазоне от 0 до 10.");
            }
        }

        private void ExitBtnClick(object sender, RoutedEventArgs e)
        {
            Close();  
        }
    }
}
