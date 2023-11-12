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
    public partial class FrmStudentRecord : Form
    {
        public FrmStudentRecord()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            FrmRegistration frmRegistration = new FrmRegistration();
            frmRegistration.Show();
            Hide(); 
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\"; 
                openFileDialog.Title = "Select Text File"; 
                openFileDialog.DefaultExt = "txt"; 
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; 

                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    //to display the content of the selected text file
                    DisplayTextFileContent(filePath);
                }
            }
        }

        private void DisplayTextFileContent(string filePath)
        {
            lvViewRecord.Items.Clear();

            try
            {
                using (StreamReader streamReader = File.OpenText(filePath))
                {
                    string content;
                    while ((content = streamReader.ReadLine()) != null)
                    {
                        lvViewRecord.Items.Add(content);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void btnUpload_Click(object sender, EventArgs e)
        {
            lvViewRecord.Items.Clear();
            MessageBox.Show("Successfully Uploaded!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

            Close();
            
        }


    }
}
