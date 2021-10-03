using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanLateFeeCalc
{
    public class RentalItem
    {
        //object fields
        private int movieNo;
        private string description;
        private string rating;

        // Constructors

        // No-argument constructor
        public RentalItem()
        {
            this.MovieNo = 0;
            this.Description = "TBD";
            this.Rating = "TBD";
        }

        // Constructor with arguments
        public RentalItem(int movieNo, string description, string rating)
        {
            this.MovieNo = movieNo;
            this.Description = description;
            this.Rating = rating;
        }

        // Methods
        // Returns a string of the concatenated object fields
        public string GetDisplayText()
        {
            return MovieNo + "    " + Description + " " + Rating;
        }
        public string GetDisplayText(string sep)
        {
            return MovieNo + sep + Rating + sep + Description;
        }

        // Accessors and Mutators
        public int MovieNo
        {
            get { return movieNo; }
            set { movieNo = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Rating
        {
            get { return rating; }
            set { rating = value; }
        }
    }
}
