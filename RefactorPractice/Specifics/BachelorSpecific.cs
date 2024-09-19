using RefactorPractice.Models;
using RefactorPractice.Specifics.Interface;

namespace RefactorPractice.Specifics;

public class BachelorSpecific : IScholarshipSpecific
{
    public int Calculate(List<Course> courses)
    {

        var total = courses.Count;
        var achieved = courses.Count(course => course.GetScore() >= 80);
        var rate = (double)achieved / total;

        return rate switch
        {
            >= (double)1 / 2 => 10_000,
            >= (double)1 / 3 => 5_000,
            _ => 0
        };
    }
}