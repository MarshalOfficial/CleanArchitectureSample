namespace CleanArchitectureSample.Application.Exceptions
{
    public class SmtpServerException : Exception
    {
        public SmtpServerException(Exception innerException, string email, string action) :
            base($"failed to send the {action} email to {email}.", innerException)
        {

        }
    }
}
