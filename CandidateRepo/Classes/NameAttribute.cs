namespace CandidateRepo.Classes
{
    public class NameAttribute : System.Attribute
    {
        public string Name { get; set; }

        public NameAttribute(string name)
        {
            Name = name;
        }
    }
}
