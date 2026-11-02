using lab4ThucHanh.Data;
using lab4ThucHanh.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab4ThucHanh.ViewComponents
{
    public class MajorViewComponent : ViewComponent
    {
        SchoolContext db;
        List<Major> majors;

        public MajorViewComponent(SchoolContext _context)
        {
            db = _context;
            majors = db.Majors.ToList();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(majors);
        }
    }
}