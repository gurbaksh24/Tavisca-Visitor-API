﻿using DALCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeService
{
    public interface IEmployee
    {
        List<Employees> GetAllEmployees();
        string EditEmployee(Employees employee);
        bool AddNewEmployee(Employees employee);
        string GetEmployeeNameById(string UserId);
        List<EmployeeLogs> GetAllEmployeesLogs();
        void AddEmployeeLog(string EmployeeId);
        List<EmployeeLogs> GetEmployeeLogByName(string EmployeeName);
        List<EmployeeLogs> GetEmployeeLogsByDate(string fromDate, string toDate, string fromTime, string toTime);
        List<EmployeeLogs> GetEmployeeLogsByNameAndDate(string nameOfEmployee, string fromDate, string toDate, string fromTime, string toTime);
        Employees GetEmployeeDetailsById(string UserId);
        string LogEmployeeExit(string EmplpyeeId);
        List<EmployeeLogs> GetEmployeeLogsById(string EmployeeId);
    }
}
