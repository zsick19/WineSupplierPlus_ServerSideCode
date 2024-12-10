namespace WineSupplierPlus.Server.Model
{
    public class Vineyard
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Continent { get; set; }
        public string? Region {  get; set; }

        //coordinates 
        //public double[] Coordinates {get;set;}

        //public DateOnly? FoundingDate { get; set; }
       // public List<string>? Themes { get; set; }

    }
}
