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
            var group_3 = new Group() { Id = 3, StartDate = new DateTime(2021, 4, 5), Title = "third_group", Status = Enums.GroupStatus.Started, TeacherId = teacher_3.Id };
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
            var topic1 = new Topic()
            {
                Id = 1,
                Title = ".Net",
                Description = ".Net (ASP.NET, Unity)"
            };
            var topic2 = new Topic()
            {
                Id = 2,
                Title = "Java",
                Description = "Full-stack, JS, Spring"
            };



            var course1 = new Course()
            {
                Id = 10,
                Title = "Introduction to C#",
                Description = "Introduction to C#",
                Program = "1. Getting Started",
                TopicId = 1,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnpoO8C2w4eMbJ1NaPLaJgrwC7smBhuwSSRA&usqp=CAU"
            };

            var course2 = new Course()
            {
                Id = 11,
                Title = "Introduction to Java",
                Description = "Introduction to Java",
                Program = "1. Getting Started",
                TopicId = 2,
                ImageUrl = "https://www.osp.ru/FileStorage/DOCUMENTS_ILLUSTRATIONS/13230112/original.jpg"

            };

            var course3 = new Course()
            {
                Id = 12,
                Title = "ASP.NET",
                Description = "Web with ASP.NET",
                Program = "1. Controllers and MVC",
                TopicId = 1,
                ImageUrl = "https://fiverr-res.cloudinary.com/images/t_main1,q_auto,f_auto,q_auto,f_auto/gigs/113201276/original/3adcfe36722f42c0a44f46a81f06064c9988fe3a/do-asp-dot-net-core-mvc-applications.png"

            };

            var course4 = new Course()
            {
                Id = 13,
                Title = "Unity",
                Description = "Unity Game Development",
                Program = "1. What is Unity",
                TopicId = 1,
                ImageUrl = "https://unity.com/sites/default/files/styles/social_media_sharing_twitter/public/2019-11/unity-logo-600x400%402x.jpg?h=10d202d3&itok=LgYBHKk9"

            };

            modelBuilder.Entity<Course>().HasData(course1, course2, course3, course4);
            modelBuilder.Entity<Topic>().HasData(topic1, topic2);
            modelBuilder.Entity<Student>().HasData(student_1, student_2, student_3, student_4, student_5);
            modelBuilder.Entity<Teacher>().HasData(teacher_1, teacher_2, teacher_3);
            modelBuilder.Entity<Group>().HasData(group_1, group_2, group_3, group_4);


        }
    }
}
