////////////////////////////////////////////////////////////////
using todolist.Data;
using todolist.Models;
////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
////////////////////////////////////////////////////////////////
namespace todolist.Pages.Assignments;
////////////////////////////////////////////////////////////////
public class DetailsModel: PageModel {
    private readonly TodolistContext context;
    public DetailsModel( TodolistContext context ){
        this.context = context;
    }
    public Assignment Assignment { get; set; }
    // OnGet
    public async Task <IActionResult> OnGetAsync( int id ){
        Assignment = await context.Assignments.FindAsync( id );
        return Assignment == null ? NotFound() : Page();
    }
}
////////////////////////////////////////////////////////////////
