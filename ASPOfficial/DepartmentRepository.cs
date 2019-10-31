using System;
using System.Collections.Generic;
using ASPOfficial.Models;
using MySql.Data.MySqlClient;

namespace ASPOfficial
{
    public class DepartmentRepository
    {
        private static string connectionString = System.IO.File.ReadAllText("ConnectionString.txt");

        public List<Departments> GetDepartments()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Departments;";

            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Departments> allDepartments = new List<Departments>();

                while (reader.Read() == true)
                {
                    var currentDepartment = new Departments();
                    currentDepartment.DepartmentID = reader.GetInt32("DepartmentID");
                    currentDepartment.Name = reader.GetString("Name");

                    allDepartments.Add(currentDepartment);
                }
                return allDepartments;
            }

        }

        public List<Departments> ViewDepartment(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Departments WHERE DepartmentId = @id;";
            cmd.Parameters.AddWithValue("id", id);

            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Departments> dep = new List<Departments>();

                while (reader.Read() == true)
                {
                    var currentDep = new Departments();
                    currentDep.DepartmentID = reader.GetInt32("DepartmentID");
                    currentDep.Name = reader.GetString("Name");

                    dep.Add(currentDep);
                }
                return dep;
            }
        }
    }
}
