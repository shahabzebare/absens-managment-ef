using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Migrations;
namespace AbsentProject.Forms
{
    public partial class Departments : Form
    {

        //DB Object 
        DataAccess.AbsentModel absent = new DataAccess.AbsentModel();


        public Departments()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //validation
            if (txtName.Text.ToString() == "")
            {
                MessageBox.Show("Name is Required !");
                return;
            }


            //object department class  and init 
            DataAccess.Dept dep = new DataAccess.Dept()
            {
                id = int.Parse(txtID.Text.ToString()),
                Name = txtName.Text.ToString()
            };
           
            // insert or update this object in database
            absent.Depts.AddOrUpdate(dep);
          
            //commit
            absent.SaveChanges();
            
            //show sccess mesg
            MessageBox.Show("Department Insterted Successfuly ");
               
            //clear form and rest 
            clear();
            //reload datagrid view
            loadData();
        }

        private void clear()
        {
            // set next id
            int? maxId = absent.Depts.Max(d => (int?)d.id);
            if (maxId != null)
                maxId++;
            else
                maxId = 1;
            txtID.Text = (maxId).ToString();

            //clear text
            txtName.Text = "";
            //dispable delete button 
            btnDelete.Enabled = false;
        }

        private void loadData()
        {
            //load data from database into data grid view
            dtgDepartment.DataSource = absent.Depts.ToList<DataAccess.Dept>();
        }

        //when bot application
        private void Departments_Load(object sender, EventArgs e)
        {
            clear();
            loadData();
        }

        private void dtgDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //when double click on row 
        private void dtgDepartment_DoubleClick(object sender, EventArgs e)
        {
            if (dtgDepartment.CurrentCell.RowIndex != -1)
            {
                txtID.Text = dtgDepartment.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dtgDepartment.CurrentRow.Cells[1].Value.ToString();
                btnDelete.Enabled = true;
            }
        }

        //delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.ToString() != "")
            {
                //id
                int id = int.Parse(txtID.Text.ToString());


                var dep = absent.Depts.FirstOrDefault(d => d.id == id);

                absent.Depts.Remove(dep);
                
                absent.SaveChanges();
                MessageBox.Show("Deleted Successfuly");
                clear();
                loadData();
            }
        }
    }
}
