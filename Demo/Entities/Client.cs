using System;

namespace Demo.Entities
{
    public class Client : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}" +
                   $"Name: {Name}" +
                   $"Email: {Email}";
        }
    }
}