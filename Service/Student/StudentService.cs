using schoolmanagement.data.Repository;
using schoolmanagement.Domain.Models;
using schoolmanagement.Service.ViewModel;

namespace schoolmanagement.Service.Student
{
    public class StudentService : IStudentService
    {
        private IRepository<student> _Studentrepository;
        public StudentService(IRepository<student> repository)
        {
            _Studentrepository = repository;

        }
        public async Task<StudentViewModel> DeleteStudentAsync(int StudentID)
        {
            var isStudentExist = (await _Studentrepository.GetByIdAsync(x => x.StudentID == StudentID)).FirstOrDefault();
            if (isStudentExist != null)
            {
                await _Studentrepository.DeleteAsync(isStudentExist);
                await _Studentrepository.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<StudentViewModel>> GellAllStudentAsync()
        {
            var studentList = await _Studentrepository.GetAllAsync();
            var companyViewModels = studentList.Select(student => new StudentViewModel
            {
                StudentID = student.StudentID,
                Name = student.Name,
                BirthDate = student.BirthDate,
                Address = student.Address,
                Mobile = student.Mobile,
                Email = student.Email,
                SchoolCollege = student.SchoolCollege,
            }).ToList();

            return companyViewModels;
        }

        public async Task<StudentViewModel> GetStudentAsync(int StudentID)
        {
            var result = await _Studentrepository.GetByIdAsync(x => x.StudentID == StudentID);
            var student = result.Select(x => new StudentViewModel
            {
                StudentID = x.StudentID,
                Name = x.Name,
                BirthDate = x.BirthDate,
                Address = x.Address,
                Mobile = x.Mobile,
                Email = x.Email,
                Year = x.Year,
                SchoolCollege = x.SchoolCollege,
                Percentage = x.Percentage,
                GuardianName = x.GuardianName,
                GuardianType = x.GuardianType,
            }).FirstOrDefault();
            return student;
        }

        public async Task<string> InsertStudentAsync(StudentViewModel studentViewModel)
        {
            string result;
            var student = new student();
            var isStudentExist = (await _Studentrepository.GetByIdAsync(x => x.Mobile == studentViewModel.Mobile)).Any();
            if (isStudentExist)
            {
                result = "PhoneNumber Already Exist";
            }
            else
            {
                student.Name = studentViewModel.Name;
                student.BirthDate = studentViewModel.BirthDate;
                student.Address = studentViewModel.Address;
                student.Mobile = studentViewModel.Mobile;
                student.Email = studentViewModel.Email;
                student.Year = studentViewModel.Year;
                student.SchoolCollege = studentViewModel.SchoolCollege;
                student.Percentage = studentViewModel.Percentage;
                student.GuardianName = studentViewModel.GuardianName;
                student.GuardianType = studentViewModel.GuardianType;
                await _Studentrepository.InsertAsync(student);
                await _Studentrepository.SaveChangesAsync();
                result = "Added Successfully!";
            }

            return result;
        }

        public async Task<StudentViewModel> UpdateStudentAsync(StudentViewModel studentViewModel)
        {
            var doesStudentExist = (await _Studentrepository.GetByIdAsync(x => x.StudentID == studentViewModel.StudentID)).FirstOrDefault();
            if (doesStudentExist != null)
            {

                doesStudentExist.Name = studentViewModel.Name;
                doesStudentExist.BirthDate = studentViewModel.BirthDate;
                doesStudentExist.Mobile = studentViewModel.Mobile;
                doesStudentExist.Address = studentViewModel.Address;
                doesStudentExist.Email = studentViewModel.Email;
                doesStudentExist.Year = studentViewModel.Year;
                doesStudentExist.SchoolCollege = studentViewModel.SchoolCollege;
                doesStudentExist.Percentage = studentViewModel.Percentage;
                doesStudentExist.GuardianName = studentViewModel.GuardianName;
                doesStudentExist.GuardianType = studentViewModel.GuardianType;
                await _Studentrepository.UpdateAsync(doesStudentExist);
                await _Studentrepository.SaveChangesAsync();
            }
            return studentViewModel;
        }
    }
}
