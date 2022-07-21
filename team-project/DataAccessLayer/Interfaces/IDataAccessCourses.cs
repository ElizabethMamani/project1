// <copyright file="IDataAccessCourses.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DataAccessLayer.Interfaces
{
    using Models;

    public interface IDataAccessCourses
    {
        public IEnumerable<Course>? GetAllCourses();

        public Course GetCourse(int id);

        public Course? AddCourse(Course course);

        public Course? UpdateCourse(int id, Course course);

        public int DeleteCourse(int id);
    }
}
