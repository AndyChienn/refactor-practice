using RefactorPractice.Exceptions;
using RefactorPractice.Models;
using RefactorPractice.Specifics;
using RefactorPractice.Specifics.Interface;

namespace RefactorPractice.Service;

public class ScholarshipService
{
    private Dictionary<string,IScholarshipSpecific> SpecificMap { get; set; } 

    public ScholarshipService()
    {
        SpecificMap = new Dictionary<string, IScholarshipSpecific>
        {
            {"Bachelor", new BachelorSpecific()},
            {"Master", new MasterSpecific()},
            {"PhD", new PhDSpecific()}
        };
    }

    public int Calculate(Transcript transcript)
    {
        var programType = transcript.GetProgramType();
        
        if (SpecificMap.TryGetValue(programType, out var specific))
        {
            var courses = transcript.GetCourses();
            return courses.Count == 0 ? 0 : specific.Calculate(courses);
        }

        throw new UnknownProgramTypeException(programType);

    }

   
}