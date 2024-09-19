namespace RefactorPractice.Exceptions;

public class UnknownProgramTypeException : Exception
{
    public UnknownProgramTypeException(string programType)
        : base($"Unknown program type: {programType}")
    {
    }
}