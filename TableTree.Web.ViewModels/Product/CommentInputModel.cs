using TableTree.Data.Models;

namespace TableTree.Web.ViewModels.Product
{
	public class CommentInputModel
	{
		public string CommentDescription { get; set; }
		public Guid	ApplicationUserId { get; set; }
		public Guid ProductId { get; set; }
	}
}
