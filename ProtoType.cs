using System;

namespace Patterns
{
    public abstract class Prototype
    {
        public abstract Prototype Clone();
    }

    public class User : Prototype
    {
        public string Username { get; set; }
        public int Age { get; set; }

        public User(string username, int age)
        {
            Username = username;
            Age = age;
        }

        public override Prototype Clone()
        {
            return new User(this.Username, this.Age);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"User: {Username}, Age: {Age}");
        }
    }

    public class Document : Prototype
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Document(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public override Prototype Clone()
        {
            return new Document(this.Title, this.Content);
        }

        public void DisplayContent()
        {
            Console.WriteLine($"Document: {Title}, Content: {Content}");
        }
    }
}

