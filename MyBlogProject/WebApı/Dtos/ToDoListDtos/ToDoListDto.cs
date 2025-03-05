namespace MyBlogProject.WebApı.Dtos.ToDoListDtos
{
    public class ToDoListDto
    {
        public int ToDoListId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
