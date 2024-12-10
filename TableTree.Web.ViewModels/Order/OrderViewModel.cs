using System.ComponentModel.DataAnnotations;
using static TableTree.Common.EntityValidationContants.Order;

namespace TableTree.Web.ViewModels.Order
{
    public class OrderViewModel
    {
        public string UserId { get; set; }
        [MinLength(FistNameMinLength, ErrorMessage = "The {0} length must be more than {1}")]
        [MaxLength(FirstNameMaxLength, ErrorMessage = "The {0} cannot be more than {1}")]
        public string FirstName { get; set; } //NEW
        [MinLength(LastNameMinLength, ErrorMessage = "The {0} length must be more than {1}")]
        [MaxLength(LastNameMaxLength, ErrorMessage = "The {0} cannot be more than {1}")]
        public string LastName { get; set; } //NEW
        [MinLength(PhoneNumberMinLength, ErrorMessage = "Make sure the phone number is correct")]
        [MaxLength(PhoneNumberMaxLength, ErrorMessage = "Phone number must be less than {1}")]
        public string PhoneNumber { get; set; } //NEW
        [MinLength(ShippingCityMinLength, ErrorMessage = "Make sure address is correct")]
        [MaxLength(ShippingCityMaxLength, ErrorMessage = "Make sure address is correct")]
        public string? ShippingCity { get; set; } //NEW
        [MinLength(ShippingAddressMinLength, ErrorMessage = "Make sure address is correct")]
        [MaxLength(ShippingAddressMaxLength, ErrorMessage = "Make sure address is correct")]
        public string? ShippingAddress { get; set; } //NEW
		public string DeliveryMethod { get; set; } // NEW
		public string OrderId { get; set; }
        public int SequenceNumber { get; set; }
        public string OrderDate { get; set; }
        public string TotalPrice { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}
