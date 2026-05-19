namespace simpleapp.Models
{
    public class DragonBall
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    public class DragonballApiResponse
    {
        public int id { get; set; }
        public Name1 name { get; set; }
        public Characters characters { get; set; }
    }

    public class Name1
    {
        public string official { get; set; }
    }

    public class Characters
    {
        public string png { get; set; }
    }
}