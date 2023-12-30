namespace ProxyPattern
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

    public class SMSServiceProxy
    {
        private SMSService sMSService;
        private readonly Dictionary<string, int> sentCount = new Dictionary<string, int>();
        public string SendSMS(string customerId, string number, string message)
        {
            sMSService ??= new ConcreteSMSService();

            if(!sentCount.ContainsKey(customerId))
            {
                sentCount.Add(customerId, 1);
                return sMSService.SendSMS(customerId, number, message);
            }

            if(sentCount[customerId] < 2)
            {
                sentCount[customerId] = sentCount[customerId] + 1;
                return sMSService.SendSMS(customerId, number, message);
            }

            return "Not Sent";
        }
    }
}
