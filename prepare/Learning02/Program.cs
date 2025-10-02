using System;
class Program
{
    static void Main(string[] args)
    {

        Job job1 = new Job();
        job1._jobTitle = "Team Associate";
        job1._company = "Walmart";
        job1._startYear = 2023;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._jobTitle = "Sales Manager";
        job2._company = "Pointe Marketing";
        job2._startYear = 2025;
        job2._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Christopher Savage";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}