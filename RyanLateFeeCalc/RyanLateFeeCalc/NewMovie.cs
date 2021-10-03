using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RyanLateFeeCalc.Validator;

namespace RyanLateFeeCalc
{
    public partial class NewMovie : Form
    {
        public NewMovie()
        {
            InitializeComponent();
        }
        // Initialize to movie obj to null
        private RentalItem movie = null;

        // Show form and return the created movie object
        public RentalItem GetNewMovie()
        {
            this.ShowDialog();
            return movie;
        }

        // Validate entries using the Validator class
        private bool isValidData()
        {
            return IsInteger(txtMovieNo) && IsPresent(txtDescription) && IsPresent(txtRating);
        }

        // If entries are valid, create new movie object then close form
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValidData())
            {
                movie = new RentalItem(Convert.ToInt32(txtMovieNo.Text), txtDescription.Text, txtRating.Text);
                this.Close();
            }
        }

        // Close form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
