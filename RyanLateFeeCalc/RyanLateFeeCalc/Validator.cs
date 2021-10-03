using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RyanLateFeeCalc
{
    public static class Validator
    {

        // Set the error message poput title
        private static string title = "Entry Error";

        public static string Title
        {
            get { return title; }
            set { title = value; }
        }

        // Ispresent for required fields
        public static bool IsPresent(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(textBox.Tag + " is a required field.", Title);
                textBox.Focus();
                return false;
            }

            return true;
        }

        //IsDecimal checks if entry is decimal
        public static bool IsDecimal(TextBox textBox)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + "must be a decimal value", Title);
                textBox.Focus();
                return false;
            }
        }

        // IsInteger checks if entry is an integer...
        public static bool IsInteger(TextBox textBox)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + "must be an integer value", Title);
                textBox.Focus();
                return false;
            }
        }
    }
}
