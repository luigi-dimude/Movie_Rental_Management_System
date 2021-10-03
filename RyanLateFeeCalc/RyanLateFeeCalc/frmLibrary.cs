using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RyanLateFeeCalc
{
    public partial class frmLibrary : Form
    {
        public frmLibrary()
        {
            InitializeComponent();

            // Populates today's date formatted as month-day-year and displays it in the txtCurrentDate textbox on initialization
            txtCurrentDate.Text = DateTime.Now.ToString(@"MM-dd-yyyy");
        }

        string customerType;
        int totalMovies = 0;
        double discount = 0;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hides the Library Moives form to navigate back to 
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    // Generate the current date from the user's computer
                    DateTime dCurrent = DateTime.Now;

                    // Generate the due date based on user entry in txtDueDate textbox
                    DateTime dDue = DateTime.Parse(txtDueDate.Text);

                    // Calculate the number of days late by deducting the current date from the due date
                    TimeSpan days = (dCurrent.Date - dDue.Date);
                    double numberOfdays = days.TotalDays;

                    // Get discount based on the customer type
                    customerType = txtCustomerType.Text;

                    // Get number of movies from Late films tag and try to parse as an int
                    Int32.TryParse(lblNumMovies.Text, out totalMovies);

                    // Display the number of days late in the txtDaysLate textbox
                    txtDaysLate.Text = numberOfdays.ToString();

                    // Calculate late fee
                    double lateFee = CalculateLateFee(numberOfdays, customerType, totalMovies);

                    // Display the late fee as the user's local currency in the txtLateFee textbox
                    txtLateFee.Text = lateFee.ToString("c");

                    // Place cursor back to customer type
                    txtCustomerType.Focus();

                    // Save late fee as the tag 
                    this.Tag = lateFee;

                }
            }

            // Handle Exceptions
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message + "\n\n" +
                ex.GetType().ToString() + "\n" +
                ex.StackTrace, "Exception");
            }
        }

        // Validates user's entries
        public bool IsValidData()
        {
            return
                // Validate Customer Type text box
                IsPresent(txtCustomerType, "Customer Type") &&
                IsCustType(txtCustomerType, "Customer Type") &&

                // No longer in use
                // Validate Number of Movies text box
                //IsPresent(txtNumOfMovies, "Number of movies") &&
                //IsInt32(txtNumOfMovies, "Number of movies") &&

                // Validate if Number of movies has been determined
                IsNumMovies(lblNumMovies, "Number of movies") &&

                // Validate Due Date text box
                IsPresent(txtDueDate, "Due Date") &&
                IsDateTime(txtDueDate, "Due Date") &&
                IsPast(txtDueDate, txtCurrentDate, "Due Date");

        }

        // Checks if entry is not entered by the user
        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        // Checks if entry is an integer
        public bool IsInt32(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be an integer.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        // Checks if the user enters a valid date
        public bool IsDateTime(TextBox textBox, string name)
        {
            DateTime date;
            if (DateTime.TryParse(textBox.Text, out date))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a valid date", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        // Compares two dates and validates if the date is appropriately greater than the other
        public bool IsPast(TextBox textBox1, TextBox textBox2, string name)
        {
            DateTime date1, date2;

            DateTime.TryParse(textBox1.Text, out date1);
            DateTime.TryParse(textBox2.Text, out date2);

            if (date2 > date1)
            {
                return true;
            }

            else
            {
                MessageBox.Show(name + " must be less than " + textBox2.Text, "Entry Error");
                textBox1.Focus();
                return false;
            }
        }

        // Checks if the number of movies has been determined
        public bool IsNumMovies(Label label, string name)
        {
            if (label.Text == "")
            {
                MessageBox.Show(name + " has not been calculated", "Entry Error");
                label.Focus();
                return false;
            }
            int number = 0;
            if (Int32.TryParse(label.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be an integer.", "Entry Error");
                label.Focus();
                return false;
            }


        }

        // Checks if the user enters a valid customer type
        public bool IsCustType(TextBox textBox, string name)
        {
            string custType = textBox.Text;

            if (custType == "N" || custType == "J" || custType == "L")
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a valid type", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        // Calculates the late fee
        private double CalculateLateFee(double numberOfdays, string customerType, int totalMovies)
        {
            // Calculate the late fee for Library Movies by subtracting 0.57 dollars for each day the user is late 
            double lateFee = 0.57 * numberOfdays;

            // Multiply by number of movies to get total late fee
            lateFee *= Convert.ToDouble(totalMovies);

            switch (customerType)
            {
                // New customers get 0% discount
                case "N":
                    discount = 0;
                    break;
                // Junior customers get 5% discount
                case "J":
                    discount = 0.05;
                    break;
                // Loyal customers get 10% discount
                case "L":
                    discount = 0.1;
                    break;
                // If the user does not provide a valid customer type, 0% dicount is given
                default:
                    discount = 0;
                    break;
            }

            // Apply discount to total late fee
            lateFee -= (lateFee * discount);
            return lateFee;
        }

        private void txtNumOfMovies_TextChanged(object sender, EventArgs e)
        {
            txtLateFee.Text = "";
        }

        private void btnAddMovies_Click(object sender, EventArgs e)
        {
            // Opens late films form and returns to the count of movies to number of movies label
            Form lateFilmsForm = new frmLateFilms();
            DialogResult selectedButton = lateFilmsForm.ShowDialog();
            if (selectedButton == DialogResult.OK)
                lblNumMovies.Text = lateFilmsForm.Tag.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Checks if late fee has been calculated
            if (txtLateFee.Text == "")
            {
                MessageBox.Show("Calculate late fee first", "Entry Error");
                txtLateFee.Focus();

            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
           
        }
    }
}
