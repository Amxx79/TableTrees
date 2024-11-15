using TableTree.Web.ViewModels.Store;

namespace TableTree.Web.ViewModels.Product
{
    public class AddProductToStoreViewModel
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public IList<CheckboxInputModel> Locations { get; set; } = new List<CheckboxInputModel>();
    }
}
