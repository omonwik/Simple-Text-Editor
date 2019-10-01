using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using TextEditor.Models.DTO;
using TextEditor.Services.Mappers;
using IOFile = System.IO.File;

namespace TextEditor.Services.FileService
{
    public sealed class FileService : IFileService
    {
        public readonly AppContext _context;
        private readonly IMapper<File, FileDTO> _mapper;

        public FileService(IMapper<File, FileDTO> mapper, AppContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<string> GetAllFilesTitles()
        {
            return _context.Files.Select(f => f.Title).ToList();
        }

        public FileDTO LoadFileFromDatabase(string fileName)
        {
            var file = GetFileByName(fileName);
            var dto = _mapper.Map(file);

            DecompressFileContent(dto);
            return dto;
        }

        public Task<FileDTO> LoadFileFromDatabaseAsync(string title)
        {
            return new TaskFactory().StartNew(() => LoadFileFromDatabase(title));
        }

        public FileDTO LoadFileFromDisk(string path)
        {
            var info = new FileInfo(path);
            var content = IOFile.ReadAllBytes(info.FullName);

            return new FileDTO(info.Name, content);
        }

        public Task<FileDTO> LoadFileFromDiskAsync(string path)
        {
            return new TaskFactory().StartNew(() => LoadFileFromDisk(path));
        }

        private void CompressAndSave(FileDTO dto)
        {
            CompressFileContent(dto);
            var fileExists = IsFileExistsInDatabase(dto.Title);
            File file;

            if (fileExists)
            {
                file = GetFileByName(dto.Title);
                file.Content = dto.Content;
            }
            else
            {
                file = _mapper.Map(dto);
                _context.Files.Add(file);
            }

            _context.SaveChanges();
        }

        public void SaveFileToDatabaseAsync(FileDTO dto)
        {
            new TaskFactory().StartNew(() => CompressAndSave(dto));
        }

        public void SaveFileToDisk(string text, string path)
        {
            IOFile.WriteAllText(path, text);
        }

        public Task SaveFileToDiskAsync(string text, string path)
        {
            return new TaskFactory().StartNew(() => SaveFileToDisk(text, path));
        }

        private void CompressFileContent(FileDTO dto)
        {
            var memory = new MemoryStream();
            using (var gzip = new GZipStream(memory, CompressionMode.Compress, true))
            {
                gzip.Write(dto.Content, 0, dto.Content.Length);
            }

            dto.Content = memory.ToArray();
        }

        private void DecompressFileContent(FileDTO dto)
        {
            using (var gzip = new GZipStream(new MemoryStream(dto.Content), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = gzip.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    dto.Content = memory.ToArray();
                }
            }
        }

        public bool IsFileExistsInDatabase(string fileName)
        {
            return GetFileByName(fileName) != null;
        }

        private File GetFileByName(string fileName)
        {
            return _context.Files.FirstOrDefault(file => file.Title.Trim() == fileName.Trim());
        }
    }
}
