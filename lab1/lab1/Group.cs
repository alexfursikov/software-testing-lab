using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    struct Group
    {
        int group;
        List<Student> students;

        public Group(int group)
        {
            this.group = group;
            this.students = new List<Student>();
        }

        public void addStudent(Student student) //func add Student
        {
            students.Add(student);
        }

        public void calcAverageForGroup(int group)
        {
            int count = 0;
            double average = 0;
            foreach (Student item in students)
            {
                average += item.note.Average();
                count++;
            }
            Console.WriteLine("Average score for the group: {0}", Math.Round(average/count,2));
        }
    }
}
