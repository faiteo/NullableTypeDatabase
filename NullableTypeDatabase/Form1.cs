using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NullableTypeDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void ClickSaveNewUser(object sender, EventArgs e)
        {
            if (ValidateStringInputFields())
            {
                string ageInput = txtAge.Text;

                int? validatedAgeInput = ValidateAgeInput(ageInput);

                int queryResult = NullableTypeDB.AddNewEmployee(txtFname.Text, txtLname.Text, comBoxMaritalStatus.SelectedIndex, validatedAgeInput);
                if (queryResult == 1)
                {
                    MessageBox.Show("A New Employee Record has been Successfully Added");
                }
                txtFname.Text = "";
                txtLname.Text = "";
                txtAge.Text = "";
                //automatically reload the form show the newly added employee on the Gridview
                this.Form_Load(this, null);
            }

        }




        //private void ClickSaveNewUser2(object sender, EventArgs e)
        //{
        //    if (ValidateStringInputFields())
        //    {
        //        string ageInput = txtAge.Text;

        //        int? validatedAgeInput = ValidateAgeInput(ageInput);

        //        string comboRes = comBoxMaritalStatus.SelectedItem.ToString();

        //        bool? returnedVal = GetValueOfMaritalStatus(comboRes);

        //        int queryResult = NullableTypeDB.AddNewEmployee2(txtFname.Text, txtLname.Text, returnedVal, validatedAgeInput);
        //        if (queryResult == 1)
        //        {
        //            MessageBox.Show("A New Employee Record has been Successfully Added");
        //        }

        //    }

        //}


        private bool? GetValueOfMaritalStatus(string input)
        {

            bool? rescom = null;

            if (input == "Yes")
            {
                rescom = true;
            }

            else if (input == "No")
            {
                rescom = false;
            }
            return rescom;
        }


        private bool ValidateStringInputFields()
        {
            var controls = new[] { txtFname, txtLname };

            bool isValid = true;
            foreach (var control in controls.Where(e => String.IsNullOrEmpty(e.Text)))
            {
                errorProviderTxtBoxes.SetError(control, "Please fill the required field");

                isValid = false;
            }

            return isValid;
        }





        private int ValidateAgeInput(string ageInput)
        {
            int result = 0;

            if (string.IsNullOrEmpty(ageInput))
            {
                result = 0;
            }
            else if (!string.IsNullOrEmpty(ageInput))
            {
                int resultAge;
                if (int.TryParse(txtAge.Text, out resultAge))
                {
                    result = resultAge;
                }
            }

            return result;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_Load(object sender, EventArgs e)
        {
            List<Employee> employeeList;
            try
            {
                employeeList = NullableTypeDB.GetEmployees();
                if (employeeList.Count > 0)
                {


              
                

                    dgViewEmployees.DataSource = employeeList;
                    dgViewEmployees.Columns[0].Visible = false;
                    dgViewEmployees.Columns[3].Visible = false;
                }
                else
                {
                    MessageBox.Show("There are currently no employees in the database");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, GetType().ToString());
                MessageBox.Show(ex.Message);
            }

        }
    }
}
