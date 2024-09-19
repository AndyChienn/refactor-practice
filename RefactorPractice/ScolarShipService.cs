namespace RefactorPractice;

using System;
using System.Collections.Generic;

public class Course
{
    public double GetScore() => Score;
    public double GetCredit() => Credit;
    public double Score { get; set; }
    public double Credit { get; set; }
}

public class Transcript
{
    public string GetProgramType() => ProgramType;
    public List<Course> GetCourses() => Courses;

    public string ProgramType { get; set; }
    public List<Course> Courses { get; set; }
}

public class ScholarshipService
{
    public int Calculate(Transcript transcript)
    {
        string programType = transcript.GetProgramType();

        if (programType.Equals("Bachelor"))
        {
            List<Course> courses = transcript.GetCourses();
            if (courses.Count == 0) return 0; // 不修課跟人家領什麼獎學金！

            int total = courses.Count;
            int achieved = 0;
            foreach (Course course in courses)
            {
                if (course.GetScore() >= 80)
                {
                    achieved++;
                }
            }
            double rate = (double)achieved / total;

            if (rate >= (double)1 / 2)
            {
                return 10_000;
            }
            else if (rate >= (double)1 / 3)
            {
                return 5_000;
            }
            else
            {
                return 0;
            }
        }

        if (programType.Equals("Master"))
        {
            List<Course> courses = transcript.GetCourses();
            if (courses.Count == 0) return 0; // 不修課跟人家領什麼獎學金！

            double totalCredit = 0.001D;
            double totalWeightedScore = 0D;

            foreach (Course course in courses)
            {
                totalCredit += course.GetCredit();
                totalWeightedScore += course.GetScore() * course.GetCredit();
            }

            double weightedAverage = totalWeightedScore / totalCredit;

            if (weightedAverage >= 90D)
            {
                return 15_000;
            }
            else if (weightedAverage >= 80D)
            {
                return 7_500;
            }
            else
            {
                return 0;
            }
        }

        if (programType.Equals("PhD"))
        {
            List<Course> courses = transcript.GetCourses();
            if (courses.Count == 0) return 0; // 不修課跟人家領什麼獎學金！

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

        throw new UnknownProgramTypeException(programType);
    }

    private class UnknownProgramTypeException : Exception
    {
        public UnknownProgramTypeException(string programType)
            : base($"Unknown program type: {programType}")
        {
        }
    }
}
