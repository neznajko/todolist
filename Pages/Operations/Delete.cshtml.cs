////////////////////////////////////////////////////////////
using todolist.Models; // Operation
using todolist.Data; // TodolistContext
////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc; // IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages; // PageModel
////////////////////////////////////////////////////////////
namespace todolist.Pages.Operations;
////////////////////////////////////////////////////////////
class DeleteModel: PageModel {
    private readonly TodolistContext context;
    public DeleteModel( TodolistContext context ){
        this.context = context;
    }
    public Operation Operation { get; set; }
    public async Task <IActionResult> OnGetAsync( int id ){
        Operation = await context.Operations.FindAsync( id );
        return Operation == null ? NotFound() : Page();
    }
    public async Task <IActionResult> OnPostAsync( int id ){
        Operation = await context.Operations.FindAsync( id );
        if( Operation == null ){
            return NotFound();
        }
        context.Operations.Remove( Operation );
        await context.SaveChangesAsync();
        return RedirectToPage( "/Operations/Index" );
    }
}
////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////
