namespace TableTree.Data.Models
{
	public class Comment
	{
		public Guid Id { get; set; }
		public string CommentDescription { get; set; }
		public DateTime PostedOn { get; set; }
		public Guid ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		public Guid ProductId { get; set; }
		public Product Product { get; set; }
	}
}
