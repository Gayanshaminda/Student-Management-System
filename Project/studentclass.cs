using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Project
{
    public class studentclass
    {
        DBconnection connect = new DBconnection();

        public bool insertStudent(string fname, string lname, DateTime bdate, string phone, string gender, string address, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `student`(`StdFirstName`, `StdLastName`, `Birthday`, `Gender`, `Phone`, `Address`, `Photo`) VALUES(@fn, @ln, @bd, @gd, @ph, @adr, @img)", connect.getconnection);

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;

            connect.openconnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeconnect();  
                return true;
            }
            else
            {
                connect.closeconnect();  
                return false;
            }
        }

        //To get the student table
        public DataTable getStudentlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student` ",connect.getconnection);
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


    }
}
