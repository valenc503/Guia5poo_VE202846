using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Complementario2Guia5_VE202846
{
    public partial class Form1 : Form
    {
        public Form1()
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
            if (txtresponsable.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtresponsable, "Ingresar responsable");
            }
            if (txtcorreo.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtcorreo, "Ingresar correo");
            }
            if (txtcarnet.Text == "")
            {
                validado = false;
                errorProvider1.SetError(txtcarnet, "Ingresar carnet");
            }
            return validado;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fechaNacimiento = dtpnacimiento.Value;
            int anios = System.DateTime.Now.Year - fechaNacimiento.Year;
            int edadentraruniversidad = 17;
            int operaedad = System.DateTime.Now.Year - edadentraruniversidad ;
            if ( fechaNacimiento.Year > operaedad)
            {
                MessageBox.Show("Fecha de nacimiento invalida, ingrese un año como valor minimo de 17 años atras");
                
            }
            else { 
            if (validarcampos() == false)
            {
                MessageBox.Show("OH ha ocurrido un erros verifica que es");
            }
            else { 

             Form2 formulario = new Form2(); //instancia de otro formulario
             formulario.txtnombre.Text = txtnombre.Text;
             formulario.txtcarnet.Text = txtcarnet.Text;
             formulario.txtfecha.Text = Convert.ToString(dtpnacimiento.Value);
             formulario.txtcorreo.Text = txtcorreo.Text;
             formulario.txtresponsable.Text = txtresponsable.Text;

             formulario.Show(); //mostar el segundo formulario
                    this.Hide();
             }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        public static bool ValidarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email,expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void txtcorreo_Leave(object sender, EventArgs e)
        {
            //condicion que captura el email
            if (ValidarEmail(txtcorreo.Text))
            {

            }
            else
            {
                MessageBox.Show("Direccion de correo no es valida, por favor ingresar direccion con correo usuario@dominio.com");
                txtcorreo.SelectAll();
                txtcorreo.Focus();
            }
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion que permite ocupar la tecla
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }

            //condicion que nos permite utilizar la tecla backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            //condicion que verifica si hay un punto decimal
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten letras");
            }
        }

        private void txtresponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion que permite ocupar la tecla
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }

            //condicion que nos permite utilizar la tecla backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            //condicion que verifica si hay un punto decimal
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten letras");
            }
        }

        private void txtcarnet_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtcarnet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form frm = new Menu();
            frm.Show();
            this.Hide();
        }
    }
}
