﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Core.Contracts;
using Core.Contracts.Models;
using DALCore.Models;
using Microsoft.EntityFrameworkCore;
using UserService;
using SQLDatabase;

namespace VisitorService
{
    public class VisitorManager : IVisitor
    {
        static List<VisitorsData> AllLogs = new List<VisitorsData>();
        static List<Visitors> AllVisitors = new List<Visitors>();
        public List<VisitorsData> GetAllVisitorsFromLog()
        {
            try
            {
                ClearList();
                VisitorDatabase visitorDatabase = new VisitorDatabase();
                List<VisitorsLogs> visitorLogsList = visitorDatabase.GetAllVisitorLogs();
                foreach (var entry in visitorLogsList)
                {
                    GetVisitorData(entry);
                }
                return AllLogs;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Visitors From Log. Please try again" + ex.StackTrace);
            }
        }
        public void GetVisitorData(VisitorsLogs visitor)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                Visitors visitorData = entity.Visitors.Find(visitor.VisitorId);
                VisitorsData entry = new VisitorsData();
                entry.NameOfVisitor = visitorData.NameOfVisitor;
                entry.GovtIdProof = visitorData.GovtIdProof;
                entry.Contact = visitorData.Contact;
                entry.ComingFrom = visitor.ComingFrom;
                entry.WhomToMeet = visitor.WhomToMeet;
                entry.EmployeeId = visitor.EmployeeId;
                entry.TimeIn = visitor.TimeIn.ToString();
                entry.TimeOut = visitor.TimeOut.ToString();
                entry.VisitorId = visitor.VisitorId;
                entry.GuardId = visitor.GuardId;
                entry.DateOfVisit = visitor.DateOfVisit.ToString();
                AllLogs.Add(entry);
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Exception: GetVisitorData" + ex.StackTrace);
            }
        }
        public List<VisitorsData> GetVisitorsLogByName(string searchInput)
        {
            try
            {
                ClearList();
                //var entity = new VisitorsDatabaseContext();
                //List<Visitors> visitorLogsList = entity.Visitors.FromSql("select * from Visitors where NameOfVisitor = @searchInput", new SqlParameter("@searchInput", searchInput)).ToList<Visitors>();
                VisitorDatabase visitorDatabase = new VisitorDatabase();
                List<Visitors> visitorLogsList = visitorDatabase.GetVisitorsByName(searchInput);
                foreach (var entry in visitorLogsList)
                {
                    GetVisitorDataByName(entry);
                }
                return AllLogs;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Visitors From Log. Please try again" + ex.StackTrace);
            }
        }
        public void GetVisitorDataByName(Visitors visitor)
        {
            try
            {
                //var entity = new VisitorsDatabaseContext();
                //List<VisitorsLogs> visitorData = entity.VisitorsLogs.FromSql("select * from VisitorsLogs where VisitorId = @searchInput", new SqlParameter("@searchInput", visitor.VisitorId)).ToList<VisitorsLogs>();
                VisitorDatabase visitorDatabase = new VisitorDatabase();
                List<VisitorsLogs> visitorData = visitorDatabase.GetVisitorLogsById(visitor.VisitorId);
                foreach (var result in visitorData)
                {
                    VisitorsData entry = new VisitorsData();
                    entry.NameOfVisitor = visitor.NameOfVisitor;
                    entry.GovtIdProof = visitor.GovtIdProof;
                    entry.Contact = visitor.Contact;
                    entry.ComingFrom = result.ComingFrom;
                    entry.WhomToMeet = result.WhomToMeet;
                    entry.EmployeeId = result.EmployeeId;
                    entry.TimeIn = result.TimeIn.ToString();
                    entry.TimeOut = result.TimeOut.ToString();
                    entry.VisitorId = result.VisitorId;
                    entry.GuardId = result.GuardId;
                    entry.DateOfVisit = result.DateOfVisit.ToString();
                    AllLogs.Add(entry);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Exception: GetVisitorDataByName" + ex.StackTrace);
            }
        }
        public List<VisitorsData> GetVisitorsLogByMeetingPerson(string whomToMeet)
        {
            try
            {
                ClearList();
                //var entity = new VisitorsDatabaseContext();
                //List<VisitorsLogs> visitorLogsList = entity.VisitorsLogs.FromSql("select * from VisitorsLogs where WhomToMeet = @searchInput", new SqlParameter("@searchInput", SearchInput)).ToList<VisitorsLogs>();
                VisitorDatabase visitorDatabase = new VisitorDatabase();
                List<VisitorsLogs> visitorLogsList = visitorDatabase.GetVisitorLogsByWhomToMeet(whomToMeet);
                foreach (var entry in visitorLogsList)
                {
                    GetVisitorDataByMeetingPerson(entry, whomToMeet);
                }
                return AllLogs;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Visitors From Log. Please try again" + ex.StackTrace);
            }
        }
        public void GetVisitorDataByMeetingPerson(VisitorsLogs visitor, string searchInput)
        {
            try
            {
                //var entity = new VisitorsDatabaseContext();
                //Visitors visitorData = entity.Visitors.FromSql("select * from Visitors where VisitorId = @searchInput", new SqlParameter("@searchInput", visitor.VisitorId)).SingleOrDefault();
                VisitorDatabase visitorDatabase = new VisitorDatabase();
                Visitors visitorData = visitorDatabase.GetVisitorById(visitor.VisitorId);
                //foreach (var result in visitorData)
                //{
                    VisitorsData entry = new VisitorsData();
                    entry.NameOfVisitor = visitorData.NameOfVisitor;
                    entry.GovtIdProof = visitorData.GovtIdProof;
                    entry.Contact = visitorData.Contact;
                    entry.ComingFrom = visitor.ComingFrom;
                    entry.WhomToMeet = visitor.WhomToMeet;
                    entry.EmployeeId = visitor.EmployeeId;
                    entry.TimeIn = visitor.TimeIn.ToString();
                    entry.TimeOut = visitor.TimeOut.ToString();
                    entry.VisitorId = visitor.VisitorId;
                    entry.DateOfVisit = visitor.DateOfVisit.ToString();
                    entry.GuardId = visitor.GuardId;
                    AllLogs.Add(entry);
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Exception: GetVisitorDataByMeetingPerson" + ex.StackTrace);
            }
        }
        public List<VisitorsData> GetVisitorLogByDate(string fromDate, string toDate, string fromTime, string toTime)
        {
            try
            {
                ClearList();
                if (fromTime == "" && toTime == "")
                {
                    fromTime = "00:00:00";
                    toTime = "23:59:59";
                }
                var entity = new VisitorsDatabaseContext();
                List<VisitorsLogs> visitorLogsList = entity.VisitorsLogs.FromSql("select * from VisitorsLogs where DateOfVisit between @fromDate And @toDate and TimeIn >= @fromTime and TimeOut <= @toTime", new SqlParameter("@fromDate", fromDate), new SqlParameter("@toDate", toDate), new SqlParameter("@fromTime", fromTime), new SqlParameter("@toTime", toTime)).ToList<VisitorsLogs>();
                foreach (var entry in visitorLogsList)
                {
                    GetVisitorData(entry);
                }

                return AllLogs;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Visitors From Log. Please try again" + ex.StackTrace);
            }
        }
        public List<VisitorsData> GetVisitorLogByPurposeOfVisitor(string searchInput)
        {
            try
            {
                ClearList();
                var entity = new VisitorsDatabaseContext();
                List<VisitorsLogs> visitorLogsList = entity.VisitorsLogs.FromSql("select * from VisitorsLogs where PurposeOfVisit = @purpose", new SqlParameter("@purpose", searchInput)).ToList<VisitorsLogs>();
                foreach (var entry in visitorLogsList)
                {
                    GetVisitorData(entry);
                }
                return AllLogs;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Visitors From Log. Please try again" + ex.StackTrace);
            }
        }
        public List<VisitorsData> GetVisitorLogByNameAndDate(string nameOfVisitor, string fromDate, string toDate, string fromTime, string toTime)
        {
            try
            {
                ClearList();
                List<VisitorsData> allLogsByDateProvided = GetVisitorLogByDate(fromDate, toDate, fromTime, toTime);
                IEnumerable<VisitorsData> allLogsByDateAndName = allLogsByDateProvided.Where(entry => entry.NameOfVisitor.Equals(nameOfVisitor));
                return allLogsByDateAndName.ToList<VisitorsData>();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Visitors From Log. Please try again" + ex.StackTrace);
            }
        }

        //Unique Visitor Data: 
        public List<Visitors> GetUniqueVisitors()
        {
            try
            {
                ClearList();
                var entity = new VisitorsDatabaseContext();
                List<Visitors> visitorsList = entity.Visitors.ToList<Visitors>();
                foreach (var entry in visitorsList)
                {
                    Visitors uniqueVisitor = new Visitors();
                    uniqueVisitor.VisitorId = entry.VisitorId;
                    uniqueVisitor.NameOfVisitor = entry.NameOfVisitor;
                    uniqueVisitor.GovtIdProof = entry.GovtIdProof;
                    uniqueVisitor.Contact = entry.Contact;
                    AllVisitors.Add(uniqueVisitor);
                }
                return AllVisitors;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Visitors. Please try again" + ex.StackTrace);
            }
        }
        public List<Visitors> GetUniqueVisitorsByName(string searchInput)
        {
            try
            {
                ClearList();
                var entity = new VisitorsDatabaseContext();
                List<Visitors> visitorsList = entity.Visitors.Where(entry => entry.NameOfVisitor == searchInput).ToList<Visitors>();
                foreach (var entry in visitorsList)
                {
                    Visitors uniqueVisitor = new Visitors();
                    uniqueVisitor.VisitorId = entry.VisitorId;
                    uniqueVisitor.NameOfVisitor = entry.NameOfVisitor;
                    uniqueVisitor.GovtIdProof = entry.GovtIdProof;
                    uniqueVisitor.Contact = entry.Contact;
                    AllVisitors.Add(uniqueVisitor);
                }
                return AllVisitors;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get Visitors. Please try again" + ex.StackTrace);
            }
        }
        public void AddNewVisitor(NewVisitorFormData newVisitorData)
        {
            var entity = new VisitorsDatabaseContext();
            Visitors NewVisitor = new Visitors();
            NewVisitor.NameOfVisitor = newVisitorData.nameOfVisitor;
            NewVisitor.Contact = newVisitorData.contactNo;
            NewVisitor.VisitorImage = "image"; // Call add new face from here, leaving for now
            NewVisitor.GovtIdProof = newVisitorData.govtIdProof;
            AddNewVisitorLog(newVisitorData);
        }
        public void AddNewVisitorLog(NewVisitorFormData VisitorData)
        {
            var entity = new VisitorsDatabaseContext();
            List<Visitors> visitorEntry = entity.Visitors.Where(entry => entry.NameOfVisitor == VisitorData.nameOfVisitor).ToList<Visitors>();
            List<Employees> empEntry = entity.Employees.Where(entry => entry.EmployeeName == VisitorData.whomToMeet).ToList<Employees>();
            VisitorsLogs newLog = new VisitorsLogs();
            newLog.ComingFrom = VisitorData.comingFrom;
            newLog.WhomToMeet = VisitorData.whomToMeet;
            newLog.EmployeeId = empEntry[0].EmployeeId;
            newLog.DateOfVisit = DateTime.Today;
            newLog.TimeIn = DateTime.Now.TimeOfDay;
            newLog.VisitorId = visitorEntry[0].VisitorId;
            newLog.GuardId = VisitorData.guardId;
            newLog.PurposeOfVisit = VisitorData.purposeOfVisit;
            entity.VisitorsLogs.Add(newLog);
            entity.SaveChanges();
        }
        public List<MatchingSubstring> AllMatchingEmployeeNames(string userInput)
        {
            List<MatchingSubstring> MatchingResults = new List<MatchingSubstring>();
            var entity = new VisitorsDatabaseContext();
            userInput = "%" + userInput + "%";
            List<Employees> employeesList = entity.Employees.FromSql("select * from Employees where EmployeeName Like @searchInput", new SqlParameter("@searchInput", userInput)).ToList<Employees>();
            foreach(var Entry in employeesList)
            {
                MatchingSubstring name = new MatchingSubstring();
                name.MatchingResult = Entry.EmployeeName;
                MatchingResults.Add(name);
            }
            return MatchingResults;
        }
        public int SendAndReturnOtp(string ContactNo)
        {
            try
            {
                SMSGeneration smsGeneration = new SMSGeneration();
                int otp;
                return otp = smsGeneration.SMS(Convert.ToInt64(ContactNo));
            }
            catch (Exception ex)
            {
                throw new Exception("Could not update password. Please try again" + ex.StackTrace);
            }
        }
        public string GetVisitorNameById(int Id)
        {
            var entity = new VisitorsDatabaseContext();
            Visitors Visitor = entity.Visitors.Where(entry => entry.VisitorId == Id).FirstOrDefault();
            return Visitor.NameOfVisitor;
        }
        public void SaveVisitorExitTime(int Id)
        {
            var entity = new VisitorsDatabaseContext();
            VisitorsLogs ExistingLog = entity.VisitorsLogs.Where(entry => entry.VisitorId == Id).FirstOrDefault();
            ExistingLog.TimeOut = DateTime.Now.TimeOfDay;
            entity.SaveChanges();
        }
        public void ClearList()
        {
            AllLogs.Clear();
            AllVisitors.Clear();
        }
    }
}
