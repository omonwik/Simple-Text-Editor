using SimpleInjector;
using TextEditor.Models.DTO;
using TextEditor.Services.FileService;
using TextEditor.Services.Mappers;
using TextEditor.Services.Mappers.FileMapper;

namespace TextEditor.Infrastructure
{
    public static class SimpleInjectorConfig
    {
        private static Container container;

        public static Container Container
        {
            get { return container; } private set { }
        }

        public static void Bootstrap()
        {
            container = new Container();

            container.Register<MainForm>(Lifestyle.Singleton);
            container.Register<SelectFileForm>(Lifestyle.Singleton);
            container.Register<InputBoxForm>(Lifestyle.Singleton);

            container.Register<AppContext>(Lifestyle.Singleton);
            container.Register<IFileService, FileService>(Lifestyle.Singleton);

            container.Register<IMapper<File, FileDTO>, FileMapper>(Lifestyle.Singleton);

            container.Verify();
        }
    }
}
