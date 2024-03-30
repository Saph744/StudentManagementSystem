using schoolmanagement.Service.ViewModel;

namespace schoolmanagement.Service.Student
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentViewModel>> GellAllStudentAsync();
        Task<StudentViewModel> GetStudentAsync(int CompanyID);
        Task<string> InsertStudentAsync(StudentViewModel studentViewModel);
        Task<StudentViewModel> UpdateStudentAsync(StudentViewModel studentViewModel);
        Task<StudentViewModel> DeleteStudentAsync(int StudentID);
    }
}
