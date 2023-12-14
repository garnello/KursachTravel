using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using KursachTravel.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace KursachTravel.Window;

public partial class MainWindow : System.Windows.Window 
{
    PostgresContext db;
    
    public MainWindow()
    {
        InitializeComponent();
        db = new PostgresContext();
        
        List<Tur> turs = db.Turs.ToList();
        TurListView.ItemsSource = turs;
        
        List<Client> сlient = db.Clients.ToList();
        ClientListView.ItemsSource = сlient;
        
        List<Service> service = db.serviceSet.ToList();
        ServiceListView.ItemsSource = service;
        
        List<Partner> partner = db.partnerSet.ToList();
        PartnerListView.ItemsSource = partner;
    }
    
    /* <--------------------Tur------------------------> */
    private void AddButtonTur(object sender, RoutedEventArgs e)
    {
        AddEditTur addEditTur = new AddEditTur();
        addEditTur.Show();
    }
    
    private void DeleteButtonTur(object sender, RoutedEventArgs e)
    {
        Tur selectedTur = (Tur)TurListView.SelectedItem;
        if (selectedTur != null)
        {
            db.turSet.Remove(selectedTur);
            db.SaveChanges();
            
            List<Tur> turs = db.Turs.ToList();
            TurListView.ItemsSource = turs;
        }
    }
    
    private void UpdateButtonTur(object sender, RoutedEventArgs e)
    {
        List<Tur> turs = db.Turs.ToList();
        TurListView.ItemsSource = turs;
    }

    private void SearchButtonTur(object sender, RoutedEventArgs e)
    {
        string searchText = SearchTextBoxTur.Text;

        List<Tur> searchResults = new List<Tur>();
        foreach (Tur tur in db.Turs)
        {
            if (tur.TitleTur.Contains(searchText))
            {
                searchResults.Add(tur);
            }
        }
        TurListView.ItemsSource = searchResults;
    }
    /* <--------------------Tur------------------------> */
    
    
    
    /* <--------------------Client------------------------> */
    private void AddButtonClient(object sender, RoutedEventArgs e)
    {
        AddEditClient addEditClient = new AddEditClient();
        addEditClient.Show();
    }
    
    private void DeleteButtonClient(object sender, RoutedEventArgs e)
    {
        Client selectedClient = (Client)ClientListView.SelectedItem;
        if (selectedClient != null)
        {
            db.clientsSet.Remove(selectedClient);
            db.SaveChanges();
            
            List<Client> сlient = db.Clients.ToList();
            ClientListView.ItemsSource = сlient;
        }
    }
    
    private void UpdateButtonClient(object sender, RoutedEventArgs e)
    {
        List<Client> client = db.Clients.ToList();
        ClientListView.ItemsSource = client;
    }

    private void SearchButtonClient(object sender, RoutedEventArgs e)
    {
        string searchText = SearchTextBoxClient.Text;

        List<Client> searchResults = new List<Client>();
        foreach (Client client in db.Clients)
        {
            if (client.Surname.Contains(searchText) 
                || client.Name.Contains(searchText) 
                || (client.Patronymic != null && client.Patronymic.Contains(searchText)))
            {
                searchResults.Add(client);
            }
        }
        ClientListView.ItemsSource = searchResults;
    }
    /* <--------------------Client------------------------> */
    
    
    
    /* <--------------------Services------------------------> */
    private void AddButtonService(object sender, RoutedEventArgs e)
    {
        AddEditService addEditService = new AddEditService();
        addEditService.Show();
    }
    
    private void DeleteButtonService(object sender, RoutedEventArgs e)
    {
        Service selectedService = (Service)ServiceListView.SelectedItem;
        if (selectedService != null)
        {
            db.serviceSet.Remove(selectedService);
            db.SaveChanges();
            
            List<Service> services = db.Services.ToList();
            ServiceListView.ItemsSource = services;
        }
    }
    
    private void UpdateButtonService(object sender, RoutedEventArgs e)
    {
        List<Service> service = db.Services.ToList();
        ServiceListView.ItemsSource = service;
    }

    private void SearchButtonService(object sender, RoutedEventArgs e)
    {
        string searchText = SearchTextBoxService.Text;

        List<Service> searchResults = new List<Service>();
        foreach (Service service in db.Services)
        {
            if (service.Title.Contains(searchText))
            {
                searchResults.Add(service);
            }
        }
        ServiceListView.ItemsSource = searchResults;
    }
    /* <--------------------Services------------------------> */
    
    
    
    /* <--------------------Partner------------------------> */
    private void AddButtonPartner(object sender, RoutedEventArgs e)
    {
        AddEditPartner addEditPartner = new AddEditPartner();
        addEditPartner.Show();
    }
    
    private void DeleteButtonPartner(object sender, RoutedEventArgs e)
    {
        Partner selectedService = (Partner)PartnerListView.SelectedItem;
        if (selectedService != null)
        {
            db.partnerSet.Remove(selectedService);
            db.SaveChanges();
            
            List<Partner> partner = db.Partners.ToList();
            PartnerListView.ItemsSource = partner;
        }
    }
    
    private void UpdateButtonPartner(object sender, RoutedEventArgs e)
    {
        List<Partner> partner = db.Partners.ToList();
        PartnerListView.ItemsSource = partner;
    }

    private void SearchButtonPartner(object sender, RoutedEventArgs e)
    {
        string searchText = SearchTextBoxPartner.Text;

        List<Partner> searchResults = new List<Partner>();
        foreach (Partner partner in db.Partners)
        {
            if (partner.Title.Contains(searchText))
            {
                searchResults.Add(partner);
            }
        }
        PartnerListView.ItemsSource = searchResults;
    }
    /* <--------------------Partner------------------------> */
}
