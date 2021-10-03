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
    public partial class frmLateFilms : Form
    {
        public frmLateFilms()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get movie from user
            string movie = txtMovie.Text;

            // Validate user entry
            if (IsValidData(movie))
            {
                // Add movie to list
                lstLateMovies.Items.Add(movie);
            }


            // Clear text field 
            txtMovie.Clear();

        }

        // Checks if user enters an empty string
        private bool IsValidData(string movie)
        {
            if (movie == "")
            {
                MessageBox.Show("Please enter a movie", "Entry Error");
                txtMovie.Focus();
                return false;

            }
            return true;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Get count of movies in list
            int moviesCount = lstLateMovies.Items.Count;

            // Save count as the tag and set the DialogResult property of the form to OK
            this.Tag = moviesCount;
            this.DialogResult = DialogResult.OK;
        }
    }
}
