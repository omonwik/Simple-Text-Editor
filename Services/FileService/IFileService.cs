using System.Collections.Generic;
using System.Threading.Tasks;
using TextEditor.Models.DTO;

namespace TextEditor.Services.FileService
{
    public interface IFileService
    {
        void SaveFileToDatabaseAsync(FileDTO file);
        bool IsFileExistsInDatabase(string fileName);
        FileDTO LoadFileFromDatabase(string title);
        FileDTO LoadFileFromDisk(string path);
        List<string> GetAllFilesTitles();
        Task SaveFileToDiskAsync(string text, string path);
        Task<FileDTO> LoadFileFromDatabaseAsync(string title);
        Task<FileDTO> LoadFileFromDiskAsync(string path);
    }
}
