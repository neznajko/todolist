////////////////////////////////////////////////////////////////
using todolist.Models;
using todolist.Data;
////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        // This creates a JOIN query to get the Operation 
        // and its Missions
        Operation = await context.Operations
            .Include( o => o.Missions )
            .FirstOrDefaultAsync( o => o.Id == id );
        return Operation == null ? NotFound() : Page();
    }
}
////////////////////////////////////////////////////////////////