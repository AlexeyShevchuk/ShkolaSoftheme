using System;
using System.Linq;
using System.Windows;

namespace HW1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NextBtnClick(object sender, RoutedEventArgs e)
        {
            FirstNameValidation();
            LastNameValidation();
            BirthDateValidation();
            GenderValidation();
            EmailValidation();
            PhoneMumberValidation();
            AdditionalInfoValidation();
        }

        private bool IsOnlyLetters(string str)
        {
            if (str == string.Empty)
            {
                return false;
            }

            foreach (var item in str)
            {
                if ((item >= 65 && item <= 90) || (item >= 97 && item <= 122))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsOnlyNumbers(string str)
        {
            if (str == string.Empty)
            {
                return false;
            }

            foreach (var item in str)
            {
                if (item >= 48 && item <= 57)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsDateValid(string str)
        {
            if (str == string.Empty)
            {
                return false;
            }

            foreach (var item in str)
            {
                if (item >= 47 && item <= 57)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private bool FirstNameValidation()
        {
            if (fnTextBox.Text.Equals(string.Empty))
            {
                fnValidInfo.Content = "Empty entry";
                return false;
            }

            if (fnTextBox.Text.Length > 254 || !IsOnlyLetters(fnTextBox.Text)) // only letters, length < 255 symbols
            {
                fnValidInfo.Content = "Only letters and length < 255 symbols";
            }
            else
            {
                fnValidInfo.Content = string.Empty;
            }

            return true;
        }

        private bool LastNameValidation()
        {
            if (lnTextBox.Text.Equals(string.Empty))
            {
                lnValidInfo.Content = "Empty entry";
                return false;
            }

            if (lnTextBox.Text.Length > 254 || !IsOnlyLetters(lnTextBox.Text)) // only letters, length < 255 symbols
            {
                lnValidInfo.Content = "Only letters and length < 255 symbols";
            }
            else
            {
                lnValidInfo.Content = string.Empty;
            }

            return true;
        }

        private bool BirthDateValidation()
        {
            if (bdTextBox.Text.Equals(string.Empty))
            {
                bdValidInfo.Content = "Empty entry";
                return false;
            }

            if (!DateTime.TryParse(bdTextBox.Text, out DateTime date) || !IsDateValid(bdTextBox.Text))
            {
                bdValidInfo.Content = "Invalid data format. Required ДД/ММ/ГГГГ";
                return false;
            }
            else if (0 < date.Day && date.Day < 32 || 0 < date.Month && date.Month < 13 || 1900 < date.Year && date.Year < DateTime.Now.Year) //0 < day < 32, 0 < month < 13, 1900 < year < current year
            {
                bdValidInfo.Content = string.Empty;
            }
            else
            {
                bdValidInfo.Content = "0 < day < 32, 0 < month < 13, 1900 < year < current year";
                return false;
            }

            return true;
        }

        private bool GenderValidation()
        {
            if (gTextBox.Text.Equals(string.Empty))
            {
                gValidInfo.Content = "Empty entry";
                return false;
            }

            if (gTextBox.Text.Equals("male") || gTextBox.Text.Equals("female"))
            {
                gValidInfo.Content = string.Empty;
                return true;
            }

            gValidInfo.Content = "Only male or female";

            return false;
        }

        private bool EmailValidation()
        {
            if (eTextBox.Text.Equals(string.Empty))
            {
                eValidInfo.Content = "Empty entry";
                return false;
            }
            if (eTextBox.Text.Length > 254 || !eTextBox.Text.Contains('@')) // should contains @, length < 255 symbols
            {
                eValidInfo.Content = "Should contains @, length < 255 symbols";
            }
            else
            {
                eValidInfo.Content = string.Empty;
            }

            return true;
        }

        private bool PhoneMumberValidation()
        {
            if (pTextBox.Text.Equals(string.Empty))
            {
                pValidInfo.Content = "Empty entry";
                return false;
            }

            if (!IsOnlyNumbers(pTextBox.Text) || pTextBox.Text.Length != 12)// only numbers, length = 12
            {
                pValidInfo.Content = "Only numbers, length = 12";
                return false;
            }
            else
            {
                pValidInfo.Content = string.Empty;
            }

            return true;
        }

        private bool AdditionalInfoValidation()
        {
            if (aTextBox.Text.Equals(string.Empty))
            {
                aValidInfo.Content = string.Empty;
                return true;
            }

            if (aTextBox.Text.Length >= 2000)// length < 2000 symbols
            {
                aValidInfo.Content = "Length < 2000 symbols";
                return false;
            }
            else
            {
                aValidInfo.Content = string.Empty;
            }

            return true;
        }
    }
}
