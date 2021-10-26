using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Complementario2Guia5_VE202846
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private bool validarcampos()
        {
            //variables que verifica si algo ha sido validado
            bool validado = true;
            if (txtnombre.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtnombre, "Ingresar nombre");
            }
            if (txtapellido.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtapellido, "Ingresar apellido");
            }
            return validado;
        }
        private void BorrarMensaje()
        {
            errorProvider1.SetError(txtnombre, "");
            errorProvider1.SetError(txtapellido, "");
        }

        public void Limpiar()
        {
            txtapellido.Clear();
            txtedad.Clear();
            txtnombre.Clear();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            BorrarMensaje();
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            int anios = System.DateTime.Now.Year - fechaNacimiento.Year;

            if (fechaNacimiento.Day >= System.DateTime.Now.Day && fechaNacimiento.Year >= System.DateTime.Now.Year)
            {
                MessageBox.Show("Fecha de nacimiento invalida, vuelva a ingresar los datos");
                Limpiar();
            }
            else
            {
                if (validarcampos() == false)
                {
                    MessageBox.Show("OH ha ocurrido un erros verifica que es");
                }
                else
                {
                    MessageBox.Show("Los datos se ingresaron correctamente");
                    if (System.DateTime.Now.Subtract(fechaNacimiento.AddYears(anios)).TotalDays < 0) txtedad.Text = Convert.ToString(anios - 1);
                    else
                        txtedad.Text = Convert.ToString(anios);
                }




            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Menu();
            frm.Show();
            this.Hide();
        }
    }
}
