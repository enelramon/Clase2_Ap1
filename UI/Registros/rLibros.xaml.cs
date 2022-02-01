using System.Windows;
using Clase2.Entidades;
using Clase2.BLL;

namespace Clase2.UI.Registros
{
    public partial class rLibros : Window
    {
        private Libros Libro = new Libros();

        public rLibros()
        {
            InitializeComponent();

            this.DataContext = Libro;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.Libro;
        }

        private void Limpiar()
        {
            this.Libro = new Libros();
            this.DataContext = Libro;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(Libro.Titulo))
            {
                esValido = false;
                TituloTextBox.Focus();
                MessageBox.Show("Debe indicar el titulo!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrWhiteSpace(Libro.Grupo))
            {
                esValido = false;
                GrupoTextBox.Focus();
                MessageBox.Show("Debe indicar el grupo!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = LibrosBLL.Buscar(this.Libro.LibroId);

            if (encontrado != null)
            {
                this.Libro = encontrado;
                Cargar();

            }
            else
            {
                Limpiar();
                MessageBox.Show("No se encontro el libro!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            paso = LibrosBLL.Guardar(Libro);

            if (paso)
                MessageBox.Show("Libro guardado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No se pudo guardar el libro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (LibrosBLL.Eliminar(Libro.LibroId))
            {
                Limpiar();
                MessageBox.Show("Libro eliminado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar el libro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}