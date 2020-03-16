using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PruebaOrden1.Entidades;
using PruebaOrden1.BLL;

namespace PruebaOrden1.UI.Registros
{
    /// <summary>
    /// Interaction logic for ROrden.xaml
    /// </summary>
    public partial class ROrden : Window
    {
        Contenedor contenedor = new Contenedor();
        public ROrden()
        {
            InitializeComponent();
            this.DataContext = contenedor;
            OrdenIdTextBox.Text = "0";
        }

        private void Recargar()
        {
            this.DataContext = null;
            this.DataContext = contenedor;
        }

        private void Limpiar()
        {
            OrdenIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            FechaDatePicker.SelectedDate = DateTime.Now;
            DescripcionTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            contenedor = new Contenedor();
            contenedor.orden.Productos = new List<ProductoDetalle>();
            Recargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Orden ordenAnterior = OrdenesBLL.Buscar(contenedor.orden.OrdenId);
            return contenedor.orden != null;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (contenedor.orden.OrdenId == 0)
            {
                if(contenedor.orden.Productos.Count > 0)
                    paso = OrdenesBLL.Guardar(contenedor.orden);
                if (contenedor.orden.Productos.Count == 0)
                    paso = false;
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se Puede Modificar una Orden Que no Existe");
                    return;
                }
                else
                    paso = OrdenesBLL.Modificar(contenedor.orden);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
                MessageBox.Show("No se Pudo Guardar porque debe de haber agregado un producto");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdenesBLL.Eliminar(contenedor.orden.OrdenId))
            {
                Limpiar();
                MessageBox.Show("Eliminado");
            }
            else
                MessageBox.Show("No se Puede Eliminar Una Orden Que no Existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Orden OrdenAnterior = OrdenesBLL.Buscar(contenedor.orden.OrdenId);

            if(OrdenAnterior != null)
            {
                contenedor.orden = OrdenAnterior;
                Recargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Orden No Encontrada");
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ExisteEnLaBaseDeDatos())
                return;

            contenedor.orden.Productos.Add(new ProductoDetalle(contenedor.orden.OrdenId, DescripcionTextBox.Text, 
                Convert.ToDecimal(PrecioTextBox.Text), Convert.ToDecimal(MontoTextBox.Text), 
                Convert.ToInt32(CantidadTextBox.Text)));

            Recargar();

            DescripcionTextBox.Clear();
            PrecioTextBox.Clear();
            MontoTextBox.Clear();
            CantidadTextBox.Clear();
            DescripcionTextBox.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProductosDataGrid.Items.Count > 1 && ProductosDataGrid.SelectedIndex < ProductosDataGrid.Items.Count - 1)
            {
                contenedor.orden.Productos.RemoveAt(ProductosDataGrid.SelectedIndex);
                Recargar();
            }
        }

        private void PrecioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(CantidadTextBox.Text) && !string.IsNullOrWhiteSpace(PrecioTextBox.Text))
            {
                foreach(char caracter in PrecioTextBox.Text)
                {
                    if(!char.IsDigit(caracter))
                    {
                        contenedor.detalle.Precio = 0;
                        PrecioTextBox.Clear();
                    }
                    else
                    {
                        PrecioTextBox.Text = Convert.ToString(contenedor.detalle.Precio);
                        CantidadTextBox.Text = Convert.ToString(contenedor.detalle.Cantidad);

                        contenedor.detalle.Monto = contenedor.detalle.Precio *
                            contenedor.detalle.Cantidad;

                        MontoTextBox.Text = Convert.ToString(contenedor.detalle.Monto);
                    }
                }
            }
        }

        private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CantidadTextBox.Text) && !string.IsNullOrWhiteSpace(PrecioTextBox.Text))
            {
                foreach (char caracter in CantidadTextBox.Text)
                {
                    if (!char.IsDigit(caracter))
                    {
                        contenedor.detalle.Cantidad = 0;
                        CantidadTextBox.Clear();
                    }
                    else
                    {
                        PrecioTextBox.Text = Convert.ToString(contenedor.detalle.Precio);
                        CantidadTextBox.Text = Convert.ToString(contenedor.detalle.Cantidad);

                        contenedor.detalle.Monto = contenedor.detalle.Precio *
                            contenedor.detalle.Cantidad;

                        MontoTextBox.Text = Convert.ToString(contenedor.detalle.Monto);
                    }
                }
            }
        }
    }
}
