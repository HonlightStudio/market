namespace CW10B.Model;

public class StudentInfo
{
    public void PrintMyName()
    {
        Console.WriteLine("My name is Hossein");
        
    }

    public void printToday()
    {
        Console.WriteLine("Today is " + DateTime.Now.ToShortDateString());
    }
}
