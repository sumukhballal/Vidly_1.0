using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class newviewmodel
    {
        public IEnumerable<MembershipType> MembershipTypes;
        public Customer customer { get; set; }
        public Movie movie { get; set; }
        public IEnumerable<Genre> genre { get; set; }
        public string MovieTitle
        {
            get
            {
                if (movie != null && movie.MovieId != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }

            public string CustomerTitle
        {
            get
            {
                if (customer != null && customer.CustomerId != 0)
                    return "Edit Customer";

                return "New Customer";


            }

        }
    }
}