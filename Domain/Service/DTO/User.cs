//user dto

namespace Service.DTO
{
    public class User
    {
        public User(string firstName, string lastName, string emailAddress)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }
    }
}
