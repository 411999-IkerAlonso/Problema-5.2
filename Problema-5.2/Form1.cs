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
        Alumno alumno = new Alumno();
        List<Parametro> parametros = new List<Parametro>();
        int Modo = 0;
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
            cboTipoDoc.Enabled = false;
            cboCarrera.Enabled = false;
            rbtFem.Checked = true;
            rbtMasc.Checked = false;
            rbtFem.Enabled = false;
            rbtMasc.Enabled = false;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            btnBorrar.Enabled = true;
            btnEditar.Enabled = true;
            txtNombre.Clear();
            txtNombre.Enabled = false;
            txtApellido.Clear();
            txtApellido.Enabled = false;
            txtCalle.Clear();
            txtCalle.Enabled = false;
            txtCantidad.Clear();
            txtCantidad.Enabled = false;
            txtDoc.Clear();
            txtDoc.Enabled = false;
            txtNro.Clear();
            txtNro.Enabled = false;
            dtpFechaNac.Value = DateTime.Now;
            dtpFechaNac.Enabled = false;
            chbActividad.Enabled = false;
            chbActividad.Enabled= false;
            chbHijos.Enabled = false;
            chbCasado.Enabled = false;
            CargarLista("SELECT a.legajo, a.nombre, a.apellido FROM alumnos a");
        }

        private void LimpiarForms()
        {
            cboTipoDoc.SelectedIndex = -1;
            cboCarrera.SelectedIndex = -1;
            cboTipoDoc.Enabled = false;
            cboCarrera.Enabled = false;
            rbtFem.Checked = true;
            rbtMasc.Checked = false;
            rbtFem.Enabled = false;
            rbtMasc.Enabled = false;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            btnBorrar.Enabled = true;
            btnEditar.Enabled = true;
            txtNombre.Clear();
            txtNombre.Enabled = false;
            txtApellido.Clear();
            txtApellido.Enabled = false;
            txtCalle.Clear();
            txtCalle.Enabled = false;
            txtCantidad.Clear();
            txtCantidad.Enabled = false;
            txtDoc.Clear();
            txtDoc.Enabled = false;
            txtNro.Clear();
            txtNro.Enabled = false;
            dtpFechaNac.Value = DateTime.Now;
            dtpFechaNac.Enabled = false;
        }
        private void CargarCboCarrera()
        {
            //Al crear el datatable aca evitamos mandarle por parametro el nombre de la tabla al metodo
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
            if (Modo ==1)
            {
                alumno.Nombre = txtNombre.Text;
                alumno.Apellido = txtApellido.Text;
                alumno.FechaNac = dtpFechaNac.Value;
                if (rbtFem.Checked)
                {
                    alumno.Sexo = "Femenino";
                }
                else if (rbtMasc.Checked)
                {
                    alumno.Sexo = "Masculino";
                }
                alumno.TipoDoc = Convert.ToInt32(cboTipoDoc.SelectedValue);
                alumno.Doc = Convert.ToInt32(txtDoc.Text);
                alumno.Calle = Convert.ToString(txtCalle.Text);
                alumno.NroCalle = Convert.ToInt32(txtNro.Text);
                if (chbActividad.Checked)
                {
                    alumno.Actividad = true;
                }
                else alumno.Actividad = false;
                if (chbCasado.Checked)
                {
                    alumno.Casado = true;
                }
                else alumno.Casado = false;
                if (chbHijos.Checked)
                {
                    alumno.Hijos = true;
                }
                else
                {
                    alumno.Hijos = false;
                    txtCantidad.Enabled = false;
                };
                alumno.Carrera = Convert.ToInt32(cboCarrera.SelectedValue);
                //Si llega a dar error cambiar aquellos valores que en la Bd son int y aca string, por int
                NuevoAlumno();
                LimpiarForms();
                CargarLista("SELECT a.legajo, a.nombre, a.apellido FROM alumnos a");
                
            }
            else if(Modo == 2)
            {
                int legajoAlumno = Convert.ToInt32(dgvAlumnos.CurrentRow.Cells[0].Value); 
                EditarAlumno(legajoAlumno);
                alumno.Nombre = txtNombre.Text;
                alumno.Apellido = txtApellido.Text;
                alumno.FechaNac = dtpFechaNac.Value;
                if (rbtFem.Checked)
                {
                    alumno.Sexo = "Femenino";
                }
                else if (rbtMasc.Checked)
                {
                    alumno.Sexo = "Masculino";
                }
                alumno.TipoDoc = Convert.ToInt32(cboTipoDoc.SelectedValue);
                alumno.Doc = Convert.ToInt32(txtDoc.Text);
                alumno.Calle = Convert.ToString(txtCalle.Text);
                alumno.NroCalle = Convert.ToInt32(txtNro.Text);
                if (chbActividad.Checked)
                {
                    alumno.Actividad = true;
                }
                else alumno.Actividad = false;
                if (chbCasado.Checked)
                {
                    alumno.Casado = true;
                }
                else alumno.Casado = false;
                if (chbHijos.Checked)
                {
                    alumno.Hijos = true;
                }
                else
                {
                    alumno.Hijos = false;
                    txtCantidad.Enabled = false;
                };
                alumno.Carrera = Convert.ToInt32(cboCarrera.SelectedValue);
                LimpiarForms();
                CargarLista("SELECT a.legajo, a.nombre, a.apellido FROM alumnos a");
                
            }
        }

        private void NuevoAlumno()
        {
            string consultaSql = "INSERT INTO Alumnos(nombre, apellido, fecha_nac, sexo, tipo_doc, doc, calle, numero, actividad, casado, hijos, cantidad_hijos, carrera)" +
     "VALUES (@nombre, @apellido, @fecha_nac, @sexo, @tipo_doc, @doc, @calle, @numero, @actividad, @casado, @hijos, @cantidad_hijos, @carrera)";
            parametros.Add(new Parametro("@nombre", alumno.Nombre));
            parametros.Add(new Parametro("@apellido", alumno.Apellido));
            parametros.Add(new Parametro("@fecha_nac", alumno.FechaNac));
            parametros.Add(new Parametro("@sexo", alumno.Sexo));
            parametros.Add(new Parametro("@tipo_doc", alumno.TipoDoc));
            parametros.Add(new Parametro("@doc", alumno.Doc));
            parametros.Add(new Parametro("@calle", alumno.Calle));
            parametros.Add(new Parametro("@numero", alumno.NroCalle));
            parametros.Add(new Parametro("@actividad", alumno.Actividad));
            parametros.Add(new Parametro("@casado", alumno.Casado));
            parametros.Add(new Parametro("@hijos", alumno.Hijos));
            parametros.Add(new Parametro("@cantidad_hijos", alumno.Cantidad));
            parametros.Add(new Parametro("@carrera", alumno.Carrera));
            int filasAfectadas = DAO.Actualizar(consultaSql, parametros);
            if (filasAfectadas == 0)
            {
                MessageBox.Show("Algo ha salido mal, el alumno no se insertó");
            }
            else MessageBox.Show("Alumno creado con exito");
        }
         
        private void EditarAlumno(int legajo)
        {
            string consultaSql = "UPDATE Alumnos SET  " +
                "nombre = @nombre, " +
                "apellido = @apellido, " +
                "fecha_nac = @fecha_nac, " +
                "sexo = @sexo, " +
                "tipo_doc = @tipo_doc, " +
                "doc = @doc, " +
                "calle = @calle, " +
                "numero = @numero, " +
                "actividad = @actividad, " +
                "casado = @casado, " +
                "hijos = @hijos, " +
                "cantidad_hijos = @cantidad_hijos, " +
                "carrera = @carrera " +
                "WHERE legajo = @legajo";
            parametros.Add(new Parametro("@nombre", alumno.Nombre));
            parametros.Add(new Parametro("@apellido", alumno.Apellido));
            parametros.Add(new Parametro("@fecha_nac", alumno.FechaNac));
            parametros.Add(new Parametro("@sexo", alumno.Sexo));
            parametros.Add(new Parametro("@tipo_doc", alumno.TipoDoc));
            parametros.Add(new Parametro("@doc", alumno.Doc));
            parametros.Add(new Parametro("@calle", alumno.Calle));
            parametros.Add(new Parametro("@numero", alumno.NroCalle));
            parametros.Add(new Parametro("@actividad", alumno.Actividad));
            parametros.Add(new Parametro("@casado", alumno.Casado));
            parametros.Add(new Parametro("@hijos", alumno.Hijos));
            parametros.Add(new Parametro("@cantidad_hijos", alumno.Cantidad));
            parametros.Add(new Parametro("@carrera", alumno.Carrera));
            parametros.Add(new Parametro("@legajo", alumno.Legajo));
            int filasAfectadas = DAO.Actualizar(consultaSql, parametros);
            if (filasAfectadas == 0)
            {
                MessageBox.Show("Algo ha salido mal, el alumno no se edito");
            }
            else MessageBox.Show("Alumno editado con exito");
        }

        private void CargarLista(string consultaSql)
        {
            DataTable dt =  DAO.ConsultarBD(consultaSql);
            dgvAlumnos.Rows.Clear();
            foreach (DataRow fila in dt.Rows)
            {
                dgvAlumnos.Rows.Add(fila[0], fila[1], fila[2]);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Completa los cambios para poder Agregar un alumno");
            cboTipoDoc.Enabled = true;
            cboCarrera.Enabled = true;
            rbtFem.Checked = true;
            rbtMasc.Checked = false;
            rbtFem.Enabled = true;
            rbtMasc.Enabled = true;
            txtNombre.Clear();
            txtNombre.Enabled = true;
            txtApellido.Clear();
            txtApellido.Enabled = true;
            txtCalle.Clear();
            txtCalle.Enabled = true;
            txtCantidad.Clear();
            txtCantidad.Enabled = true;
            txtDoc.Clear();
            txtDoc.Enabled = true;
            txtNro.Clear();
            txtNro.Enabled = true;
            dtpFechaNac.Value = DateTime.Now;
            dtpFechaNac.Enabled = true;
            chbActividad.Enabled = true;
            chbHijos.Enabled = true;
            chbCasado.Enabled = true;
            btnGrabar.Enabled = true;
            btnBorrar .Enabled = false;
            btnEditar .Enabled = false;
            btnCancelar .Enabled = true;
            Modo = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cboTipoDoc.Enabled = true;
            cboCarrera.Enabled = true;
            rbtFem.Checked = true;
            rbtMasc.Checked = false;
            rbtFem.Enabled = true;
            rbtMasc.Enabled = true;
            txtNombre.Clear();
            txtNombre.Enabled = true;
            txtApellido.Clear();
            txtApellido.Enabled = true;
            txtCalle.Clear();
            txtCalle.Enabled = true;
            txtCantidad.Clear();
            txtCantidad.Enabled = true;
            txtDoc.Clear();
            txtDoc.Enabled = true;
            txtNro.Clear();
            txtNro.Enabled = true;
            dtpFechaNac.Value = DateTime.Now;
            dtpFechaNac.Enabled = true;
            chbActividad.Enabled = true;
            chbHijos.Enabled = true;
            chbCasado.Enabled = true;
            btnGrabar.Enabled = true;
            btnBorrar.Enabled = false;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
            int legajoAlumno = Convert.ToInt32(dgvAlumnos.CurrentRow.Cells[0].Value);
            CargarAlumno(legajoAlumno);
            btnNuevo.Enabled = false;
            btnBorrar .Enabled = false;
            btnGrabar .Enabled = true;
            btnCancelar.Enabled = true;
            Modo = 2;
        }

        private void Cancelar()
        {
            CargarCboCarrera();
            CargarCboTipoDoc();
            cboTipoDoc.SelectedIndex = -1;
            cboCarrera.SelectedIndex = -1;
            rbtFem.Checked = true;
            rbtMasc.Checked = false;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            btnBorrar.Enabled = true;
            btnEditar.Enabled = true;
            CargarLista("SELECT a.legajo, a.nombre, a.apellido FROM alumnos a");
            txtNombre.Clear();
            txtApellido.Clear();
            txtCalle.Clear();
            txtCantidad.Clear();
            txtDoc.Clear();
            txtNro.Clear();
            dtpFechaNac.Value= DateTime.Now;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void CargarAlumno(int legajo)
        {
            string consultaSql = $"SELECT * FROM alumnos WHERE legajo = {legajo}";
            DataTable dt = DAO.ConsultarBD(consultaSql);
            if(dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                alumno.Legajo = Convert.ToInt32(dr[0]);
                alumno.Nombre = Convert.ToString(dr[1]);
                alumno.Apellido = Convert.ToString(dr[2]);
                alumno.FechaNac = Convert.ToDateTime(dr[3]);
                alumno.Sexo = Convert.ToString(dr[4]);
                alumno.TipoDoc = Convert.ToInt32(dr[5]);
                alumno.Doc = Convert.ToInt32(dr[6]);
                alumno.Calle = Convert.ToString(dr[7]);
                alumno.NroCalle = Convert.ToInt32(dr[8]);
                alumno.Actividad = Convert.ToBoolean(dr[9]);
                alumno.Casado = Convert.ToBoolean(dr[10]);
                alumno.Hijos = Convert.ToBoolean(dr[11]);
                alumno.Cantidad = Convert.ToInt32(dr[12]);
                alumno.Carrera = Convert.ToInt32(dr[13]);

                txtNombre.Text = alumno.Nombre;
                txtApellido.Text = alumno.Apellido;
                dtpFechaNac.Value = alumno.FechaNac;
                if (alumno.Sexo == "Masculino")
                {
                    rbtMasc.Checked = true;
                }
                else if(alumno.Sexo == "Femenino")
                { 
                rbtFem.Checked = true;  
                }
                cboTipoDoc.SelectedIndex = alumno.TipoDoc;
                txtDoc.Text = Convert.ToString(alumno.Doc);
                txtCalle.Text = alumno.Calle;
                txtNro.Text = Convert.ToString(alumno.NroCalle);
                if (alumno.Actividad == true)
                {
                    chbActividad.Checked = true;
                }
                else { chbActividad.Checked = false; }
                if(alumno.Casado == true)
                {
                    chbCasado.Checked = true;
                }
                else chbCasado.Checked = false;
                if(alumno.Hijos == true)
                {
                    chbHijos .Checked = true;
                }
                else chbHijos.Checked = false;
                txtCantidad.Text = Convert.ToString(alumno.Cantidad);
                cboCarrera.SelectedIndex = alumno.Carrera;
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarLista("SELECT a.legajo, a.nombre, a.apellido FROM alumnos a");
        }
    }
}
