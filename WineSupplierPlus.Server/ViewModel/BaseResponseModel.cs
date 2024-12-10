namespace WineSupplierPlus.Server.ViewModel
{
    public class BaseResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }=string.Empty;
        public object Data { get; set; } = null!;
    }
}
