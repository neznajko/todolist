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
    //
    public Assignment Assignment { get; set; }
    public Mission Mission { get; set; }
    public Operation Operation { get; set; }
    public async Task <IActionResult> OnGetAsync( int id ){
        Assignment = await context.Assignments.FindAsync( id );
        if( Assignment == null ) return NotFound();
        Mission = await context.Missions.FindAsync( Assignment.MissionId );
        Operation = await context.Operations.FindAsync( Mission.OperationId );
        return Page();
    }
}
////////////////////////////////////////////////////////////////
