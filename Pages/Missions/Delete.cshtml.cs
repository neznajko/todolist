////////////////////////////////////////////////////////////////
using todolist.Models;
using todolist.Data;
////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
////////////////////////////////////////////////////////////////
namespace todolist.Pages.Missions;
////////////////////////////////////////////////////////////////
public class DeleteModel: PageModel {
    private readonly TodolistContext context;
    public DeleteModel(TodolistContext context) {
        this.context = context;
    }
    [BindProperty]
    public Mission Mission { get; set; }
    public async Task<IActionResult> OnGetAsync(int id) {
        Mission = await context.Missions.FindAsync(id);
        return Mission == null ? NotFound() : Page();
    }
    public async Task<IActionResult> OnPostAsync(int id) {
        Mission = await context.Missions.FindAsync(id);
        if( Mission == null ) return NotFound();
        int operationId = Mission.OperationId;
        context.Missions.Remove(Mission);
        await context.SaveChangesAsync();
        return RedirectToPage("/Operations/Details", new { id = operationId });
    }
}
////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
