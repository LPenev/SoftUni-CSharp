using System.ComponentModel.DataAnnotations;

namespace BookVerse.ViewModels.Book
{
    public class BookCreateInputModel : BookBaseInputModel
    {
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public string PublishedOn { get; set; }
    }
}
