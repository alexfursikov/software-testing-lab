using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student_1 = new Student();
            Student student_2 = new Student(new int[] { 1, 2, 3,5,2,4,6,4,3 });
            Student student_3 = new Student(new int[] { 10,7,9,8,9,10,9,7,8,8 });
            student_1.calcAverageForStudent();
            student_2.calcAverageForStudent();
            student_3.calcAverageForStudent();

            Group group2 = new Group(2);
            group2.addStudent(student_1);
            group2.addStudent(student_2);

            Group group2 = new Group(1);
            group2.addStudent(student_3);

            group2.calcAverageForGroup(1);
            group2.calcAverageForGroup(2);
        }
    }
}
