using System;
class Program
{
    static void Main(string[] args)
    {

        Job job1 = new Job();
        job1._jobTitle = "Team Associate";
        job1._company = "Walmart";
        job1._startDate = "4/6/2023";
        job1._endDate = "8/30/2024";

        Job job2 = new Job();
        job2._jobTitle = "Sales Manager";
        job2._company = "Pointe Marketing";
        job2._startDate = "4/14/2025";
        job2._endDate = "8/31/2025";

        Resume myResume = new Resume();
        myResume._name = "Christopher Savage";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}