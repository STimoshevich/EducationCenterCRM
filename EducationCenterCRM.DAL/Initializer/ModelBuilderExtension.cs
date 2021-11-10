using EducationCenterCRM.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace EducationCenterCRM.DAL.Initializer
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            var student_role = new EducationCenterRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = ApplicationRoles.Student,
                NormalizedName = ApplicationRoles.Student.ToUpper()
            };
            var teacher_role = new EducationCenterRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = ApplicationRoles.Teacher,
                NormalizedName = ApplicationRoles.Teacher.ToUpper()
            };
            var manager_role = new EducationCenterRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = ApplicationRoles.Manager,
                NormalizedName = ApplicationRoles.Manager.ToUpper()
            };
            var admin_role = new EducationCenterRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = ApplicationRoles.Admin,
                NormalizedName = ApplicationRoles.Admin.ToUpper()
            };


            var user_1 = new EducationCenterUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "guilo-339@yopmail.com",
                UserName = "guilo-339@yopmail.com",
                PhoneNumber = "+375294632561",
                PersonName = "Артем",
                PersonLastName = "Никольский",
                BirthDate = new DateTime(1990, 4, 11),

            };
            var user_2 = new EducationCenterUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "asdfwq@om.com",
                Email = "asdfwq@om.com",
                PhoneNumber = "+375294632561",
                BirthDate = new DateTime(1986, 5, 4),
                PersonName = "Даниил",
                PersonLastName = "Галкин",

            };
            var user_3 = new EducationCenterUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "qweewq@om.com",
                UserName = "qweewq@om.com",
                PhoneNumber = "+375296207583",
                BirthDate = new DateTime(1989, 7, 1),
                PersonName = "Анастасия",
                PersonLastName = "Прокофьева",

            };
            var user_4 = new EducationCenterUser()
            {
                Id = Guid.NewGuid().ToString(),
                BirthDate = new DateTime(1990, 7, 20),
                PersonName = "Мирослав",
                PersonLastName = "Дубченко",
                Email = "gougeigubreudo-4919@yopmail.com",
                UserName = "gougeigubreudo-4919@yopmail.com",
                PhoneNumber = "+375291234561",

            };
            var user_5 = new EducationCenterUser()
            {
                Id = Guid.NewGuid().ToString(),
                BirthDate = new DateTime(1994, 2, 5),
                PersonName = "Гордей",
                PersonLastName = "Дзюба",
                Email = "croimappossoteu-1134@yopmail.com",
                UserName = "croimappossoteu-1134@yopmail.com",
                PhoneNumber = "+375291265463",

            };
            var user_6 = new EducationCenterUser()
            {
                Id = Guid.NewGuid().ToString(),
                BirthDate = new DateTime(1989, 4, 14),
                PersonName = "Даниил",
                PersonLastName = "Мирный",
                Email = "kaumeusateileu-9412@yopmail.com",
                UserName = "kaumeusateileu-9412@yopmail.com",
                PhoneNumber = "+375299514564",

            };
            var user_7 = new EducationCenterUser()
            {
                Id = Guid.NewGuid().ToString(),
                BirthDate = new DateTime(1998, 4, 3),
                PersonName = "Чеслав",
                PersonLastName = "Тимошенко",
                Email = "jeibrucrouquixi-1073@yopmail.com",
                UserName = "jeibrucrouquixi-1073@yopmail.com",
                PhoneNumber = "+375291235217",

            };
            var user_8 = new EducationCenterUser()
            {
                Id = Guid.NewGuid().ToString(),
                BirthDate = new DateTime(1993, 11, 22),
                PersonName = "Георгий",
                PersonLastName = "Яловой",
                Email = "cobrebaseido-4239@yopmail.com",
                UserName = "cobrebaseido-4239@yopmail.com",
                PhoneNumber = "+375291239635",

            };




            var topic1 = new Topic()
            {
                Title = ".Net",
                Description = ".Net (ASP.NET, Unity)"
            };
            var topic2 = new Topic()
            {
                Title = "Java",
                Description = "Full-stack, JS, Spring"
            };
            var topic3 = new Topic()
            {
                Title = "Business analysis",
                Description = "	 Бизнес-анализ как дисциплина тесно связан с анализом требований, но нацелен на определение изменений, которые необходимы для того, чтобы та или иная компания (организация) достигла своих стратегических целей. Эти изменения затрагивают стратегию, структуру, политику, процессы и информационные системы."

            };
            var topic4 = new Topic()
            {
                Title = "QA",
                Description = "Тестирование дистанционно – это контроль качества программного продукта. Оно может быть ручным или автоматизированным (с помощью Java/Python). Это не разовая активность, а процесс, который длится на протяжении всего жизненного цикла программного обеспечения. Курсы тестировщиков ПО – быстрый старт к востребованной и высокооплачиваемой IT-профессии"

            };
            var topic5 = new Topic()
            {
                Title = "English",
                Description = " Если вы хотите «войти в IT» и построить успешную карьеру в индустрии, то вам обязательно нужно знать английский язык. Не имеет значения, какое направление вы выберете и в какой компании в перспективе будете работать, так или иначе столкнетесь с необходимостью применять английский"
            };
            var topic6 = new Topic()
            {
                Title = "Design",
                Description = " Программа по UI/UX и веб-дизайну включает в себя знакомство с инструментарием, обучение созданию визуальной составляющей IT-продуктов, проектированию сайтов, приложений и других сервисов. Вы научитесь воплощать свои идеи, разрабатывать привлекательный и функциональный дизайн, сможете оформить или пополнить портфолио качественными проектами."
            };



            var course1 = new Course()
            {
                Id = 1,
                Title = "Introduction to C#",
                Description = "C# (си шарп) – объектно-ориентированный язык программирования, разработанный компанией Microsoft. Прямой интерес такой крупной корпорации к языку гарантирует, что он продолжит развиваться и находить применение в различных отраслях.C Sharp впитал лучшие качества, а также унаследовал особенности синтаксиса Java и C++. Применяется язык для веб-разработки, создания настольных и мобильных приложений. Если вы записались на курс по C# в Минске для того, чтобы научиться создавать web-проекты, то в дальнейшем вам необходимо освоить инструментарий .NET.Благодаря огромному количеству документации C# достаточно прост в изучении. А собственная среда разработки Visual Studio, готовые шаблоны, модули, процедуры делают язык комфортным в применении. После прохождения базового курса «Программирование на C#» можно выбрать направление для дальнейшего развития – заниматься промышленной разработкой ПО на ASP.NET или созданием мобильных игр на Unity.",
                Program = "1. Getting Started",
                TopicTitle = topic1.Title,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnpoO8C2w4eMbJ1NaPLaJgrwC7smBhuwSSRA&usqp=CAU",
                DurationWeeks = 18,
                Price = 400,
                CourseLevel = Enums.CourseLevel.Beginner,

            };
            var course2 = new Course()
            {
                Id = 2,
                Title = "Introduction to Java",
                Description = "Язык программирования Java находится в числе лидеров во многих рейтингах: TIOBE – на основе подсчёта результатов поисковых запросов, PYPL – по анализу популярности в поисковике Google, IEEE – по комплексу показателей, таких как упоминание в проектах, статьях, вакансиях и других. Такая популярность обусловлена практически безграничными его возможностями и областями применения. Java не зависит от определённой платформы, его называют безопасным, портативным, высокопроизводительным и динамичным языком.Специалист, который знает этот язык, точно не останется без работы – уже более 7 миллиардов устройств по всему миру работают на Java. При этом те, кто освоит основы программирования на Java на курсах в Минске, могут развиваться в совершенно разных направлениях: заниматься enterprise-разработкой, промышленным программированием, разработкой мобильных приложений под Android, автоматизированным тестированием или программной роботизацией бизнес-процессов (RPA).",
                Program = "1. Getting Started",
                TopicTitle = topic2.Title,
                ImageUrl = "https://www.osp.ru/FileStorage/DOCUMENTS_ILLUSTRATIONS/13230112/original.jpg",
                DurationWeeks = 18,
                Price = 400,
                CourseLevel = Enums.CourseLevel.Beginner,
            };
            var course3 = new Course()
            {
                Id = 3,
                Title = "ASP.NET",
                Description = "Платформа ASP.NET от компании Microsoft применяется для создания как простых web-сайтов, так и масштабных проектов – высоконадежных сетевых порталов, которые рассчитаны на многотысячную аудиторию. Благодаря безопасности и гибкости активно используется крупными компаниями: популярные сайты Microsoft, Lego, Volvo, Toyota, L'Oreal разработаны именно на ASP.NET.Сегодня ASP.NET – в авангарде web-разработки, а специалисты, работающие с этой технологией, находятся в числе самых востребованных в Беларуси. Как показывает статистика, выпускники IT-Academy, которые успешно оканчивают курсы по ASP.NET в Минске, быстрее находят работу.",
                Program = "1. Controllers and MVC",
                TopicTitle = topic1.Title,
                ImageUrl = "https://fiverr-res.cloudinary.com/images/t_main1,q_auto,f_auto,q_auto,f_auto/gigs/113201276/original/3adcfe36722f42c0a44f46a81f06064c9988fe3a/do-asp-dot-net-core-mvc-applications.png",
                DurationWeeks = 40,
                Price = 700,
                CourseLevel = Enums.CourseLevel.Advanced,
            };
            var course4 = new Course()
            {
                Id = 4,
                Title = "Unity",
                Description = "На современном движке Unity разработано более 50 процентов всех мобильных игр. Среди них – Albion Online, Pokemon GO, HearthStone, Inside и множество других крутых проектов. C помощью Unity можно разрабатывать приложения под любую платформу, само направление отличается относительно низким порогом вхождения, а еще имеет сильное комьюнити. Все это позволяет начинающему разработчику достаточно быстро освоиться в движке. Заинтересовались? Тогда записывайтесь на курсы по разработке игр на Unity в Минске.",
                Program = "1. What is Unity",
                TopicTitle = topic1.Title,
                ImageUrl = "https://unity.com/sites/default/files/styles/social_media_sharing_twitter/public/2019-11/unity-logo-600x400%402x.jpg?h=10d202d3&itok=LgYBHKk9",
                DurationWeeks = 30,
                Price = 600,
                CourseLevel = Enums.CourseLevel.Advanced
            };
            var course5 = new Course()
            {
                Id = 5,
                Title = "Бизнес-анализ в области разработки ПО",
                Description = "Данный специалист помогает максимально учесть цели и возможности организации в ходе работы над программными продуктами, даёт рекомендации по внедрению новых технологий с минимальными рисками. Именно бизнес-аналитик определяет потребности и предлагает эффективные решения, приносящие выгоды заинтересованным сторонам.",
                Program = "",
                TopicTitle = topic3.Title,
                ImageUrl = "https://analytics.infozone.pro/wp-content/uploads/2019/09/business_analysis_techniques-720x380.jpg",
                DurationWeeks = 24,
                Price = 1000,
                CourseLevel = Enums.CourseLevel.Advanced
            };
            var course6 = new Course()
            {
                Id = 6,
                Title = "Продвинутый курс по использованию нотации UML для практического анализа и визуального моделирования",
                Description = " Одним из важнейших направлений разработки информационных систем является метод визуальной интерпретации создаваемых решений, то есть моделирование. Грамотно выстроенная модель подобна хорошо проработанной топографической карте, которая с высокой степенью надежности гарантирует, что Вы не заблудитесь в хитросплетениях реальности, не всегда интерпретируемых однозначно.",
                Program = "",
                TopicTitle = topic3.Title,
                ImageUrl = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://coursera-course-photos.s3.amazonaws.com/db/00f7d7d51348529ad0323db833cd55/Cuadrado.png?auto=format%2Ccompress&dpr=1",
                DurationWeeks = 10,
                Price = 350,
                CourseLevel = Enums.CourseLevel.Advanced
            };
            var course7 = new Course()
            {
                Id = 7,
                Title = "Автоматизированное тестирование на Java",
                Description = "Тестировщик-автоматизатор или QA Automation engineer – это специалист, который отвечает за качество произведенного продукта. Главная его задача – писать автоскрипты, которые будут проверять работу ПО. Это позволяет упростить процесс тестирования и сократить время на выполнение задания.",
                Program = "1. What is Unity",
                TopicTitle = topic4.Title,
                ImageUrl = "https://grodno.in/source/photos/app/b_c291cmNlL3Bob3Rvcy8yMDIwLzAyLzEwL21ha2V0LW5vdnl5LmpwZw==_640_c1c1188269.jpg",
                DurationWeeks = 40,
                Price = 500,
                CourseLevel = Enums.CourseLevel.Advanced,
            };
            var course8 = new Course()
            {
                Id = 8,
                Title = "Автоматизированное тестирование на Python",
                Description = "Python подходит для автоматизации лучше, чем другие языки программирования благодаря своим характеристикам: он интерпретируемый, простой в изучении и более лаконичный. Язык кроссплатформенный, поэтому, за редким исключением, все приложения, написанные на нём, будут работать под любой системой. Среди плюсов также обширный набор библиотек и активная поддержка сообществом, так что, скорее всего, нужный модуль для ваших нужд уже написан.",
                Program = "",
                TopicTitle = topic4.Title,
                ImageUrl = "https://techrocks.ru/wp-content/uploads/2017/09/python-learn-logo.jpg",
                DurationWeeks = 34,
                Price = 700,
                CourseLevel = Enums.CourseLevel.Advanced,
            };
            var course9 = new Course()
            {
                Id = 9,
                Title = "Английский для начинающих ",
                Description = "Данный курс обеспечит получение базовых знаний, необходимых в повседневной жизни и профессиональной сфере.",
                Program = "",
                TopicTitle = topic5.Title,
                ImageUrl = "https://speakwell.co.in/wp-content/uploads/2017/08/3.jpg",
                DurationWeeks = 50,
                Price = 1000,
                CourseLevel = Enums.CourseLevel.Beginner,
            };
            var course10 = new Course()
            {
                Id = 10,
                Title = "Бизнес Английский ",
                Description = "Данный курс сочетает в себе элементы теоретического знания с практическими деловыми навыками, что позволяет закрепить базовые знания, развить устную речь и расширить словарный запас",
                Program = "1. What is Unity",
                TopicTitle = topic5.Title,
                ImageUrl = "https://is5-ssl.mzstatic.com/image/thumb/Purple127/v4/da/ef/da/daefda5e-2add-30ed-5689-9fd7f516b23b/source/512x512bb.jpg",
                DurationWeeks = 50,
                Price = 2000,
                CourseLevel = Enums.CourseLevel.Expert,
            };
            var course11 = new Course()
            {
                Id = 11,
                Title = "Обучение инструментам UI/UX дизайна",
                Description = "Ещё несколько лет назад Photoshop был абсолютным лидером по популярности среди digital-дизайнеров. Но постепенно начали появляться и другие, более специализированные, графические редакторы – такие как Figma и Sketch. Эти инструменты созданы специально для разработки веб-проектов и мобильных приложений и намного лучше подходят для UI/UX дизайна.",
                Program = "",
                TopicTitle = topic6.Title,
                ImageUrl = "https://media.istockphoto.com/vectors/unified-modeling-language-acronym-business-concept-vector-id1272853458?k=20&m=1272853458&s=612x612&w=0&h=-7X5_-FpAZfAHPUQgmcBUjVz6ueByOnTfTcXySWSA7Q=",
                DurationWeeks = 10,
                Price = 200,
                CourseLevel = Enums.CourseLevel.Beginner,
            };
            var course12 = new Course()
            {
                Id = 12,
                Title = "Веб-дизайн и дизайн мобильных интерфейсов",
                Description = " UI/UX и web-дизайн ориентирован на создание внешне привлекательных, удобных в использовании и функциональных пользовательских интерфейсов. Для того, чтобы достичь успеха в этой сфере, необходимо обладать художественным вкусом, быть внимательным к деталям, понимать принципы компьютерной графики и визуального дизайна, уметь работать с инструментами (например, Adobe Photoshop, Adobe Illustrator, Sketch, Figma).",
                Program = "1. What is Unity",
                TopicTitle = topic6.Title,
                ImageUrl = "https://thumbs.dreamstime.com/b/web-design-studio-web-site-responsive-design-presentation-computer-display-laptop-smart-phone-tablet-web-design-studio-web-175052877.jpg",
                DurationWeeks = 27,
                Price = 700,
                CourseLevel = Enums.CourseLevel.Advanced,
            };





            var teacher_1 = new Teacher()
            {
                Id = 1,
                EducationCenterUserId = user_1.Id,
                Bio = " teacher bio",
                LinkToProfile = " teacher link",
            };
            var teacher_2 = new Teacher()
            {
                Id = 2,
                EducationCenterUserId = user_2.Id,
                Bio = " teacher bio",
                LinkToProfile = " teacher link",
            };
            var teacher_3 = new Teacher()
            {
                Id = 3,
                EducationCenterUserId = user_3.Id,
                Bio = " teacher bio",
                LinkToProfile = " teacher link",
            };



           



            var group_1 = new Group()
            {
                Id = 1,
                CourseId = 1,
                Title = "first_group",
                Status = Enums.GroupStatus.NotStarted,
                StudentCapacity = 5,
                StudingType = Enums.StudingType.Mix
            };
            var group_2 = new Group()
            {
                Id = 2,
                CourseId = 2,
                Title = "second_group",
                Status = Enums.GroupStatus.NotStarted,
                StudentCapacity = 5,
                StudingType = Enums.StudingType.Online
            };
            var group_3 = new Group()
            {
                Id = 3,
                CourseId = 3,
                Title = "third_group",
                Status = Enums.GroupStatus.NotStarted,
                StudentCapacity = 5,
                StudingType = Enums.StudingType.InClass
            };
            var group_4 = new Group()
            {
                Id = 4,
                CourseId = 4,
                Title = "fourth_group",
                Status = Enums.GroupStatus.NotStarted,
                StudentCapacity = 5,
                StudingType = Enums.StudingType.Mix
            };



            var student_1 = new Student()
            {
                Id = 4,
                EducationCenterUserId = user_4.Id,
                GroupId = group_1.Id,
            };
            var student_2 = new Student()
            {
                Id = 5,
                EducationCenterUserId = user_5.Id,
                GroupId = group_2.Id,
            };
            var student_3 = new Student()
            {
                EducationCenterUserId = user_6.Id,
                Id = 6,
                GroupId = group_3.Id,

            };
            var student_4 = new Student()
            {
                Id = 7,
                EducationCenterUserId = user_7.Id,
                GroupId = group_1.Id,

            };
            var student_5 = new Student()
            {
                EducationCenterUserId = user_8.Id,
                Id = 8,
                GroupId = group_3.Id,

            };






            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
           new IdentityUserRole<string>
           {
               RoleId = teacher_role.Id,
               UserId = user_1.Id,
           },
            new IdentityUserRole<string>
            {
                RoleId = teacher_role.Id,
                UserId = user_2.Id,
            }, new IdentityUserRole<string>
            {
                RoleId = teacher_role.Id,
                UserId = user_3.Id,
            }
            , new IdentityUserRole<string>
            {
                RoleId = student_role.Id,
                UserId = user_4.Id,
            }
             , new IdentityUserRole<string>
             {
                 RoleId = student_role.Id,
                 UserId = user_5.Id,
             }, new IdentityUserRole<string>
             {
                 RoleId = student_role.Id,
                 UserId = user_6.Id,
             }, new IdentityUserRole<string>
             {
                 RoleId = student_role.Id,
                 UserId = user_7.Id,
             }, new IdentityUserRole<string>
             {
                 RoleId = student_role.Id,
                 UserId = user_8.Id,
             }
       );



            modelBuilder.Entity<EducationCenterUser>().HasData(user_1, user_2, user_3, user_4, user_5, user_6, user_7, user_8);
            modelBuilder.Entity<EducationCenterRole>().HasData(student_role, admin_role, manager_role, teacher_role);
            modelBuilder.Entity<Course>().HasData(course1, course2, course3, course4, course5, course6, course7, course8, course9, course10, course11, course12);
            modelBuilder.Entity<Topic>().HasData(topic1, topic2, topic3, topic4, topic5, topic6);
            modelBuilder.Entity<Student>().HasData(student_1, student_2, student_3, student_4, student_5);
            modelBuilder.Entity<Teacher>().HasData(teacher_1, teacher_2, teacher_3);
            modelBuilder.Entity<Group>().HasData(group_1, group_2, group_3, group_4);
       


        }


    }
}
