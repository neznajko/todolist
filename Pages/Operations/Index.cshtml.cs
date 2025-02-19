////////////////////////////////////////////////////////////////
using todolist.Data;
using todolist.Models;
////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
////////////////////////////////////////////////////////////////
namespace todolist.Pages.Operations;
////////////////////////////////////////////////////////////////
public class IndexModel: PageModel {
    private readonly TodolistContext context;

    public IndexModel( TodolistContext context ){
        this.context = context;
    }
    public IList <Operation> Operations { get; set; }

    public async Task OnGetAsync() {
        // Query all operations with their missions
        Operations = await context.Operations
        .Include( o => o.Missions )
        .ToListAsync(); // convert DbSet to List
    }
}
////////////////////////////////////////////////////////////////
