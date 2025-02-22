using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using todolist.Data;
using todolist.Models;

namespace todolist.Pages.Assignments;

public class CreateModel: PageModel {
    private readonly TodolistContext context;
    public CreateModel( TodolistContext context ){
        this.context = context;
    }
    [BindProperty]
    public Assignment Assignment { get; set; }
    public IActionResult OnGet( int missionId ){
        Assignment = new Assignment
        {
            MissionId = missionId
        };
        return Page();
    }
    public async Task <IActionResult> OnPostAsync() {
        if( !ModelState.IsValid ){
            return Page();
        }
        context.Assignments.Add( Assignment );
        await context.SaveChangesAsync();
        return RedirectToPage( "/Missions/Details", new { id = Assignment.MissionId });
    }
}