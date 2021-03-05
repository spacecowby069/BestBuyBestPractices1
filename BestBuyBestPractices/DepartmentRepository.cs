using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace BestBuyBestPractices
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
        }

        public void UpdateDepartment(int id, string newName)
        {
            _connection.Execute("UPDATE departments SET Name = @newName WHERE DepartmentID = @id;", new { newName = newName, id = id });
        }

        
    }
}
