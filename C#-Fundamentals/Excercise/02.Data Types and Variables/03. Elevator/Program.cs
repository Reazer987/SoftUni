﻿using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int coursesCount = 0;

            while(persons>0)
            {
                persons -= capacity;
                coursesCount++;
            }
            Console.WriteLine(coursesCount);


        }
    }
}
