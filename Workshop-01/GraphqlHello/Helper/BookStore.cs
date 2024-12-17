using GraphqlHello.Model;

namespace GraphqlHello.Helper
{
    //Step 03: Create a BookStore class
    public static class BookStore
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Title = "C# in Depth", Author = new Author { Name = "Jon Skeet" } },
            new Book { Title = "Clean Code", Author = new Author { Name = "Robert C. Martin" } },
            new Book { Title = "The Pragmatic Programmer", Author = new Author { Name = "Andrew Hunt" } },
            new Book { Title = "Design Patterns", Author = new Author { Name = "Erich Gamma" } },
            new Book { Title = "Refactoring", Author = new Author { Name = "Martin Fowler" } },
            new Book { Title = "Code Complete", Author = new Author { Name = "Steve McConnell" } },
            new Book { Title = "Introduction to Algorithms", Author = new Author { Name = "Thomas H. Cormen" } },
            new Book { Title = "The Mythical Man-Month", Author = new Author { Name = "Frederick P. Brooks Jr." } },
            new Book { Title = "Structure and Interpretation of Computer Programs", Author = new Author { Name = "Harold Abelson" } },
            new Book { Title = "Domain-Driven Design", Author = new Author { Name = "Eric Evans" } },
            new Book { Title = "Patterns of Enterprise Application Architecture", Author = new Author { Name = "Martin Fowler" } },
            new Book { Title = "Continuous Delivery", Author = new Author { Name = "Jez Humble" } },
            new Book { Title = "Working Effectively with Legacy Code", Author = new Author { Name = "Michael Feathers" } },
            new Book { Title = "You Don't Know JS", Author = new Author { Name = "Kyle Simpson" } },
            new Book { Title = "JavaScript: The Good Parts", Author = new Author { Name = "Douglas Crockford" } },
            new Book { Title = "Eloquent JavaScript", Author = new Author { Name = "Marijn Haverbeke" } },
            new Book { Title = "JavaScript: The Definitive Guide", Author = new Author { Name = "David Flanagan" } },
            new Book { Title = "Effective Java", Author = new Author { Name = "Joshua Bloch" } },
            new Book { Title = "Head First Design Patterns", Author = new Author { Name = "Eric Freeman" } },
            new Book { Title = "Spring in Action", Author = new Author { Name = "Craig Walls" } },
            new Book { Title = "Pro ASP.NET Core MVC", Author = new Author { Name = "Adam Freeman" } },
            new Book { Title = "ASP.NET Core in Action", Author = new Author { Name = "Andrew Lock" } },
            new Book { Title = "C# 8.0 in a Nutshell", Author = new Author { Name = "Joseph Albahari" } },
            new Book { Title = "Entity Framework Core in Action", Author = new Author { Name = "Jon P Smith" } },
            new Book { Title = "Blazor in Action", Author = new Author { Name = "Chris Sainty" } },
            new Book { Title = "Kubernetes Up & Running", Author = new Author { Name = "Kelsey Hightower" } },
            new Book { Title = "Docker Deep Dive", Author = new Author { Name = "Nigel Poulton" } },
            new Book { Title = "Microservices Patterns", Author = new Author { Name = "Chris Richardson" } },
            new Book { Title = "Building Microservices", Author = new Author { Name = "Sam Newman" } },
            new Book { Title = "Site Reliability Engineering", Author = new Author { Name = "Niall Richard Murphy" } }
        };

        public static Book GetBook(string title)
        {
            return books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<Book> ListBooks(int pageNumber, int pageSize)
        {
            return books.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public static void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}
