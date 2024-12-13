﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProgrammingFinal2024.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingFinal2024.Pages
{
    public class ProjectModel : PageModel
    {
        private readonly ApplicationDbContext _context;
            private readonly ILogger<ProjectModel> _logger;


        public ProjectModel(ApplicationDbContext context, ILogger<ProjectModel> logger)
        {
            _context = context;
                    _logger = logger;        

        }

        public IList<Project> Projects { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Projects = await _context.Projects.ToListAsync();
            return Page();
        }

        [BindProperty]
        public int ProjectID { get; set; }

        public async Task<IActionResult> OnPostSaveAsync()
        {
            var user = await _context.Users.Include(u => u.ParticipatingProjects).FirstOrDefaultAsync(u => u.UserID == 1); // Assuming user with ID 1 is logged in
            var project = await _context.Projects.FindAsync(ProjectID);

            if (user != null && project != null)
            {
                user.ParticipatingProjects.Add(project);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}