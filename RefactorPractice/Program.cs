// See https://aka.ms/new-console-template for more information

using RefactorPractice.Models;
using RefactorPractice.Service;

Console.WriteLine("Hello, Eric!");

var scholarshipService = new ScholarshipService();

var transcript = new Transcript
{
    ProgramType = "Bachelor",
    Courses =
    [
        new Course { Score = 3.0, Credit = 3.0 },
        new Course { Score = 3.0, Credit = 3.0 },
        new Course { Score = 3.0, Credit = 3.0 }
    ]
};
var scholarship = scholarshipService.Calculate(transcript);

Console.WriteLine("I Don't Know answer");