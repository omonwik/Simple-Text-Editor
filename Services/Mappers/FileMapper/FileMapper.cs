using TextEditor.Models.DTO;

namespace TextEditor.Services.Mappers.FileMapper
{
    public class FileMapper : IMapper<File, FileDTO>
    {
        public File Map(FileDTO obj)
        {
            return new File(obj.Title, obj.Content);
        }

        public FileDTO Map(File obj)
        {
            return new FileDTO(obj.Title, obj.Content);
        }
    }
}
