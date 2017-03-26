//User Dto

namespace Service.DTO
{
    public class CreateUser
    {
        public CreateUser(
            string firstName, 
            string lastName, 
            string emailAddress)
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
