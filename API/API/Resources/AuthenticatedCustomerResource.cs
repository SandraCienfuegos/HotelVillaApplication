namespace API.Resources
{
    public class AuthenticatedCustomerResource
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}