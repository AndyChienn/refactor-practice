using RefactorPractice.Models;

namespace RefactorPractice.Specifics.Interface;

public interface IScholarshipSpecific
{
    int Calculate( List<Course> courses);
}