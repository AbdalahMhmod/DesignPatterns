using System.Text;

namespace DecoratorPattern
{
    public abstract class SMSService
    {
        public abstract string SendSMS(string customerId, string number, string message);
    }

    public class ConcreteSMSService : SMSService
    {
        public override string SendSMS(string customerId, string number, string message)
        {
            return $"Cust Id : {customerId}, sms is : {message}, from : {number}";
        }
    }

    public abstract class AbstractDecorator : SMSService
    {
        private SMSService _sMSService;
        protected abstract string SMSSendNotification(string custId, string sms);
        public void SetService(SMSService sMSService)
        {
            _sMSService = sMSService;
        }

        public override string SendSMS(string customerId, string number, string message)
        {
            if(_sMSService == null)
            {
                return "Notification service not initialized!";
            }

            return _sMSService.SendSMS(customerId, number, message);
        }
    }

    public class NotificationEmailDecorator : AbstractDecorator
    {
        public override string SendSMS(string customerId, string number, string message)
        {
            var result = new StringBuilder();
            result.AppendLine(base.SendSMS(customerId, number, message));
            result.AppendLine(SMSSendNotification(customerId, message));

            return result.ToString();
        }

        protected override string SMSSendNotification(string custId, string sms)
        {
            return $"Sms {sms}, sent to {custId}, at {DateTime.Now.ToLongDateString()}";
        }
    }
}
