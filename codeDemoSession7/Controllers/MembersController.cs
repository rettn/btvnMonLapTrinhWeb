using codeDemoSession7.Models.DataModels;
using codeDemoSession7.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace codeDemoSession7.Controllers
{
    public class MembersController : Controller
    {   
        public static readonly List<Member> members = new List<Member>(); 
        public IActionResult Index()
        {   
            return View();
        }

        public IActionResult Create ()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                Member m = new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    UserName = register.UserName,
                    FullName = register.FullName,
                    Email = register.Email,
                    Password = register.Password,
                    Phone = register.Phone,
                    Birthday = register.BirthDay,
                };

                members.Add(m);
                return RedirectToAction("Index");
            }
            else
            {
                return View(register);
            }
        }
    }
}
