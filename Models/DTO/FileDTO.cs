namespace TextEditor.Models.DTO
{
    public sealed class FileDTO
    {
        public string Title { get; set; }
        public byte[] Content { get; set; }

        public FileDTO() { }

        public FileDTO(string title, byte[] content)
        {
            Title = title;
            Content = content;
        }
    }
}
