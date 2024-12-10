using System.ComponentModel.DataAnnotations;

namespace WineSupplierPlus.Server.ViewModel
{
    public class AddVineyardViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }

        ////coordinates 
        ////public double[] Coordinates {get;set;}

       // public DateOnly FoundingDate { get; set; }
        //public List<string> Themes { get; set; }





    }
}
