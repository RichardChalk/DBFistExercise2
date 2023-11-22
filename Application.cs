﻿using DBFistExercise2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFistExercise2
{
    internal class Application
    {

        public void Run()
        {
            using (var _db = new StudentContext())
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("1. Create new course");
                    Console.WriteLine("2. List all courses");
                    Console.WriteLine("3. Create new student");
                    Console.WriteLine("4. List all students");
                    Console.WriteLine("5. Find student by ID");
                    Console.WriteLine("0. Avsluta");

                    int sel = Convert.ToInt32(Console.ReadLine());

                    // Create new - Create new - Create new - Create new - Create new - 
                    if (sel == 1)
                    {
                        Console.Clear();
                        var course = new Kur();
                        Console.WriteLine("Course Name: ");
                        course.Namn = Console.ReadLine();

                        _db.Add(course);
                        _db.SaveChanges();
                    }

                    // List Courses -  List Courses - List Courses - List Courses - List Courses -
                    if (sel == 2)
                    {
                        Console.Clear();
                        foreach (var course in _db.Kurs)
                        {
                            Console.WriteLine($"Course name: {course.Namn}");
                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                    }

                    // Create new - Create new - Create new - Create new - Create new - 
                    if (sel == 3)
                    {
                        Console.Clear();
                        var student = new Student();
                        Console.WriteLine("Students Firstname: ");
                        student.Fornamn = Console.ReadLine();

                        Console.WriteLine("Students Surname: ");
                        student.Efternamn = Console.ReadLine();

                        Console.WriteLine("Students birthdate (yyyy-mm-dd): ");
                        student.Birthdate = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine();
                        Console.WriteLine("These are the available course ids:");
                        foreach (var course in _db.Kurs)
                        {
                            Console.WriteLine($"Course ID: {course.Id} Course Name: {course.Namn}");
                        }

                        Console.WriteLine("Choose one of the course IDs above: ");
                        student.KursId = Convert.ToInt32(Console.ReadLine());

                        _db.Add(student);
                        _db.SaveChanges();
                    }

                    // List Students -  List Students - List Students - List Students - List Students -
                    if (sel == 4)
                    {
                        Console.Clear();
                        foreach (var student in _db.Students)
                        {
                            Console.WriteLine($"Student name: {student.Fornamn} {student.Efternamn}");
                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                    }

                    // Find student -  Find student -  Find student -  Find student -  Find student - 
                    if (sel == 5)
                    {
                        Console.Clear();
                        Console.WriteLine("What is the Id of the student you are looking for?");
                        int idToSearch = Convert.ToInt32(Console.ReadLine());

                        var foundStudent = _db.Students
                            .Where(s => s.Id == idToSearch)
                            .FirstOrDefault();

                        if (foundStudent == null)
                        {
                            Console.WriteLine("No student exists with that Id");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                            continue;
                        }

                        Console.WriteLine($"Student Id: {foundStudent.Fornamn} {foundStudent.Efternamn}");

                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                    }

                    if (sel == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}

