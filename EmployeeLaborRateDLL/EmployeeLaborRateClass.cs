/* Title:           Employee Labor Rate Class
 * Date:            2-5-18
 * Author:          Terry Holmes
 * 
 * Description:     This class is for employee labor rate */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace EmployeeLaborRateDLL
{
    public class EmployeeLaborRateClass
    {
        //setting up the class
        EventLogClass TheEventLogClass = new EventLogClass();

        EmployeeLaborRateDataSet aEmployeeLaborRateDataSet;
        EmployeeLaborRateDataSetTableAdapters.employeelaborrateTableAdapter aEmployeeLaborRateTableAdapter;

        InsertEmployeeLaborRateEntryTableAdapters.QueriesTableAdapter aInsertEmployeeLaborRateTableAdapter;

        UpdateEmployeeLaborRateEntryTableAdapters.QueriesTableAdapter aUpdateEmployeeLaborRateTableAdapter;

        FindEmployeeLaborRateDataSet aFindEmployeeLaborRateDataSet;
        FindEmployeeLaborRateDataSetTableAdapters.FindEmployeeLaborRateTableAdapter aFindEmployeeLaborRateTableAdapter;

        public FindEmployeeLaborRateDataSet FindEmployeeLaborRate(int intEmployeeID)
        {
            try
            {
                aFindEmployeeLaborRateDataSet = new FindEmployeeLaborRateDataSet();
                aFindEmployeeLaborRateTableAdapter = new FindEmployeeLaborRateDataSetTableAdapters.FindEmployeeLaborRateTableAdapter();
                aFindEmployeeLaborRateTableAdapter.Fill(aFindEmployeeLaborRateDataSet.FindEmployeeLaborRate, intEmployeeID);
            }
            catch(Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Labor Rate Class // Find Employee Labor Rate " + Ex.Message);
            }

            return aFindEmployeeLaborRateDataSet;
        }
        public bool UpdateEmployeeLaborRate(int intEmployeeID, decimal decPayRate)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateEmployeeLaborRateTableAdapter = new UpdateEmployeeLaborRateEntryTableAdapters.QueriesTableAdapter();
                aUpdateEmployeeLaborRateTableAdapter.UpdateEmployeeLaborRate(intEmployeeID, decPayRate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Labor Rate // Update Employee Labor Rate " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertEmployeeLaborRate(int intEmployeeID, decimal decPayRate)
        {
            bool blnFatalError = false;

            try
            {
                aInsertEmployeeLaborRateTableAdapter = new InsertEmployeeLaborRateEntryTableAdapters.QueriesTableAdapter();
                aInsertEmployeeLaborRateTableAdapter.InsertEmployeeLaborRate(intEmployeeID, decPayRate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Labor Rate // Insert Employee Labor Rate " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public EmployeeLaborRateDataSet GetEmployeeLaborRateInfo()
        {
            try
            {
                aEmployeeLaborRateDataSet = new EmployeeLaborRateDataSet();
                aEmployeeLaborRateTableAdapter = new EmployeeLaborRateDataSetTableAdapters.employeelaborrateTableAdapter();
                aEmployeeLaborRateTableAdapter.Fill(aEmployeeLaborRateDataSet.employeelaborrate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Labor Rate Class // Get Employee Labor Rate Info " + Ex.Message);
            }

            return aEmployeeLaborRateDataSet;
        }
        public void UpdateEmployeeLaborRateDB(EmployeeLaborRateDataSet aEmployeeLaborRateDataSet)
        {
            try
            {
                aEmployeeLaborRateTableAdapter = new EmployeeLaborRateDataSetTableAdapters.employeelaborrateTableAdapter();
                aEmployeeLaborRateTableAdapter.Update(aEmployeeLaborRateDataSet.employeelaborrate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Employee Labor Rate Class // Update Employee Labor Rate DB " + Ex.Message);
            }
        }
    }
}
