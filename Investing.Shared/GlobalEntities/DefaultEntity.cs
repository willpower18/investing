using Flunt.Notifications;
using Flunt.Validations;
using Investing.Shared.GlobalEnumerators;
using System.Text;

namespace Investing.Shared.GlobalEntities
{
    public class DefaultEntity : Notifiable<Notification>
    {
        public DefaultEntity()
        {
            Id = Guid.NewGuid();
            Active = EActiveStatus.Active;
            ValidateDefaultEntity();
        }

        public DefaultEntity(Guid id, EActiveStatus active)
        {
            Id = id;
            Active = active;
            ValidateDefaultEntity();
        }

        public Guid Id { get; protected set; }

        public EActiveStatus Active { get; protected set; }

        public void Enable()
        {
            Active = EActiveStatus.Active;
        }

        public void Disable()
        {
            Active = EActiveStatus.Inactive;
        }

        public List<string> GetNotificationsList()
        {
            List<string> errorList = new List<string>();

            if (Notifications != null)
            {
                if (Notifications.Any())
                {
                    foreach (Notification n in Notifications)
                    {
                        errorList.Add(n.Message.ToString());
                    }
                }
            }

            return errorList;
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

        private void ValidateDefaultEntity()
        {
            AddNotifications(new Contract<DefaultEntity>()
                .AreNotEquals(Id, Guid.Empty, "Id", "Invalid Id. The unique identifier must be a valid guid")    
            );
        }
    }
}
