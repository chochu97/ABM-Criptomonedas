using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arquitectura
{
    public partial class Form1 : Form
    {
        private CriptomonedaBusiness criptobusiness = new CriptomonedaBusiness();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            Criptomoneda cripto = new Criptomoneda();
            cripto.Siglas = txtSiglas.Text;
            cripto.Precio = Convert.ToDouble(txtPrecioAlta.Text);
            cripto.Descripcion = txtDescripcion.Text;

            criptobusiness.DarAlta(cripto);
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            comboBoxConsult.DisplayMember = "Descripcion";
            comboBoxConsult.ValueMember = "ID";
            
            //comboBoxConsult.SelectedValue;

            comboBoxConsult.DataSource = null;
            comboBoxConsult.DataSource = criptobusiness.Consultar();

            comboBoxModify.DisplayMember = "Descripcion";
            comboBoxModify.ValueMember = "ID";
            comboBoxModify.DataSource = null;
            comboBoxModify.DataSource = criptobusiness.Consultar();

            comboBoxEliminar.DisplayMember = "Descripcion";
            comboBoxEliminar.ValueMember = "ID";
            comboBoxEliminar.DataSource = null;
            comboBoxEliminar.DataSource = criptobusiness.Consultar();
            

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = criptobusiness.Consultar();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            criptobusiness.Modificar(Convert.ToInt32(comboBoxModify.SelectedValue), Convert.ToDouble(textBox1.Text));
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
                    

            criptobusiness.Eliminar(Convert.ToInt32(comboBoxEliminar.SelectedValue));
        }
    }
}
