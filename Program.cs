using System;
using System.Windows.Forms;
using SimpleInjector;
using TextEditor;
using TextEditor.Infrastructure;
using TextEditor.Services.FileService;

static class Program
{
    [STAThread]
    static void Main()
    {

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        SimpleInjectorConfig.Bootstrap();
        Application.Run(SimpleInjectorConfig.Container.GetInstance<MainForm>());
    }
}