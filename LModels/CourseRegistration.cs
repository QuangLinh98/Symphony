using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LModels
{
	public class CourseRegistration
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CourseRegistrationID { get; set; }

		public string? Status {  get; set; }

		public int CourseID { get; set; } 
		public Course? Course { get; set; } 

		public int StudentID { get; set; } 
		public Student? Student { get; set; }

		public DateTime RegistrationDate { get; set; } // Thời gian đăng ký
	}
}
