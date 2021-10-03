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
    public partial class frmMaintenance : Form
    {
        public frmMaintenance()
        {
            InitializeComponent();
        }

        // Initialize to null
        private List<RentalItem> movies = null;

        // Clear the list first then fill the list with the movies
        private void FillMovieListBox()
        {
            lstMovies.Items.Clear();
            foreach (RentalItem m in movies)
            {
                lstMovies.Items.Add(m.GetDisplayText());
            }
        }

        // Open NewMovie form and save returned movie object to the list and database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewMovie newMovieForm = new NewMovie();
            RentalItem movie = newMovieForm.GetNewMovie();

            if (movie != null)
            {
                movies.Add(movie);
                MovieDB.SaveMovies(movies);
                FillMovieListBox();
            }

        }

        // When the form loads, fill the list with the movies from the database
        private void frmMaintenance_Load(object sender, EventArgs e)
        {
            movies = MovieDB.GetMovies();
            FillMovieListBox();
        }

        // Delete movie from the list and database and show updated list
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstMovies.SelectedIndex;

            if (index != -1)
            {
                RentalItem movie = (RentalItem)movies[index];
                string message = "Hey, are you sure you want to delete? " + movie.Description + "?";
                DialogResult button = MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    movies.Remove(movie);
                    MovieDB.SaveMovies(movies);
                    FillMovieListBox();
                }
            }
        }

        // Close form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
