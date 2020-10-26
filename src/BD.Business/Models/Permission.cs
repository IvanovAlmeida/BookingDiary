namespace BD.Business.Models
{
    public class Permission : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public Permission() { }

        public Permission(string name, string type, string value)
        {
            Name = name;
            Type = type;
            Value = value;
        }

        public Permission(int id, string name, string type, string value) : this(name, type, value)
        {
            Id = id;
        }
    }
}