using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD
{
    public partial class FrmClubRegistration : Form
    {
        public FrmClubRegistration()
        {
            InitializeComponent();
        }

        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age;
        private int count = 0;
        private long StudentID;
        private string FirstName, MiddleName, LastName, Gender, Program;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmUpdateMember updateMember = new FrmUpdateMember();
            updateMember.Show();
        }

        private void RefreshListOfClubMembers()
        {
            //number 10 ni sya
            clubRegistrationQuery.DisplayList();
            dataGridView.DataSource = clubRegistrationQuery.bindingSource;
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            //number 11 ni sya
            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();
        }

        private int RegistrationID()
        {
            //number 12 ni sya
            return ++count;
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            ID = RegistrationID();
            StudentID = Convert.ToInt32(txtStudentID.Text);
            FirstName = txtFirstName.Text;
            MiddleName = txtMiddleName.Text;
            LastName = txtLastName.Text;
            Age = Convert.ToInt16(txtAge.Text);
            Gender = cmbGender.Text;
            Program = cmbProgram.Text;

            clubRegistrationQuery.RegisterStudent(ID, StudentID, FirstName, MiddleName, LastName, Age, Gender, Program);

            RefreshListOfClubMembers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

    }
}