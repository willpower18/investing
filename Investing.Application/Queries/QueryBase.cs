using Flunt.Notifications;
using System.Text;

namespace Investing.Application.Queries
{
    public abstract class QueryBase : Notifiable<Notification>
    {
        public List<string> GetErrorList()
        {
            List<string> errors = new List<string>();

            if (Notifications != null)
            {
                if (Notifications.Any())
                {
                    foreach (Notification n in Notifications)
                    {
                        errors.Add(n.Message.ToString());
                    }
                }
            }

            return errors;
        }

        public string GetCompiledErrorList()
        {
            if (Notifications != null)
            {
                if (Notifications.Any())
                {
                    int counter = 1;
                    StringBuilder errors = new StringBuilder();
                    foreach (Notification n in Notifications)
                    {
                        if (counter != Notifications.Count)
                            errors.Append(string.Concat(n.Message, ", "));
                        else
                            errors.Append(n.Message);

                        counter++;
                    }

                    return errors.ToString();
                }
            }

            return string.Empty;
        }
    }
}
