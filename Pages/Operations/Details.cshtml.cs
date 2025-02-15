////////////////////////////////////////////////////////////////
using todolist.Models;
using todolist.Data;
////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
////////////////////////////////////////////////////////////////
namespace todolist.Pages.Operations;
////////////////////////////////////////////////////////////////
public class DetailsModel: PageModel {
    private readonly TodolistContext context;
    public DetailsModel( TodolistContext context ){
        this.context = context;
    }
    public Operation Operation { get; set; }
    public async Task <IActionResult> OnGetAsync( int id ){
        Operation = await context.Operations.FindAsync( id );
        return Operation == null ? NotFound() : Page();
    }
}
////////////////////////////////////////////////////////////////