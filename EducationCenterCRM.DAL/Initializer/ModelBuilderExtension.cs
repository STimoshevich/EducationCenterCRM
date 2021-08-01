using EducationCenterCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Initializer
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var teacher_1 = new Teacher()
            {
                Name = "Артём",
                Lastname = "Никольский",
                Email = "guilo-339@yopmail.com",
                Id = 1,
                Phone = "+375294632561",
                BirthDate = new DateTime(1990, 4, 11),
                Bio = "first teacher bio",
                LinkToProfile = "first teacher link"
            };
            var teacher_2 = new Teacher()
            {
                Name = "Даниил",
                Lastname = "Галкин",
                Email = "oknijs@yadpmail.com",
                Id = 2,
                Phone = "+37529108642",
                BirthDate = new DateTime(1986, 5, 4),
                Bio = "first teacher bio",
                LinkToProfile = "second teacher link"
            };
            var teacher_3 = new Teacher()
            {
                Name = "Анастасия",
                Lastname = "Прокофьева",
                Email = "qweewq@om.com",
                Id = 3,
                Phone = "+375296207583",
                BirthDate = new DateTime(1989, 7, 1),
                Bio = "first teacher bio",
                LinkToProfile = "third teacher link"
            };

            var group_1 = new Group() { Id = 1, StartDate = new DateTime(2021, 7, 20), Title = "first_group", Status = Enums.GroupStatus.Started, TeacherId = teacher_1.Id };
            var group_2 = new Group() { Id = 2, StartDate = new DateTime(2021, 10, 13), Title = "second_group", Status = Enums.GroupStatus.NotStarted, TeacherId = teacher_2.Id };
            var group_3 = new DAL.Entities.Group() { Id = 3, StartDate = new DateTime(2021, 4, 5), Title = "third_group", Status = Enums.GroupStatus.Started, TeacherId = teacher_3.Id };
            var group_4 = new Group() { Id = 4, StartDate = new DateTime(2021, 12, 12), Title = "fourth_group", Status = Enums.GroupStatus.NotStarted, TeacherId = teacher_3.Id };


            var student_1 = new Student()
            {
                Name = "Мирослав",
                Lastname = "Дубченко",
                Email = "gougeigubreudo-4919@yopmail.com",
                Id = 1,
                Phone = "+375291234561",
                BirthDate = new DateTime(1990, 7, 20),
                Type = Enums.StudentType.Online,
                GroupId = group_1.Id
            };
            var student_2 = new Student()
            {
                Name = "Гордей",
                Lastname = "Дзюба",
                Email = "croimappossoteu-1134@yopmail.com",
                Id = 2,
                Phone = "+375291265463",
                BirthDate = new DateTime(1994, 2, 5),
                Type = Enums.StudentType.InClass,
                 GroupId = group_2.Id
            };
            var student_3 = new Student()
            {
                Name = "Даниил",
                Lastname = "Мирный",
                Email = "kaumeusateileu-9412@yopmail.com",
                Id = 3,
                Phone = "+375299514564",
                BirthDate = new DateTime(1989, 4, 14),
                Type = Enums.StudentType.Mix,
                GroupId = group_3.Id
            };
            var student_4 = new Student()
            {
                Name = "Чеслав",
                Lastname = "Тимошенко",
                Email = "jeibrucrouquixi-1073@yopmail.com",
                Id = 4,
                Phone = "+375291235217",
                BirthDate = new DateTime(1998, 4, 3),
                Type = Enums.StudentType.InClass,
                GroupId = group_1.Id
            };
            var student_5 = new Student()
            {
                Name = "Георгий",
                Lastname = "Яловой",
                Email = "cobrebaseido-4239@yopmail.com",
                Id = 5,
                Phone = "+375291239635",
                BirthDate = new DateTime(1993, 11, 22),
                Type = Enums.StudentType.Mix,
                GroupId = group_3.Id
            };

            modelBuilder.Entity<Student>().HasData(student_1, student_2, student_3, student_4, student_5);
            modelBuilder.Entity<Teacher>().HasData(teacher_1, teacher_2, teacher_3);
            modelBuilder.Entity<Group>().HasData(group_1, group_2, group_3, group_4);


        }
    }
}
