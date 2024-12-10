using WineSupplierPlus.Server.Model;

namespace WineSupplierPlus.Server.ViewModel
{
    public class AllVineyardViewModel
    {
        public int Count {  get; set; }
        public List<Vineyard> vineyards { get; set; }
        public AllVineyardViewModel(int c,List<Vineyard> v) { 
        this.Count                = c;
            this.vineyards = v;
        }
    }
}
