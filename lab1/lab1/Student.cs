using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Student
    {
        public int[] note;

        public Student()
        {
            note = new int[] { 6, 8, 5, 8, 9, 4, 4 };
        }

        public Student(int[] arr)
        {
            note = arr;
        }

        public void calcAverageForStudent() //func average rating
        {
            Console.WriteLine("Average grade of the selected student: {0}", Math.Round(note.Average(),2));
        }       
    }


}
