using MyEBook.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MyEBook.Models.Entities
{
    public class Book : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int LikeNumber { get; set; }

        public void AddLike()
        {
            LikeNumber++;
        }
        public void MinusLike()
        {
            LikeNumber--;
        }

    }
}
