using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLab1
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string studentNo = txtStudentNo.Text;
            string program = cbProgram.Text;
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string middleInitial = txtMI.Text;
            string age = txtAge.Text;
            string gender = cbGender.Text;
            string birthday = dateTimeBirthday.Value.ToString("yyyy-MM-dd");
            string contactNo = txtContactNo.Text;

            string fileName = studentNo + ".txt";

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(docPath, fileName);

            //desired format
            string[] studentInfoArray = {
                "Student No: " + studentNo,
                "Full Name: " + firstName + " " + middleInitial + " " + lastName,
                "Program: " + program,
                "Gender: " + gender,
                "Age: " + age,
                "Birthday: " + birthday,
                "Contact No: " + contactNo
            };

            // writing student info to the file using foreach
            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                foreach (var info in studentInfoArray)
                {
                    outputFile.WriteLine(info);
                }
            }

            MessageBox.Show("Registration completed!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the form
            Close();

        }
    }
}
