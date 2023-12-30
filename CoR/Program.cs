using CoR;
using System.Text;

var jobApplication = new JobApplication
{
    ApplicationName = "Interview",
    JobCode = "456",
    JobTitle = "Software engineer",
    Comments = new StringBuilder(),
};

var hRHandler = new HRHandler();
var techHandler = new TechHandler();

techHandler.SetNext(hRHandler);
techHandler.HandleRequest(jobApplication);

Console.WriteLine(jobApplication.Comments);