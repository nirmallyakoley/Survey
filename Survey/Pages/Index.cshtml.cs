using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Survey.Data;
using Survey.Models;

namespace Survey.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Survey.Data.SurveyContext _context;
        public string[] AWSExperience = new[] { "Yes", "No" };

        [BindProperty]
        public SurveyBO SurveyBO { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public IndexModel(ILogger<IndexModel> logger, Survey.Data.SurveyContext context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            //SurveyBO = new SurveyBO {AWSProjectExperience= "Yes"};
        }
        public async Task<IActionResult> OnPostAsync()
         {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Referrer"] = "";
                    return Page();
                }
                SurveyBO.UserID = "nirmallya.kolay@infosys.com";
                _context.SurveyBO.Add(SurveyBO);
                 await _context.SaveChangesAsync();
                TempData["Referrer"] = "SaveRegister";
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
            return RedirectToPage("./Index");
        }
    }
}
