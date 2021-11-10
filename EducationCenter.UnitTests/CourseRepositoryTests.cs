using EducationCenterCRM.DAL.Context;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EducationCenter.UnitTests
{
    public class CourseRepositoryTests
    {

        DbContextOptions<EducationCenterDatabase> options = new DbContextOptionsBuilder<EducationCenterDatabase>()
        .UseInMemoryDatabase(databaseName: "TestDb")
        .Options;

        [SetUp]
        public void Setup()
        {

        }

        [TestCase("sec")]
        [TestCase("Sec")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task SearchTest(string testWord)
        {
            using (var context = new EducationCenterDatabase(options))
            {
                //Arrange
                var repository = new CoursesRepository(context);

                if (!await context.Courses.AnyAsync())
                {
                    await context.Courses.AddRangeAsync(CourseGenerator.Get());
                    await context.SaveChangesAsync();
                }
                   


                //Act
                var actual = (await repository.SearchAsync(testWord, 1, 1000)).ItemsAmount;

                var expected = string.IsNullOrEmpty(testWord) || string.IsNullOrWhiteSpace(testWord)
                     ? await context.Courses.CountAsync()
                     : await context.Courses.CountAsync(x => x.Title.Contains(testWord) || x.Description.Contains(testWord));

                //Assert
                Assert.AreEqual(expected, actual);

             
            }
        }



    }
}