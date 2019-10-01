using System.ComponentModel.DataAnnotations;

namespace TextEditor
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Content { get; set; }

        public File() {}

        public File(string title, byte[] content)
        {
            Title = title;
            Content = content;
        }
    }
}
