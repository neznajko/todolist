////////////////////////////////////////////////////////////////
using todolist.Models; // Operation, OperationStatus
using todolist.Data; // TodolistContext
////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc; // IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages; // PageModel
using Microsoft.EntityFrameworkCore; // EntityState
////////////////////////////////////////////////////////////////
namespace todolist.Pages.Operations;
////////////////////////////////////////////////////////////////
public class EditModel: PageModel {
    private readonly TodolistContext context;
    public Array Statuses { get; }
    public EditModel( TodolistContext context ){
        this.context = context;
        Statuses = Enum.GetValues( typeof( OperationStatus ));
    }
    // binds the incoming request data to the Operation property
    [BindProperty]
    public Operation Operation { get; set; }
    // OnGet, return the form to be edited
    public async Task <IActionResult> OnGetAsync( int id ){
        Operation = await context.Operations.FindAsync( id );
        return Operation == null ? NotFound() : Page();
    }
    // OnPost, Operation is filled with the incoming request data
    // before entering this funcrion
    public async Task <IActionResult> OnPostAsync() {
        // this is possible becoz of the [BindProperty] attribute
        if( !ModelState.IsValid ){
            return Page();
        }
        context.Attach( Operation ).State = EntityState.Modified;
        await context.SaveChangesAsync();
        // here id should match the @page directive in the Edit page
        return RedirectToPage( "./Details", new { id = Operation.Id });
    }
}
////////////////////////////////////////////////////////////////
