using RefactorPractice.Models;
using RefactorPractice.Specifics.Interface;

namespace RefactorPractice.Specifics;

public class PhDSpecific : IScholarshipSpecific
{
    public int Calculate(List<Course> courses)
    {

        foreach (Course course in courses)
        {
            if (course.GetScore() < 80)
            {
                return 0;
            }
            if (course.GetScore() < 90)
            {
                return 20_000;
            }
        }
        return 40_000;
    }
}