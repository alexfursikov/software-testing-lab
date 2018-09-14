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
            Student s1 = new Student();
            Student s2 = new Student(new int[] { 1, 2, 3,5,2,4,6,4,3 });
            Student s3 = new Student(new int[] { 10,7,9,8,9,10,9,7,8,8 });
            s1.calcAverageForStudent();
            s2.calcAverageForStudent();
            s3.calcAverageForStudent();

            Group group2 = new Group(2);
            group2.addStudent(s1);
            group2.addStudent(s2);

            Group group2 = new Group(1);
            group2.addStudent(s3);

            group2.calcAverageForGroup(1);
            group2.calcAverageForGroup(2);
            group2.calcAverageForGroup(2);
        }
    }
}
