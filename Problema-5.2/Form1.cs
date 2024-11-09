using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problema_5._2
{
    public partial class frmAlumnos : Form
    {
        private DAO DAO = new DAO();
        public frmAlumnos()
        {
            InitializeComponent();
            DAO = new DAO();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void frmAlumnos_Load(object sender, EventArgs e)
        {
            CargarCboCarrera();
            CargarCboTipoDoc();
            cboTipoDoc.SelectedIndex = -1;
            cboCarrera.SelectedIndex = -1;
            rbtFem.Checked = true;
            rbtMasc.Checked = false;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            btnBorrar.Enabled = false;
            btnEditar.Enabled = false;
            CargarLista();
        }

        private void CargarCboCarrera()
        {
            DataTable dt = DAO.CargarCombo("Carreras");
            cboCarrera.DataSource = dt;
            cboCarrera.ValueMember= dt.Columns[0].ColumnName;
            cboCarrera.DisplayMember = dt.Columns[1].ColumnName;
        }

        private void CargarCboTipoDoc()
        {
            DataTable dt = DAO.CargarCombo("tipos_doc");
            cboTipoDoc.DataSource = dt;
            cboTipoDoc.ValueMember = dt.Columns[0].ColumnName;
            cboTipoDoc.DisplayMember = dt.Columns[1].ColumnName;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void CargarLista()
        {
            string consultaSql = "SELECT CONCAT(a.apellido, ' ' , a.nombre) FROM alumnos a";
            DataTable dt =  DAO.ConsultarBD(consultaSql);
            lstAlumnos.Items.Clear();
            foreach (DataRow fila in dt.Rows)
            {
                lstAlumnos.Items.Add(fila[0].ToString());
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGrabar.Enabled = true;
        }
    }
}
