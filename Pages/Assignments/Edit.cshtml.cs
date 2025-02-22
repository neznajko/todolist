using todolist.Data;
using todolist.Models;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace todolist.Pages.Assignments;
class EditModel: PageModel{
    private readonly TodolistContext context;
    public EditModel( TodolistContext context ){
        this.context = context;
    }
    [BindProperty]
    public Assignment Assignment { get; set; }
    public async Task <IActionResult> OnGetAsync( int id ){
        Assignment = await context.Assignments.FindAsync( id );
        return Assignment == null ? NotFound() : Page();
    }
    public async Task <IActionResult> OnPostAsync() {
        if( !ModelState.IsValid ){
            return Page();
        }
        context.Attach( Assignment ).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return RedirectToPage( "/Assignments/Details", new { id = Assignment.Id });
    }
}