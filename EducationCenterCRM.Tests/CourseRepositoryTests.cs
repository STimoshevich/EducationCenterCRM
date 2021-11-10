using EducationCenterCRM.DAL.Context;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace EducationCenterCRM.Tests
{
    public class CourseRepositoryTests
    {

        DbContextOptionsBuilder<EducationCenterDatabase> options = new DbContextOptionsBuilder<EducationCenterDatabase>()
          .UseInMemoryDatabase(databaseName: "MovieListDatabase")
          .Options;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SearchTestAsync()
        {

            using (var context = new EducationCenterDatabase(options))
            {
                var course_1 = new Course()
                {
                    Id = 1,
                    Title = "first_course_title",
                    Description = "first_course_description",
                };

                var course_2 = new Course()
                {
                    Id = 2,
                    Title = "second_course_title",
                    Description = "second_course_description",
                };

                var course_3 = new Course()
                {
                    Id = 3,
                    Title = "third_course_title",
                    Description = "third_course_description",
                };




                await context.Courses.AddRangeAsync(course_1, course_2, course_3);


                var repository = new CoursesRepository(context);



                var testWord = "sec";
                var actualResult = await repository.SearchAsync(testWord, 1, 1000);
                var expectedResult = (await repository.GetAllAsync()).Count(x => x.Title.Contains(testWord));
            }




            Assert.Pass();
        }



    }
}