////////////////////////////////////////////////////////////////
using todolist.Models;
using todolist.Data;
////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
////////////////////////////////////////////////////////////////
namespace todolist.Pages.Missions;
////////////////////////////////////////////////////////////////
public class EditModel: PageModel
{
    private readonly TodolistContext context;
    public EditModel( TodolistContext context ){
        this.context = context;
    }
    [BindProperty]
    public Mission Mission { get; set; }
    public async Task <IActionResult> OnGetAsync( int id ){
        Mission = await context.Missions.FindAsync( id );
        return Mission == null ? NotFound() : Page();
    }
    public async Task <IActionResult> OnPostAsync() {
        if( !ModelState.IsValid ){
            return Page();
        }
        context.Attach( Mission ).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return RedirectToPage( "/Operations/Details", new { id = Mission.OperationId });
    }
}
////////////////////////////////////////////////////////////////