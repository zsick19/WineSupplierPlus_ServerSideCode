namespace WineSupplierPlus.Server.Model
{

    //experiment with storing enums in db
    public class WineBottle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GlassColor { get; set; }
        public string SKU { get; set; }
        public string CorkStyle { get; set; }
        public string WineType { get; set; }
        public Vineyard Vineyard { get; set; }
        public DateOnly ProductionDate { get; set; }
        public double WholeSalePrice { get; set; }
        public int ProductionQuantity { get; set; }
        public int Rating { get; set; }


    }
}
