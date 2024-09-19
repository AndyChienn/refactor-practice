namespace RefactorPractice.Models;

public class Transcript
{
    public string GetProgramType() => ProgramType;
    public List<Course> GetCourses() => Courses;

    public string ProgramType { get; set; }
    public List<Course> Courses { get; set; }
}