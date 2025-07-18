using System;

public class Job
{
    public string _jobtitle;
    public string _company;
    public int _startYear;
    public int _endyear;


    public void DisplayjobDetails()
    {
        Console.WriteLine($" {_jobtitle} {_company} {_startYear} - {_endyear}");
    }
}