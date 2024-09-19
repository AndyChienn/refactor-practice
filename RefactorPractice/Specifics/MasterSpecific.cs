using RefactorPractice.Models;
using RefactorPractice.Specifics.Interface;

namespace RefactorPractice.Specifics;

public class MasterSpecific : IScholarshipSpecific
{
    public int Calculate(List<Course> courses)
    {
        var totalCredit = 0.001D;
        var totalWeightedScore = 0D;

        foreach (var course in courses)
        {
            totalCredit += course.GetCredit();
            totalWeightedScore += course.GetScore() * course.GetCredit();
        }

        var weightedAverage = totalWeightedScore / totalCredit;

        return weightedAverage switch
        {
            >= 90D => 15_000,
            >= 80D => 7_500,
            _ => 0
        };
    }
}