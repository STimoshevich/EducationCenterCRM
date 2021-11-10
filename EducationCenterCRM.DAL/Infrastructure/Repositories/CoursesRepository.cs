using EducationCenterCRM.DAL.Context;
using EducationCenterCRM.DAL.Entities;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Infrastructure.Repositories
{
    public class CoursesRepository : AbstractRepository<Course>
    {
        public CoursesRepository(EducationCenterDatabase context) : base(context)
        {
        }


        public async Task<(IEnumerable<Course> Courses, int ItemsAmount)> SearchAsync(string searchString, int currentPage, int itemsPerPage)
        {
            int skipAmout = (--currentPage) * itemsPerPage;
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrWhiteSpace(searchString))
            {
                var searchWords = searchString.Split(' ');

                var expression = PredicateBuilder.New<Course>();

                foreach (var word in searchWords)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        expression = expression.Or(x => x.TopicTitle.Contains(word));
                        expression = expression.Or(x => x.Description.Contains(word));
                        expression = expression.Or(x => x.Title.Contains(word));
                    }


                }

                var list = await context.Set<Course>().Where(expression).Distinct().Skip(skipAmout).Take(itemsPerPage).AsNoTracking().ToListAsync();
                var count = await context.Set<Course>().AsNoTracking().CountAsync(expression);

                return (list, count);

            }
            else
            {
                var list = await table.Skip(skipAmout).Take(itemsPerPage).AsNoTracking().ToListAsync();
                var count = await table.AsNoTracking().CountAsync();

                return (list, count);
            }


        }

        public async Task<IEnumerable<Tuple<int, string>>> AllTitleWithId()
        {
            return await table.Select(x => new Tuple<int, string>(x.Id, x.Title)).ToListAsync();
        }


        public async Task<IEnumerable<Tuple<int, string>>> AllTeachersNamesWithIdbyCourse(int courseId)
        {
             return table
                .Include(x=>x.Teachers)
                .ThenInclude(x=>x.EducationCenterUser)
                .FirstOrDefault(x => x.Id == courseId)?
                .Teachers?
                .Select(x => new Tuple<int, string>(x.Id, $"{x.EducationCenterUser.PersonLastName} {x.EducationCenterUser.PersonName}"));
        }

    

        
    }
}