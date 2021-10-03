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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        // This creates a new instance of the New Releases form 
        frmNew NewReleases = new frmNew();

        // This creates a new instance of the Kids Movies form 
        frmKids KidsMovies = new frmKids();

        // This creates a new instance of the Library Titles form 
        frmLibrary LibraryTitles = new frmLibrary();

        // This creates a new instance of the Maintenance form 
        frmMaintenance RentalMaintenance = new frmMaintenance();

        // Initialize late fee for each movie type to be 0
        double libraryLateFees = 0;
        double newReleasesLateFees = 0;
        double kidsLateFees = 0;

        private void btnNew_Click(object sender, EventArgs e)
        {
            //NewReleases.ShowDialog(); // Displays the created instance of the New Releases form

            // Displays the created instance of the New Releases form
            DialogResult selectedButton = NewReleases.ShowDialog();
            // Add calculated late fee and display the result if the user clicks on Ok
            if (selectedButton == DialogResult.OK)
            {
                newReleasesLateFees = Convert.ToDouble(NewReleases.Tag);
                CalculateLateFees();
            }
        }

        private void btnLibrary_Click(object sender, EventArgs e)
        {
            //LibraryTitles.ShowDialog(); // Displays the created instance of the Library Titles form

            // Displays the created instance of the New Releases form
            DialogResult selectedButton = LibraryTitles.ShowDialog();
            // Add calculated late fee and display the result if the user clicks on Ok
            if (selectedButton == DialogResult.OK)
            {
                libraryLateFees = Convert.ToDouble(LibraryTitles.Tag);
                CalculateLateFees();
            }
        }

        private void btnKids_Click(object sender, EventArgs e)
        {
            //KidsMovies.ShowDialog(); // Displays the created instance of the Kids Movies form

            // Displays the created instance of the New Releases form
            DialogResult selectedButton = KidsMovies.ShowDialog();
            // Add calculated late fee and display the result if the user clicks on Ok
            if (selectedButton == DialogResult.OK)
            {
                kidsLateFees = Convert.ToDouble(KidsMovies.Tag);
                CalculateLateFees();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Calculate the total late fee from each type of movie and display to the main form
        private void CalculateLateFees()
        {
            double totalLateFee = libraryLateFees + newReleasesLateFees + kidsLateFees;
            lblTotalLateFee.Text = totalLateFee.ToString("c");
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            RentalMaintenance.ShowDialog(); // Displays the created instance of the Rental Maintenance form
        }
    }
}
