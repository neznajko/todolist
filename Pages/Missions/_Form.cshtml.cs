////////////////////////////////////////////////////////////////
using todolist.Models;
////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc.RazorPages;
////////////////////////////////////////////////////////////////
namespace todolist.Pages.Missions;
////////////////////////////////////////////////////////////////
public class FormModel: PageModel {
    public Mission Mission { get; set; }
    public string SubmitValue { get; set; }
}
////////////////////////////////////////////////////////////////
