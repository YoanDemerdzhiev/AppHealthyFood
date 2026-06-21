using AppHealthyFood;

namespace Te
{
    [TestFixture]
    public class Tests
    {
        private MyContext context;
        private UserController controller;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new LibraryDbContext(options);
            controller = new BookController(context);

            context.Genres.Add(new Genre
            {
                IdGenre = 1,
                NameGenre = "Romance"
            });

            context.SaveChanges();
        }
    }
}