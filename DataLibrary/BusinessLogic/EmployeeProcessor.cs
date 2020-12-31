using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;

namespace DataLibrary.BusinessLogic
{
    public static class EmployeeProcessor
    {
        public static int CreateEmployee(int employeeId, string firstName, 
            string lastName, string emailAddress)
        {
            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            string sql = @"insert into dbo.EmployeesTable(EmployeeId, FirstName, LastName, EmailAddress)
                            values (@EmployeeId, @FirstName, @LastName, @EmailAddress);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = @"select Id, EmployeeId, FirstName, LastName, EmailAddress
                            from dbo.EmployeesTable;";

            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }

        public static void DeleteEmployee(int empNum)
        {
            string sql = @"DELETE from dbo.EmployeesTable where EmployeeId = " +empNum;

            SqlDataAccess.DeleteData(sql);
        }

    }
}
