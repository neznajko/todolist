////////////////////////////////////////////////////////////////
using todolist.Models;
////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc.RazorPages;
////////////////////////////////////////////////////////////////
namespace todolist.Pages.Operations;
////////////////////////////////////////////////////////////////
public class FormModel: PageModel {
    public Operation Operation { get; set; }
    public string SubmitValue { get; set; }
}
////////////////////////////////////////////////////////////////
