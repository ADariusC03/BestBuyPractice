using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyExercisePractice
{
    class DapperDepartmentRepository : IDepartmentRepository
    {
        //Properties of a local variable for the class itself
        //the only place to give it value is through the constructor
        //Field or (local variable) for making queries to the DB
        private readonly IDbConnection _connection;

        //Constructor
        public DapperDepartmentRepository(IDbConnection connection)
        {
            //the feild _connection value comes from the parameter connection

            _connection = connection;
        }

        //Method
        public IEnumerable<Department> GetAllDepartments()
        {
            //variable depos is made up just to give the variable a name and return type
            // Could say return _connection.Query < Department >("SELECT * FROM departments");

            var depos = _connection.Query<Department>("SELECT * FROM departments");

            return depos;
        }

        public void InsertDepartment(string newDepartmentName)
        {
            //in SQL, the prefix @ is a variable use as a string interpolation.
            // use the variable value to give this row of data a name
            //@departmentsName vaule comes from the anonymous string type, and the value comes from the parameter
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentsName);",
            new { departmentName = newDepartmentName });
        }
    }
}
