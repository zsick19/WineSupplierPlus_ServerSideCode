using WineSupplierPlus.Server.Model;

namespace WineSupplierPlus.Server.ViewModel
{
    public class DetailedVineyardViewModel
    {
        public Vineyard Vineyard { get; set; }

        public DetailedVineyardViewModel(Vineyard v)
        {
            this.Vineyard = v;    
        }
    }
}
