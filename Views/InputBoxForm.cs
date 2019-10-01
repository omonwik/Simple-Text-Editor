using System;
using System.Windows.Forms;
using TextEditor.Infrastructure;
using TextEditor.Services.FileService;

namespace TextEditor
{
    public partial class InputBoxForm : Form
    {
        public string SelectedFileName { get; set; }
        private readonly IFileService _fileService;

        public InputBoxForm(IFileService fileService)
        {
            InitializeComponent();
            _fileService = fileService;
        }

        private void OnButtonOkClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FileNameTextbox.Text))
            {
                MessageBox.Show(ConfigurationHelper.Get("FileNameNotEnteredExceptionMessage"),
                                ConfigurationHelper.Get("Название не выбрано"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            var fileExists = _fileService.IsFileExistsInDatabase(FileNameTextbox.Text);
            if (fileExists)
            {
                var result = MessageBox.Show(ConfigurationHelper.Get("FileWithEnteredNameAlreadyExistsMessage"),
                                             ConfigurationHelper.Get("FileWithEnteredNameAlreadyExistsTitle"),
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
            }

            SelectedFileName = FileNameTextbox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FileNameTextbox.Clear();
        }
    }
}
