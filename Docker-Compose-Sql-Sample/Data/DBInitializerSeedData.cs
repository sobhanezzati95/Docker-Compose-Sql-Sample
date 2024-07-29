using Docker_Compose_Sql_Sample.Entity;

namespace Docker_Compose_Sql_Sample.Data
{
    public static class DBInitializerSeedData
    {
        public static void InitializeDatabase(ApplicationDbContext bLobDbContext)
        {
            if (bLobDbContext.Blogs.Any())
                return;

            var blogOne = new Blog
            {
                Name = "c#",
                Author = "Sobhan",
                Description = "C sharp is a good langauge",
                ImageUrl = "1.jpg"

            };
            var blogTwo = new Blog
            {
                Name = "web api",
                Author = "Sobhan",
                Description = "web apiis a good langauge",
                ImageUrl = "1.jpg"

            };
            var blogThree = new Blog
            {
                Name = "Blazor",
                Author = "Sobhan",
                Description = "Blazor is a good langauge",
                ImageUrl = "1.jpg"

            };

            bLobDbContext.Blogs.Add(blogOne);
            bLobDbContext.Blogs.Add(blogTwo);
            bLobDbContext.Blogs.Add(blogThree);

            bLobDbContext.SaveChanges();
        }
    }
}
