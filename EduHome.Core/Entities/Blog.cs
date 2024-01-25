using EduHome.Core.Entities.BaseEntites;
namespace EduHome.Core.Entities
{
    public class Blog : BaseEntity
    {
        public string Image { get; set; }
        public string Desc { get; set; }
        public string Title { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;

        //public int AuthorId { get; set; }
        //public Author Author { get; set; }

        public List<Comment> Comments { get; set; }
        public List<TagBlog> TagBlogs { get; set; } 
        

        public bool Okay { get; set; }

    }
}