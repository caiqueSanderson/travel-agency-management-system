using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravelAgency.Pages
{
    public class ViewNotesModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public ViewNotesModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        [BindProperty]
        public string? FileName { get; set; }

        [BindProperty]
        public string? Content { get; set; }

        public List<string> NoteFiles { get; set; } = new();
        public string? SelectedFileContent { get; set; }
        public string? SelectedFileName { get; set; }

        public void OnGet(string? fileName)
        {
            LoadNotes();

            if (!string.IsNullOrEmpty(fileName))
            {
                var filePath = Path.Combine(_env.WebRootPath, "files", fileName + ".txt");

                if (System.IO.File.Exists(filePath))
                {
                    SelectedFileContent = System.IO.File.ReadAllText(filePath);
                    SelectedFileName = fileName;
                }
            }
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(FileName) || string.IsNullOrWhiteSpace(Content))
            {
                ModelState.AddModelError(string.Empty, "Nome do arquivo e conteúdo são obrigatórios.");
                LoadNotes();
                return Page();
            }

            var folderPath = Path.Combine(_env.WebRootPath, "files");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, FileName + ".txt");

            System.IO.File.WriteAllText(filePath, Content);

            return RedirectToPage(new { fileName = FileName });
        }

        private void LoadNotes()
        {
            var folderPath = Path.Combine(_env.WebRootPath, "files");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            NoteFiles = Directory.GetFiles(folderPath, "*.txt")
                .Select(Path.GetFileNameWithoutExtension)
                .ToList();
        }
    }
}
