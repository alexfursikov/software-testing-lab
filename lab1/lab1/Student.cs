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
            note = new int[] { 7, 7, 7, 8, 9, 9, 9 };
        }

        public Student(int[] arr)
        {
            note = arr;
        }

        public void calcAverageForStudent()
        {
            Console.WriteLine("Средняя оценка выбранного студента: {0}", Math.Round(note.Average(),2));
        }       
    }


}
