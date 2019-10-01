using System;
using System.Linq;
using System.Windows.Forms;
using TextEditor.Infrastructure;
using TextEditor.Services.FileService;

namespace TextEditor
{
    public partial class SelectFileForm : Form
    {
        public string SelectedFileName { get; set; }
        private readonly IFileService _fileService;

        public SelectFileForm(IFileService fileService)
        {
            _fileService = fileService;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            TitlesListBox.Items.Clear();
            FillListBoxWithDatabaseFileTitles();
        }

        private void OnFileNameSelected(object sender, EventArgs e)
        {
            var fileName = TitlesListBox.SelectedItem as string;
            if (string.IsNullOrEmpty(fileName)) return;

            DialogResult = DialogResult.OK;
            SelectedFileName = fileName;
            Close();
        }

        private void FillListBoxWithDatabaseFileTitles()
        {
            Cursor = Cursors.WaitCursor;
            var items = _fileService.GetAllFilesTitles();
            if (!items.Any())
            {
                MessageBox.Show(ConfigurationHelper.Get("NoFilesInDatabaseInfoMessage"),
                                ConfigurationHelper.Get("NoFilesInDatabaseInfoTitle"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                Close();
            }

            items.ForEach(item => TitlesListBox.Items.Add(item));
            Cursor = Cursors.Default;
        }
    }
}
