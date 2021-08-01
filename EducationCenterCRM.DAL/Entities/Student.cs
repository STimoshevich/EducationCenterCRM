using EducationCenterCRM.DAL.Enums;

namespace EducationCenterCRM.DAL.Entities
{
    public class Student : Person
    {

        public StudentType Type { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }




    }
}
