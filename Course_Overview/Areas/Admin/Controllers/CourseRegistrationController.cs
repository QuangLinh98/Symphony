using Course_Overview.Data;
using LModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Course_Overview.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CourseRegistrationController : Controller
	{
		private readonly DatabaseContext _dbContext;
		public CourseRegistrationController(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IActionResult> Index()
		{
			var registrations = await _dbContext.CourseRegistrations
				               .Include(cr => cr.Course)
							   .Include(cr => cr.Student)
							   .ToListAsync();
			return View(registrations);
		}

		

		//Phương thức xác nhận đăng ký 
		[HttpPost]
		public async Task<IActionResult> AcceptRegistration(int id)
		{
			var registration = await _dbContext.CourseRegistrations.FindAsync(id);
            if (registration == null)
            {
				return NotFound();
            }
			registration.Status = "Accepted";
			await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
		}

		//Phương thức từ chối đăng ký 
		[HttpPost]
		public async Task<IActionResult> RejectRegistration(int id)
		{
			var registration = await _dbContext.CourseRegistrations.FindAsync(id);
			if (registration == null)
			{
				return NotFound();
			}
			registration.Status = "Rejected";
			await _dbContext.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		//Phương thức View Edit
		public async Task<IActionResult>Edit(int id)
		{
			var registration = await _dbContext.CourseRegistrations.FindAsync(id);
			if (registration == null)
			{
				return NotFound();
			}
			return View(registration);
		}

		//Phương thưc xử lý Edit
		[HttpPost]
		public async Task<IActionResult> Edit(CourseRegistration registration)
		{
			if (ModelState.IsValid)
			{
				_dbContext.Update(registration);
				await _dbContext.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(registration);
		}

		// 5. Xóa đăng ký
		public async Task<IActionResult> Delete(int id)
		{
			var registration = await _dbContext.CourseRegistrations.FindAsync(id);
			if (registration != null)
			{
				_dbContext.CourseRegistrations.Remove(registration);
				await _dbContext.SaveChangesAsync();
			}
			return RedirectToAction("Index");
		}
	}
}
