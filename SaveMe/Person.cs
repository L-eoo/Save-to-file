namespace SaveMe
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public Person(string firstName, string lastName, int phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
        }
    }
}
