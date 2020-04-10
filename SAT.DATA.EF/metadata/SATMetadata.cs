using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.DATA.EF
{
    #region Student
    public class StudentMetadata
    {
        [Required(ErrorMessage = "*First Name is REQUIRED")]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "First name input must be 20 characters or less")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*Last Name is REQUIRED")]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "Last name input must be 20 characters or less")]
        public string LastName { get; set; }
        [StringLength(15, ErrorMessage = "Major input must be 15 characters or less")]
        public string Major { get; set; }
        [Display(Name = "Street Address")]
        [StringLength(50, ErrorMessage = "Address input must be 50 characters or less")]
        public string Address { get; set; }
        [StringLength(25, ErrorMessage = "City input must be 25 characters or less")]
        public string City { get; set; }
        [StringLength(2, ErrorMessage = "State input must be 2 characters or less")]
        public string State { get; set; }
        [Display(Name = "Postal Code")]
        [StringLength(10, ErrorMessage = "Postal code input must be 10 characters or less")]
        public string ZipCode { get; set; }
        [StringLength(13, ErrorMessage = "Phone number input must be 13 characters or less")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "*Email address is REQUIRED")]
        [StringLength(60, ErrorMessage = "Email address input must be 13 characters or less")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Photo")]
        [StringLength(100, ErrorMessage = "Photo input must be 100 characters or less")]
        public string PhotoUrl { get; set; }
    }
    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
    #endregion
    #region Enrollment
    public class EnrollmentMetadata
    {
        [Required(ErrorMessage = "*Student Enrollment Date is REQUIRED")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "Date unknown")]
        [Display(Name = "Student Enrollment Date")]
        public System.DateTime EnrollmentDate { get; set; }
        [Display(Name = "Instructor Name")]
        public int ScheduleClassId { get; set; }
        [Display(Name = "Student Name")]
        public int StudentId { get; set; }
    }
    [MetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment
    {

    }
    #endregion
    #region StudentStatuses
    public class StudentStatusesMetadata
    {
        [Required(ErrorMessage = "*Student Status Name is REQUIRED")]
        [Display(Name = "Student Status Name")]
        [StringLength(30, ErrorMessage = "Student status name input must be 30 characters or less")]
        public string SSName { get; set; }
        [Display(Name = "Student Status Description")]
        [StringLength(250, ErrorMessage = "Student status name input must be 250 characters or less")]
        public string SSDescription { get; set; }       
    }
    [MetadataType(typeof(StudentStatusesMetadata))]
    public partial class StudentStatus
    {

    }
    #endregion

    #region Courses
    public class CoursesMetadata
    {
        [Required(ErrorMessage ="*Course Name is REQUIRED")]
        [StringLength(50, ErrorMessage="*Value must be 50 characters or less")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "*Description is REQUIRED")]
        [Display(Name = "Description")]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "*Credit Hours is REQUIRED")]
        [Display(Name = "Credit Hours")]
        public byte CreditHours { get; set; }

        [StringLength(250, ErrorMessage="*Value must be 250 characters or less")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [UIHint("MultilineText")]
        public string Curriculum { get; set; }

        [StringLength(500, ErrorMessage="*Value must be 500 characters or less")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [UIHint("MultilineText")]
        public string Notes { get; set; }

        [Required]
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
    }

    [MetadataType(typeof(CoursesMetadata))]
    public partial class Cours
    {

    }
    #endregion

    #region ScheduledClasses
    public class ScheduledClassesMetadata
    {
        [Required(ErrorMessage = "*Start Date is REQUIRED")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public System.DateTime StartDate { get; set; }

        [Required(ErrorMessage = "*End Date is REQUIRED")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public System.DateTime EndDate { get; set; }

        [Required(ErrorMessage = "*Instructor Name is REQUIRED")]
        [StringLength(40, ErrorMessage="*Value must be 40 characters or less")]
        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; }

        [Required(ErrorMessage ="*Location is required")]
        [StringLength(20, ErrorMessage="*Value must be 20 characters or less")]
        public string Location { get; set; }

    }

    [MetadataType(typeof(ScheduledClassesMetadata))]
    public partial class ScheduledClass { }
    #endregion

    #region ScheduledClassStatus
    public class ScheduledClassStatusMetadata
    {
        [Required(ErrorMessage ="*Scheduled Class Status Name is REQUIRED")]
        [StringLength(50, ErrorMessage="*Value must be 50 characters or less")]
        [Display(Name = "Status")]
        public string SCSName { get; set; }
    }

    [MetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduleClassStatus { }
    #endregion
}
