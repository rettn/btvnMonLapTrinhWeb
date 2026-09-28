using Microsoft.AspNetCore.Mvc;
using codeDemoSession7.Models.DataModels;
using System.Text.RegularExpressions;
namespace codeDemoSession7.Controllers
{
    public class MemberController : Controller
    {
        public static readonly List<Member> members = new List<Member>();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Member());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Member member)
        {
            string msg = "";
            bool validate = true;

            if (string.IsNullOrWhiteSpace(member.UserName) ||
                member.UserName.Length < 3 || member.UserName.Length > 20)
            {
                msg += "<li>Tên đăng nhập phải có độ dài từ 3 - 20 kí tự</li>";
                validate = false;
            }

            string patternEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (string.IsNullOrWhiteSpace(member.Email) ||
                !Regex.IsMatch(member.Email, patternEmail))
            {
                msg += "<li>Email không đúng định dạng</li>";
                validate = false;
            }

            if (member.Birthday.AddYears(18) > DateTime.Now)
            {
                msg += "<li>Bạn chưa đủ 18 tuổi</li>";
                validate = false;
            }

            string patternPhone = @"^0\d{9,12}$";
            if (string.IsNullOrWhiteSpace(member.Phone) ||
                !Regex.IsMatch(member.Phone, patternPhone))
            {
                msg += "<li>Số điện thoại không hợp lệ</li>";
                validate = false;
            }

            if (validate)
            {
                member.MemberId = Guid.NewGuid().ToString();
                members.Add(member);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.msg = $"<div class='alert alert-danger'><ul class='mb-0'>{msg}</ul></div>";
            return View(member);
        }
    }
}
