using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{

    namespace RepositoryLayer.Services
    {
        public class EmployeeRL : IEmployeeRL
        {
           
            private readonly IConfiguration _config;
            public string ConnectionStringName { get; set; } = "EmployeePayRollMVC";
            public EmployeeRL(IConfiguration config)
            {
                _config = config;
            }
                
            public IEnumerable<EmployeeModel> GetAllEmployees()
            {
                string connectionString = _config.GetConnectionString(ConnectionStringName);

                List<EmployeeModel> lstemployee = new List<EmployeeModel>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EmployeeModel employee = new EmployeeModel();

                        employee.Empid = Convert.ToInt32(rdr["Empid"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Profile_Image = rdr["Profile_Image"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.Salary = rdr["Salary"].ToString();
                        employee.Start_date = rdr["Start_date"].ToString();
                        employee.Notes = rdr["Notes"].ToString();


                        lstemployee.Add(employee);
                    }
                    con.Close();
                }
                return lstemployee;
            }

            //To Add new employee record      
            public void AddEmployee(EmployeeModel employee)
            {
                string connectionString = _config.GetConnectionString(ConnectionStringName);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_Emp_PayRollForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Profile_Image", employee.Profile_Image);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@Start_Date", employee.Start_date);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            //To Update the records of a particluar employee    
            public void UpdateEmployee(EmployeeModel employee)
            {
                string connectionString = _config.GetConnectionString(ConnectionStringName);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Empid", employee.Empid);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Profile_Image", employee.Profile_Image);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@Start_Date", employee.Start_date);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }




            //To Delete the record on a particular employee    
            public void DeleteEmployee(int? id)
            {
                string connectionString = _config.GetConnectionString(ConnectionStringName);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Empid", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

          
            //Get the details of a particular employee    

            public EmployeeModel GetEmployeeData(int? id)
            {
                EmployeeModel employee = new EmployeeModel();
                string connectionString = _config.GetConnectionString(ConnectionStringName);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM EmployeePayrollForm WHERE Empid= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        employee.Empid = Convert.ToInt32(rdr["Empid"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Profile_Image = rdr["Profile_Image"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.Salary = rdr["Salary"].ToString();
                        employee.Start_date = rdr["Start_date"].ToString();
                        employee.Notes = rdr["Notes"].ToString();
                    }
                }
                return employee;
            }
        }
    }
 }