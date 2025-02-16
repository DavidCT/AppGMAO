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
using System.Collections.ObjectModel;


namespace AppGMAO
{
    public sealed partial class MainWindow : Window
    {
        public ObservableCollection<Cliente> Clientes { get; set; } = new();
        private ObservableCollection<Cliente> TodosLosClientes { get; set; } = new();

        public MainWindow()
        {
            this.InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            using (var context = new AppDbContext())
            {
                var clientes = context.Clientes.ToList();
                foreach (var cliente in clientes)
                {
                    Clientes.Add(cliente);
                    TodosLosClientes.Add(cliente);
                }
            }

            ComboClientes.ItemsSource = Clientes;
            
        }

        private void ComboClientes_TextSubmitted(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var filtro = sender.Text.ToLower();
                Clientes.Clear();

                foreach (var cliente in TodosLosClientes.Where(c => c.DescCliente.ToLower().Contains(filtro)))
                {
                    Clientes.Add(cliente);
                }
            }
        }
    }
}
