namespace dNothi.Utility
{
  public interface IEmailSender
  {
    string Subject { get; set; }
    string Body { get; set; }
    string FromAddress { get; set; }
    string[] ToList { get; set; }
    string[] CcList { get; set; }
    string[] BccList { get; set; }
    bool Sendmail();
  }
}