using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace XE908.Pages.Admin.Controllers;
[Authorize(Roles = "Administrator")]
public class IndexModel : PageModel
{
    public void OnGet(string controllerId)
    {
    }
}