using System.Text;

namespace CoR
{
    public class JobApplication
    {
        public string ApplicationName { get; set; }
        public string JobTitle { get; set; }
        public string JobCode { get; set; }
        public StringBuilder Comments { get; set; }
    }

    public abstract class BaseHandler
    {
        protected BaseHandler _nextHandler;

        public void SetNext(BaseHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract void HandleRequest(JobApplication jopApplication);
    }

    public class HRHandler : BaseHandler
    {
        public override void HandleRequest(JobApplication jopApplication)
        {
            if(jopApplication.JobCode == "123")
            {
                jopApplication.Comments.AppendLine("HR comment");
            }

            if(_nextHandler != null)
            {
                _nextHandler.HandleRequest(jopApplication);
            }
            else
            {
                jopApplication.Comments.AppendLine("Ended by HR handler");
            }
        }
    }

    class TechHandler : BaseHandler
    {
        public override void HandleRequest(JobApplication jopApplication)
        {
            if(jopApplication.JobCode == "456")
            {
                jopApplication.Comments.AppendLine("Tech comment");
            }

            if(_nextHandler != null)
            {
                _nextHandler.HandleRequest(jopApplication);
            }
            else
            {
                jopApplication.Comments.AppendLine("Ended by TECH handler");
            }
        }
    }
}
