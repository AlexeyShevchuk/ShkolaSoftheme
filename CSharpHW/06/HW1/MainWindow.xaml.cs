using System;
using System.Windows;

namespace HW1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
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
                var _value = int.Parse(valueTextBox.Text);
                if (!(_value >= 0 && _value <= 10))
                    {
                    throw new ArgumentOutOfRangeException();

                }
                if (_value == _programValue)
                {
                    MessageBox.Show("Поздравляю! Вы угадали!");
                    _programValue = _rand.Next(0, 10);
                    _tryLeft = 3;
                    tryCount.Content = "Попытки: " + _tryLeft;
                }
                else
                {
                    tryCount.Content = "Попытки: " + _tryLeft;
                }
                _tryLeft--;
                if (_tryLeft < 1)
                {
                    MessageBox.Show("Вы проиграли!");
                    _programValue = _rand.Next(0, 10);
                    _tryLeft = 3;
                    tryCount.Content = "Попытки: " + _tryLeft;
                    return;
                }
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
    }
}
