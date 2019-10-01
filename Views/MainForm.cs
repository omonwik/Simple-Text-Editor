using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TextEditor.Infrastructure;
using TextEditor.Models.DTO;
using TextEditor.Services.FileService;

namespace TextEditor
{
    public partial class MainForm : Form
    {
        private readonly IFileService _fileService;
        private readonly InputBoxForm _inputBoxForm;
        private readonly SelectFileForm _selectFileForm;

        public MainForm(IFileService fileService, InputBoxForm inputBoxForm, SelectFileForm selectFileForm)
        {
            _selectFileForm = selectFileForm;
            _inputBoxForm = inputBoxForm;
            _fileService = fileService;

            InitializeComponent();
        }

        private void SaveFileToDatabase(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MainText.Text))
            {
                MessageBox.Show(ConfigurationHelper.Get("EmptyFileErrorMessage"),
                                ConfigurationHelper.Get("EmptyFileErrorTitle"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            var result = _inputBoxForm.ShowDialog();
            if (result == DialogResult.Cancel) return;

            var fileName = _inputBoxForm.SelectedFileName;

            var title = new FileInfo(fileName).Name;
            var content = Encoding.UTF8.GetBytes(MainText.Text);
            var fileDTO = new FileDTO(title, content);

            Text = fileName;
            _fileService.SaveFileToDatabaseAsync(fileDTO);
        }

        private void LoadFileFromDatabase(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            var result = _selectFileForm.ShowDialog();
            if (result != DialogResult.OK)
            {
                Cursor = Cursors.Default;
                return;
            } 
            
            var fileName = _selectFileForm.SelectedFileName;
            var task = _fileService.LoadFileFromDatabaseAsync(fileName);

            Text = fileName;
            var file = task.Result;
            MainText.Text = Encoding.UTF8.GetString(file.Content);
            Cursor = Cursors.Default;
        }

        private void LoadFileFromDisk(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var openFileDialog = new OpenFileDialog
            {
                Filter = ConfigurationHelper.Get("FileDialogFilter")
            };
            var showResult = openFileDialog.ShowDialog();

            if (showResult != DialogResult.OK)
            {
                Cursor = Cursors.Default;
                return;
            }
                
            var name = openFileDialog.FileName;
            var task = _fileService.LoadFileFromDiskAsync(name);
            
            Text = name;
            var file = task.Result;
            MainText.Text = Encoding.UTF8.GetString(file.Content);
            Cursor = Cursors.Default;
        }

        private void SaveFileToDisk(object sender, EventArgs e)
        {
            var text = MainText.Text;

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show(ConfigurationHelper.Get("SaveFileErrorMessage"),
                                ConfigurationHelper.Get("SaveFileErrorTitle"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            var saveDialog = new SaveFileDialog
            {
                Filter = ConfigurationHelper.Get("FileDialogFilter")
            };

            Cursor = Cursors.WaitCursor;
            var result = saveDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                Cursor = Cursors.Default;
                return;
            }

            var fileName = saveDialog.FileName;
            Text = fileName;
            Cursor = Cursors.Default;

            _fileService.SaveFileToDiskAsync(text, fileName);
        }
    }
}
