namespace RefactorPractice.Models;

public class Course
{
    public double GetScore() => Score;
    public double GetCredit() => Credit;
    public double Score { get; set; }
    public double Credit { get; set; }
}