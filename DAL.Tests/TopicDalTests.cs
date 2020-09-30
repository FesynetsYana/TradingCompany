using DAL.Concrete;
using System.EnterpriseServices;
using NUnit.Framework;
using System.Configuration;
using DTO;
using System.Linq;
using System.Runtime.InteropServices;

namespace DAL.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class TopicDalTests:  ServicedComponent 
    {
        public TopicDalTests()
        { }

        [Test]
        public void AddTest()
        {
            TopicDal dal = new TopicDal(ConfigurationManager.ConnectionStrings["ManagerNews"].ConnectionString);
            var result = dal.AddTopic(new TopicDTO
            {
                Title = "Movie from test",
                Year = 2000,
                GenreID = 1
            });
            Assert.IsTrue(result.MovieID != 0, "returned ID should be more than zero");
        }

        [Test]
        public void GetAllTest()
        {
            TopicDal dal = new TopicDal(ConfigurationManager.ConnectionStrings["ManagerNews"].ConnectionString);
            var result = dal.CreateMovie(new TopicDTO
            {
                Title = "Movie for get all",
                Year = 2000,
                GenreID = 1
            });
            var movies = dal.GetAllMovies();
            Assert.AreEqual(1, movies.Count(x => x.Title == "Movie for get all"));
        }

        [TearDown]
        public void Teardown()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }

    }

}
