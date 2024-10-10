using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace CRUD
{
    internal class ClubRegistrationQuery
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlDataAdapter;
        private SqlDataReader sqlDataReader;
        public DataTable dataTable;
        public BindingSource bindingSource;
        private string connectionString;
        public string _FirstName, _MiddleName, _LastName, _Gender, _Program;
        public int _Age;

        public ClubRegistrationQuery()
        {
            connectionString = @"Data Source = ADMINISTRATOR\PROGRAMMER;Initial Catalog = ClubDB; Integrated Security = True";
            sqlConnection = new SqlConnection(connectionString);
            dataTable = new DataTable();
            bindingSource = new BindingSource();
        }

        public bool DisplayList()
        {
            string ViewClubMembers = "SELECT StudentID, FirstName, MiddleName, LastName, Age, Gender, Program FROM ClubMembers";
            sqlDataAdapter = new SqlDataAdapter(ViewClubMembers, sqlConnection);
            dataTable.Clear();
            sqlDataAdapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;
            return true;
        }

        public bool RegisterStudent(int ID, long StudentID, string FirstName, string MiddleName, string LastName, int Age, string Gender, string Program)
        {
            sqlCommand = new SqlCommand("INSERT INTO ClubMember VALUES(@ID, @StudentID, @FirstName, @MiddleName, @LastName, @Age, @Gender, @Program)", sqlConnection);
            sqlCommand.Parameters.Add("ID", SqlDbType.Int).Value = ID;
            sqlCommand.Parameters.Add("@RegistrationID", SqlDbType.BigInt).Value = StudentID;
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = StudentID;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
            sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = Program;

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return true;
        }

        public bool UpdateStudent(long StudentID, int Age, string Program)
        {
            sqlCommand = new SqlCommand("UPDATE ClubMembers SET Age = @Age, Program = @Program WHERE StudentID = @StudentID, sqlConnect");
            sqlCommand.Parameters.AddWithValue("@StudentID", StudentID);
            sqlCommand.Parameters.AddWithValue("@Age", Age);
            sqlCommand.Parameters.AddWithValue("@Program", Program);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        public void DisplayID(ComboBox comboBox)
        {
            string getID = "SELECT * FROM ClubMembers";
            sqlCommand = new SqlCommand(getID, sqlConnection);
            sqlConnection.Open();
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                comboBox.Items.Add(sqlDataReader["StudentID"]);
            }
            sqlConnection.Close();
        }

        public void DisplayText(string id)
        {
            string getId = "SELECT * FROM ClubMembers WHERE StudentID = @Id";
            sqlCommand = new SqlCommand(getId, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                _FirstName = sqlDataReader.GetString(2);
                _MiddleName = sqlDataReader.GetString(3);
                _LastName = sqlDataReader.GetString(4);
                _Age = sqlDataReader.GetInt32(5);
                _Gender = sqlDataReader.GetString(6);
                _Program = sqlDataReader.GetString(7);
            }
            sqlConnection.Close();
        }
    }

}
