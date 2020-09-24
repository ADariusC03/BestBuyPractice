using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyExercisePractice
{
    public interface IDepartmentRepository
    {
        //You need a method called GetAllDepartments that return a collection
        //That conforms to IEnumerable<T>, which can be a string, list, or int.
        IEnumerable<Department> GetAllDepartments();
        void InsertDepartment(string newDepartmentName);
    }
}
