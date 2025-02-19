////////////////////////////////////////////////////////////////
using todolist.Models;
using todolist.Data;
////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
////////////////////////////////////////////////////////////////
namespace todolist.Pages.Missions;
////////////////////////////////////////////////////////////////
public class CreateModel: PageModel {
    private readonly TodolistContext context;
    public CreateModel( TodolistContext context ){
        this.context = context;
    }
    [BindProperty]
    public Mission Mission { get; set; }
    public IActionResult OnGet( int operationId ){
        Mission = new Mission {
            OperationId = operationId
        };
        return Page();
    }
    public async Task <IActionResult> OnPostAsync() {
        if( !ModelState.IsValid ){
            return Page();
        }
        context.Missions.Add( Mission );
        await context.SaveChangesAsync();
        return RedirectToPage( "/Operations/Details", new { id = Mission.OperationId });
    }
} 
////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
