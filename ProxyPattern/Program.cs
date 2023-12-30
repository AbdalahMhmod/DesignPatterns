using ProxyPattern;

var smsProxy = new SMSServiceProxy();
Console.WriteLine(smsProxy.SendSMS("895410", "01234567899", "msg"));
Console.WriteLine(smsProxy.SendSMS("895410", "01234567891", "msg1"));
Console.WriteLine(smsProxy.SendSMS("895410", "01234567892", "msg2"));