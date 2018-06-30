using System.Windows;
using System.Windows.Controls;


namespace HW1
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
        private void ListBoxTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (ListBoxItem)type.SelectedItem;

            switch (selectedItem.Content.ToString())
            {
                case "sbyte": ShowSbyteValue(); break;
                case "long": ShowLongValue(); break;
                case "short": ShowShortValue(); break;
                case "int": ShowIntValue(); break;
                case "byte": ShowByteValue(); break;
                case "ushort": ShowUshortValue(); break;
                case "uint": ShowUintlValue(); break;
                case "ulong": ShowUlongValue(); break;
            }
        }

        private void ShowSbyteValue()
        {
            minValue.Text = sbyte.MinValue.ToString();
            maxValue.Text = sbyte.MaxValue.ToString();
        }
        
        private void ShowLongValue()
        {
            minValue.Text = long.MinValue.ToString();
            maxValue.Text = long.MaxValue.ToString();
        }

        private void ShowShortValue()
        {
            minValue.Text = short.MinValue.ToString();
            maxValue.Text = short.MaxValue.ToString();
        }

        private void ShowIntValue()
        {
            minValue.Text = int.MinValue.ToString();
            maxValue.Text = int.MaxValue.ToString();
        }

        private void ShowByteValue()
        {
            minValue.Text = byte.MinValue.ToString();
            maxValue.Text = byte.MaxValue.ToString();
        }

        private void ShowUshortValue()
        {
            minValue.Text = ushort.MinValue.ToString();
            maxValue.Text = ushort.MaxValue.ToString();
        }

        private void ShowUintlValue()
        {
            minValue.Text = uint.MinValue.ToString();
            maxValue.Text = uint.MaxValue.ToString();
        }

        private void ShowUlongValue()
        {
            minValue.Text = ulong.MinValue.ToString();
            maxValue.Text = ulong.MaxValue.ToString();
        }

        private void QuitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}