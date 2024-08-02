
using LModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Course_Overview.Data;
using Microsoft.EntityFrameworkCore;
using Course_Overview.Helper;
using LModels.ExModel;

namespace Course_Overview.Controllers
{
	public class AccountController : Controller
	{
		private readonly DatabaseContext _context;

		public AccountController(DatabaseContext context)
		{
			_context = context;
		}

		// Đăng ký
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(Student student, IFormFile imageFile)
		{
			if (ModelState.IsValid)
			{
				// Kiểm tra xem email đã tồn tại chưa
				var emailExisting = await _context.Students.AnyAsync(s => s.Email == student.Email);
				if (emailExisting)
				{
					ModelState.AddModelError("Email", "Email already exists.");
					return View(student);
				}

				// Kiểm tra xem số điện thoại đã tồn tại chưa
				var phoneExisting = await _context.Students.AnyAsync(s => s.Phone == student.Phone);
				if (phoneExisting)
				{
					ModelState.AddModelError("Phone", "Phone already exists.");
					return View(student);
				}

				// Xử lý ảnh nếu có
				if (imageFile != null && imageFile.Length > 0)
				{
					var subFolder = "StudentImages";
					var saveImagePath = await UploadFile.SaveImage(subFolder, imageFile);
					student.ImagePath = saveImagePath;
				}

				// Thêm sinh viên vào cơ sở dữ liệu
				_context.Students.Add(student);
				await _context.SaveChangesAsync();
				var student1 = new ClassStudent();

				// Thêm liên kết sinh viên và lớp học
				student1.StudentID = student.StudentID;
				student1.ClassID = 1;  // Đảm bảo rằng lớp học với ID = 1 tồn tại trong cơ sở dữ liệu
				_context.ClassStudents.Add(student1);  // Cần thêm dòng này để thêm bản ghi vào bảng ClassStudents
				await _context.SaveChangesAsync();

				return RedirectToAction("Login");
			}
			return View(student);
		}


		// Đăng nhập
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Kiểm tra thông tin đăng nhập
            var student = await _context.Students
                .SingleOrDefaultAsync(s => s.Email == email && s.Password == password);

            if (student != null)
            {
                HttpContext.Session.SetInt32("StudentID", student.StudentID);
                HttpContext.Session.SetString("StudentName", student.Name);
                HttpContext.Session.SetString("StudentEmail", student.Email);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }


		// Đăng xuất
		[HttpPost]
		public IActionResult Logout()
		{
			HttpContext.Session.Remove("StudentID");
			return RedirectToAction("Index", "Home");
		}

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student, IFormFile imageFile)
        {
            if (id != student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Tải thực thể sinh viên từ cơ sở dữ liệu
                    var existingStudent = await _context.Students.FindAsync(id);
                    if (existingStudent == null)
                    {
                        return NotFound();
                    }

                    // Cập nhật thuộc tính của thực thể đã tải từ cơ sở dữ liệu
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        var subFolder = "StudentImages";
                        var saveImagePath = await UploadFile.SaveImage(subFolder, imageFile);
                        existingStudent.ImagePath = saveImagePath;
                    }
                    else
                    {
                        existingStudent.ImagePath = existingStudent.ImagePath;
                    }

                    // Cập nhật các thuộc tính khác
                    existingStudent.Name = student.Name;
                    existingStudent.Email = student.Email;
                    existingStudent.Password = student.Password;
                    existingStudent.Phone = student.Phone;
                    existingStudent.Address = student.Address;
                    existingStudent.DateOfBirth = student.DateOfBirth;
                    existingStudent.IdentityCard = student.IdentityCard;

                    _context.Update(existingStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "ClassStudent"); // Hoặc trang nào bạn muốn điều hướng sau khi chỉnh sửa
            }
            return View(student);
        }



        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentID == id);
        }

    }
}