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
        Operations = await context.Operations.ToListAsync();
    }
}
////////////////////////////////////////////////////////////////
