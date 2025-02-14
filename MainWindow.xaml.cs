using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using AppGMAO.Contexto;
using AppGMAO.Entidades;
using Microsoft.EntityFrameworkCore;


namespace AppGMAO
{
    public sealed partial class MainWindow : Window
    {
        private List<Cliente> _clientes;
        private int _index = 0;

        public MainWindow()
        {
            this.InitializeComponent();
            CargarClientes();
        }

        private async void CargarClientes()
        {
            using (var context = new AppDbContext())
            {
                _clientes = await context.Clientes.ToListAsync();
            }
            MostrarCliente();
        }

        private void MostrarCliente()
        {
            if (_clientes != null && _clientes.Count > 0)
            {
                txtDescripcion.Text = _clientes[_index].DescCliente;
            }
        }

        private void BtnAnterior_Click(object sender, RoutedEventArgs e)
        {
            if (_index > 0)
            {
                _index--;
                MostrarCliente();
            }
        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (_index < _clientes.Count - 1)
            {
                _index++;
                MostrarCliente();
            }
        }
    }
}
