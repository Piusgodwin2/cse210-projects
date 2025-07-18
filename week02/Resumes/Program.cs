using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");

        Job job1 = new Job();
        job1._jobtitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endyear = 2022;

        Console.WriteLine($"Job 1 Company: {job1._company}");

        job1.DisplayjobDetails();

        //  Second job
        Job job2 = new Job();
        job2._jobtitle = "Cloud Engineer";
        job2._company = "Google";
        job2._startYear = 2020;
        job2._endyear = 2023;

        // Display job2 company
        Console.WriteLine($"Job 2 Company: {job2._company}");

        job2.DisplayjobDetails();

        //  Resume instance
        Resume myResume = new Resume();
        myResume._name = "Pius Godwin";

        // Add the jobs to the resume’s job list
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Access and display the first job title using dot notation
        Console.WriteLine("First Job Title from Resume:");
        Console.WriteLine(myResume._jobs[0]._jobtitle);

        // Display the resume details
        myResume.DisplayResume();
    

    }
}