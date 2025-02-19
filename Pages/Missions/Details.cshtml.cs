////////////////////////////////////////////////////////////////
using todolist.Data;
using todolist.Models;
////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
////////////////////////////////////////////////////////////////
namespace todolist.Pages.Missions;
////////////////////////////////////////////////////////////////
public class DetailsModel: PageModel {
    private readonly TodolistContext context;
    public DetailsModel( TodolistContext context ){
        this.context = context;
    }
    public Mission Mission { get; set; }
    public async Task <IActionResult> OnGetAsync( int id ){
        Mission = await context.Missions
        .Include( m => m.Operation )
        .FirstOrDefaultAsync( m => m.Id == id );

        return Mission == null ? NotFound() : Page();
    }
}
////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
