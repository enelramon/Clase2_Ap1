using System.Windows;
using Clase2.Entidades;
using Clase2.BLL;
using System.Linq;
using System.Collections.Generic;

namespace Clase2.UI.Consultas
{
    public partial class cLibros : Window
    {

        public cLibros()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Libros>();

            if (string.IsNullOrWhiteSpace(CriterioTextBox.Text)) //si no hay criterio, busco todos         
                listado = LibrosBLL.GetList(l => true);
            else
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //"Titulo"
                        listado = LibrosBLL.GetList(l => l.Titulo.Contains(CriterioTextBox.Text));
                        break;
                    case 1:   //"Grupo" 
                        listado = LibrosBLL.GetList(l => l.Grupo.Contains(CriterioTextBox.Text));
                        break;
                }
            }

            //lleno el grid con la lista
            LibrosDataGrid.ItemsSource = null;
            LibrosDataGrid.ItemsSource = listado;

        }

    }
}