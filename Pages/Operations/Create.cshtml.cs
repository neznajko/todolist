////////////////////////////////////////////////////////////////
using todolist.Models;
using todolist.Data;
////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
////////////////////////////////////////////////////////////////
namespace todolist.Pages.Operations;
////////////////////////////////////////////////////////////////
public class CreateModel: PageModel {
    private readonly TodolistContext context;
    public CreateModel( TodolistContext context ){
        this.context = context;
    }
    // binds the incoming request data to the Operation property
    [BindProperty]
    public Operation Operation { get; set; }
    // OnGet, return the form to be filled
    public IActionResult OnGet() {
        Operation = new Operation();
        return Page();
    }
    // OnPost, Operation is filled with the incoming request data
    // before entering this funcrion
    public async Task <IActionResult> OnPostAsync() {
        // this is possible becoz of the [BindProperty] attribute
        if( !ModelState.IsValid ){
            return Page();
        }
        context.Operations.Add( Operation );
        await context.SaveChangesAsync();
        // here id should match the @page directive in the Create page
        return RedirectToPage( "./Details", new { id = Operation.Id });
    }
}
////////////////////////////////////////////////////////////////
