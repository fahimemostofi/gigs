using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> UpComingGigs { get; set; }
        public bool ShowActions { get; set; }
    }
}