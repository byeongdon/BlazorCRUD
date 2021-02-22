using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BlazorFirst.Server.Model;
using System.Data;
using Dapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorFirst.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public static string connectionStr = @"Server=localhost;Port=3306;Database=ack_test;Uid=root;Pwd=1234;";

        // GET: api/<StudentController>
        [HttpGet]
        public List<Student> Get()
        {
            using (IDbConnection connection = new MySqlConnection(connectionStr))
            {
                connection.Open();
                string readQuery = "select * from student;";
                List<Student> students = connection.Query<Student>(readQuery).ToList();
                connection.Close();
                return students;
            }
        }
        
        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student value)
        {
            using (IDbConnection connection = new MySqlConnection(connectionStr))
            {
                string grade = value.Grade;
                string cClass = value.CClass;
                string no = value.No;
                string name = value.Name;
                string score = value.Score;

                string queryData = "'" + grade + "' , '" + cClass + "' , '" + no + "' , '" + name + "' , '" + score + "'";
                string insertQuery = "INSERT INTO student(Grade, CClass, No, Name, Score) VALUES(" + queryData + "); ";

                connection.Open();

                connection.Execute(insertQuery);
                connection.Close();
            }
        }

        // PUT api/<StudentController>
        [HttpPut]
        public void Put([FromBody] Student value)
        {
            using (IDbConnection connection = new MySqlConnection(connectionStr))
            {
                string grade = value.Grade;
                string cClass = value.CClass;
                string no = value.No;
                string name = value.Name;
                string score = value.Score;

                string updateQuery = "UPDATE student SET Grade = '" + grade + "', CClass = '" + cClass +
                                    "', Name = '" + name + "', Score = '" + score + "' WHERE No = '" + no + "';";

                connection.Open();
                connection.Execute(updateQuery);
                connection.Close();

            }
        }

        // DELETE api/<StudentController>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionStr))
            {
                

                string deleteQuery = "DELETE FROM student WHERE No ='" + id + "';";

                connection.Open();
                connection.Execute(deleteQuery);
                connection.Close();
            }
        }
    }
}
