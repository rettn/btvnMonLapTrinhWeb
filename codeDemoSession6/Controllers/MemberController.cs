//using Microsoft.AspNetCore.Mvc;
//using codeDemoSession6.Models.DataModels;
//namespace codeDemoSession6.Controllers
//{
//    public class MemberController : Controller
//    {
//        public IActionResult Index()
//        {
//            //Tao doi duong Member
//            var member = new Member();

//            //Gan du lieu
//            member.MemberId = Guid.NewGuid().ToString();
//            member.Username = "nguyentrongtan";
//            member.Password = "241230839";
//            member.Fullname = "Nguyen Trong Tan";
//            member.Email = "trongtan20061224@gmail.com";

//            //Truyen doi tuong sang view
//            return View(member);
//        }
//        public IActionResult GetMembers ()
//        {
//            List<Member> members = new List<Member>()
//            {
//                new Member
//                {
//                    MemberId = Guid.NewGuid().ToString(),
//                    Username = "member1",
//                    Fullname = "Member 1",
//                    Password = "password1",
//                    Email = "nt1@gmail.com",
//                },

//                new Member
//                {
//                    MemberId = Guid.NewGuid().ToString(),
//                    Username = "member2",
//                    Fullname = "Member 2",
//                    Password = "password2",
//                    Email = "nt2@gmail.com",
//                },

//                new Member
//                {
//                    MemberId = Guid.NewGuid().ToString(),
//                    Username = "member3",
//                    Fullname = "Member 3",
//                    Password = "password3",
//                    Email = "nt3@gmail.com",
//                },

//                new Member
//                {
//                    MemberId = Guid.NewGuid().ToString(),
//                    Username = "member4",
//                    Fullname = "Member 4",
//                    Password = "password4",
//                    Email = "nt4@gmail.com",
//                },

//                new Member
//                {
//                    MemberId = Guid.NewGuid().ToString(),
//                    Username = "member5",
//                    Fullname = "Member 5",
//                    Password = "password5",
//                    Email = "nt5@gmail.com",
//                }
//            };

//            ViewBag.Members = members;
//            return View();  

//        }

//        public static readonly List<Member> members = new List<Member>()
//        {
//            new Member
//            {
//                MemberId = Guid.NewGuid().ToString(),
//                Username = "member1",
//                Fullname = "Thanh vien 1",
//                Password = "123456",
//                Email = "nt1@gmail.com"
//            },

//            new Member
//            {
//                MemberId = Guid.NewGuid().ToString(),
//                Username = "member2",
//                Fullname = "Thanh vien 2",
//                Password = "123456",
//                Email = "nt2@gmail.com"
//            },

//            new Member
//            {
//                MemberId = Guid.NewGuid().ToString(),
//                Username = "member3",
//                Fullname = "Thanh vien 3",
//                Password = "123456",
//                Email = "nt3@gmail.com"
//            },

//            new Member
//            {
//                MemberId = Guid.NewGuid().ToString(),
//                Username = "member4",
//                Fullname = "Thanh vien 4",
//                Password = "123456",
//                Email = "nt4@gmail.com"
//            },

//            new Member
//            {
//                MemberId = Guid.NewGuid().ToString(),
//                Username = "member5",
//                Fullname = "Thanh vien 5",
//                Password = "123456",
//                Email = "nt5@gmail.com"
//            }
//        };

//        public IActionResult Create()
//        {
//            return View();
//        }

//    }

//}
using codeDemoSession6.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Example04.Controllers
{
    public class MemberController : Controller
    {
        private static readonly List<Member> members = new List<Member>()
        {
            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member1",
                Fullname = "Thanh vien 1",
                Password = "123456",
                Email = "nt1@gmail.com"
            },

            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member2",
                Fullname = "Thanh vien 2",
                Password = "123456",
                Email = "nt2@gmail.com"
            },

            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member3",
                Fullname = "Thanh vien 3",
                Password = "123456",
                Email = "nt3@gmail.com"
            },

            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member4",
                Fullname = "Thanh vien 4",
                Password = "123456",
                Email = "nt4@gmail.com"
            },

            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member5",
                Fullname = "Thanh vien 5",
                Password = "123456",
                Email = "nt5@gmail.com"
            }
        };

        // GET: /Member/GetMembers
        public IActionResult GetMembers()
        {
            ViewBag.members = members;

            return View();
        }

        // GET: /Member/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Member/Create
        [HttpPost]
        public IActionResult Create(Member member)
        {
            member.MemberId = Guid.NewGuid().ToString();

            members.Add(member);

            return RedirectToAction("GetMembers");
        }

        // GET: Member/Delete/id
        public IActionResult Delete(string id)
        {
            var member = members.FirstOrDefault(m => m.MemberId == id);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Member/DeleteConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string MemberId)
        {
            var member = members.FirstOrDefault(m => m.MemberId == MemberId);

            if (member == null)
            {
                return NotFound();
            }

            members.Remove(member);

            return RedirectToAction("GetMembers");
        }

    }
}