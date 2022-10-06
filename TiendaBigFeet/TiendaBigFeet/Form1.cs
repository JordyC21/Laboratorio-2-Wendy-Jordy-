using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TiendaBigFeet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void LimpiarCampos()
        {
            txtId.Clear();
            txtMarca.Clear();
            txtDescripcion.Clear();
            cbCategoria.Text = string.Empty;
            txtTalla.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtMarcaFiltro.Clear();
        }
        List<ClsProducto> ListaInventario = new List<ClsProducto>();
        void RegistrarProducto()
        {

            ClsProducto Pdt = new ClsProducto();
            double pVenta;
            Pdt.ID = Convert.ToInt32(txtId.Text);
            Pdt.Marca = txtMarca.Text;
            Pdt.Descripcion = txtDescripcion.Text;
            Pdt.Categoria = cbCategoria.Text;
            Pdt.Talla = Convert.ToInt32(txtTalla.Text);
            Pdt.Cantidad = Convert.ToInt32(txtCantidad.Text);
            pVenta = double.Parse(txtPrecio.Text) + (double.Parse(txtPrecio.Text) * 0.13);

            Pdt.PrecioVenta = pVenta;
            ListaInventario.Add(Pdt);
            LimpiarCampos();



            btnBuscar.Enabled = true;

        }

        void MostrarProducto()
        {
            string Datos = string.Empty;

            foreach (ClsProducto pt in ListaInventario)
            {
                Datos = Datos + " " + pt.ID + "  " + pt.Marca + "  " + pt.Descripcion + "  " + pt.Categoria + "  " + pt.Talla + "  " + pt.Cantidad + "  " + "$"+pt.PrecioVenta + " " + "\n";
            }

            richTextBox1.Text = Datos; 
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarProducto();
            MostrarProducto();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            MostrarProducto(); 
        }


        public void FiltrarCategoria()
        {
            string datos = "";
            var consulta = from cat in ListaInventario where cat.Categoria.Equals(cbFiltrar.Text) select cat;


            foreach (ClsProducto c in consulta)
            {
                datos = datos + " " + c.ID + " " + c.Marca + " " + c.Descripcion + " " + c.Categoria + " " + c.Talla + " " + c.Cantidad + " " + c.PrecioVenta + " " + "\n";

            }
            richFiltro.Text = datos;  
            
        }



        public void FiltrarMarca()
        {
            string datos = "";
            var consulta = from cat in ListaInventario where cat.Marca.Equals(txtMarcaFiltro.Text) select cat;


            foreach (ClsProducto c in consulta)
            {
                datos = datos + " " + c.ID + " " + c.Marca + " " + c.Descripcion + " " + c.Categoria + " " + c.Talla + " " + c.Cantidad + " " + c.PrecioVenta + " " + "\n";

            }
            richFiltro.Text = datos;

        }
        public void Eliminar()
        {
            try
            {
                if (txtEliminar.Text != "")
                {
                    foreach (ClsProducto p in ListaInventario)
                    {
                        if (p.ID == int.Parse(txtEliminar.Text))
                        {

                            DialogResult respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (respuesta == DialogResult.Yes)
                            {
                                ListaInventario.Remove(p);
                                LimpiarCampos();
                                MostrarProducto();
                            }
                            break; 
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Campo nombre esta vacio!!");

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al elminar registro");
            }
        }

        public void EditarRegistro()
        {
            try
            {
                foreach (ClsProducto p in ListaInventario)
                {
                    if (p.ID ==Convert.ToInt32(txtId.Text))
                    {
                        p.Marca = txtMarca.Text;
                        p.Descripcion = txtDescripcion.Text;
                        p.Categoria = cbCategoria.Text;
                        p.Talla = int.Parse(txtTalla.Text);
                        p.Cantidad = int.Parse(txtCantidad.Text);
                        p.PrecioVenta = int.Parse(txtPrecio.Text);
                    }

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar los cambios");
            }
        }



        void Buscar()
        {
      
                try
                {
                    if (txtBuscar.Text != null)
                    {
                        foreach (ClsProducto p in ListaInventario)
                        {
                            if (p.ID == int.Parse(txtBuscar.Text))
                            {

                               txtId.Text = p.ID.ToString();
                               txtMarca.Text = p.Marca;
                               txtDescripcion.Text = p.Descripcion;
                               cbCategoria.Text = p.Categoria;
                               txtTalla.Text = p.Talla.ToString();
                               txtCantidad.Text = p.Cantidad.ToString();
                               txtPrecio.Text = p.PrecioVenta.ToString(); 
  
                               
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo nombre esta vacio!!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error en la busqueda");
                }
          
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar(); 
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarCategoria();
            FiltrarMarca();
            LimpiarCampos(); 
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <=255)
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return; 
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo números enteros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 33 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se aceptan letras ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 33 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se aceptan letras ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 45 || e.KeyChar >= 58 && e.KeyChar <= 255 || e.KeyChar >= 123 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se aceptan números ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 45 || e.KeyChar >= 58 && e.KeyChar <= 255 || e.KeyChar >= 123 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se aceptan números ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            EditarRegistro();

            MostrarProducto();
        }
    }
}
