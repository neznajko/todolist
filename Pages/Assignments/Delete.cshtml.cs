////////////////////////////////////////////////////////////////
using todolist.Models;
using todolist.Data;
////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
////////////////////////////////////////////////////////////////
namespace todolist.Pages.Assignments;
////////////////////////////////////////////////////////////////
public class DeleteModel: PageModel {
    private readonly TodolistContext context;
    public DeleteModel(TodolistContext context) {
        this.context = context;
    }
    [BindProperty]
    public Assignment Assignment { get; set; }
    public async Task<IActionResult> OnGetAsync(int id) {
        Assignment = await context.Assignments.FindAsync(id);
        return Assignment == null ? NotFound() : Page();
    }
    public async Task<IActionResult> OnPostAsync(int id) {
        Assignment = await context.Assignments.FindAsync(id);
        if( Assignment == null ) return NotFound();
        int missionId = Assignment.MissionId;
        context.Assignments.Remove(Assignment);
        await context.SaveChangesAsync();
        return RedirectToPage("/Missions/Details", new { id = missionId });
    }
}
////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////