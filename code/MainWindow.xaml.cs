using CRMwpf.Data;
using Microsoft.VisualBasic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRMwpf
{
    /// IMPORTANT NOTE FOR READING
    ///  /// IMPORTANT NOTE FOR READING
    ///   /// IMPORTANT NOTE FOR READING
    ///    /// IMPORTANT NOTE FOR READING
    ///    The XAML code is 100 percent ai - All the c# code u see like below is 1000% my code :)
    ///    The REASON the xaml is ai is because i dont have the time/need/want/have to study xaml. My focus is on software + game development NOT UI!!!!!
    ///    PLEASE READ ABOVE - all of it ;)
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Program();
        }
        void Program()
        {
            using var db = new AppDbContext();
            db.Database.EnsureCreated();
            if (!db.money.Any())
            {
                db.money.Add(new CRMwpf.models.Money
                {
                    Id = 1,
                    balance = 0,
                    totaldebt = 0,
                    totalincome = 0,
                    outstandingbalance = 0
                });
                db.SaveChanges();
            }
            if (!db.business.Any())
            {
                db.business.Add(new CRMwpf.models.business
                {
                    Id = 1,
                    name = "",
                    address = "",
                    email = "",
                    website = "www.",
                    phonenumber = ""
                    
                });
                db.SaveChanges();
            }    
        }
        void UpdateBusinessText()
        {
            using var db = new AppDbContext();
            //update current business information ui
            var business = db.business.First();
            BusinessNameTextBox.Text = $"{business.name}";
            BusinessAddressTextBox.Text = $"{business.address}";
            BusinessWebsiteTextBox.Text = $"{business.website}";
            BusinessEmailTextBox.Text = $"{business.email}";
            BusinessPhoneTextBox.Text = $"{business.phonenumber}";
        }
        void UpdateClientText()
        {
            //ClientDashboardAmountTextBox
            //ClientDashboardIncomeTextBox
            //ClientDashboardOutstandingTextBox
            using var db = new AppDbContext();
            int clientamount = 0;
            float totalincome = 0;
            float outstandingbalancetotal = 0;
            var clientlist = db.client.ToList();
            foreach (var client in clientlist)
            { 
                clientamount++;
                totalincome = totalincome + client.income;
                outstandingbalancetotal = outstandingbalancetotal + client.debt;
            }
            ClientDashboardAmountTextBox.Text = $"{clientamount}";
            ClientDashboardIncomeTextBox.Text = $"{totalincome}";
            ClientDashboardOutstandingTextBox.Text = $"{outstandingbalancetotal}";
        }
        private void MenuClick(object sender, RoutedEventArgs e)
        {
            using var db = new AppDbContext();
            //updating client overview ui
            var clientlist = db.client.ToList();
            int clientamount = 0;
            float totaldebt = 0;
            foreach (var client in clientlist)
            {
                totaldebt = totaldebt + client.debt;
                clientamount++;
            }
            ClientAmountTextBox.Text = $"{clientamount}";
            TotalClientOwedTextBox.Text = $"{totaldebt}";

            //updating money ovewview ui
            var money = db.money.First();
            CurrentBalanceTextBox.Text = $"{money.balance}";
            TotalIncomeTextBox.Text = $"{money.totalincome}";
            TotalDebtTextBox.Text = $"{money.totaldebt}";


            BusinessMenu.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Visible;
            ClientMenu.Visibility = Visibility.Collapsed;
            CreateClientMenu.Visibility = Visibility.Collapsed;
            EDITClientMenu.Visibility = Visibility.Collapsed;
        }
        private void BusinessClick(object sender, RoutedEventArgs e)
        {
            UpdateBusinessText();

            BusinessMenu.Visibility = Visibility.Visible;
            MainMenu.Visibility = Visibility.Collapsed;
            ClientMenu.Visibility = Visibility.Collapsed;
            CreateClientMenu.Visibility = Visibility.Collapsed;
            EDITClientMenu.Visibility = Visibility.Collapsed;

        }
        private void ClientClick(object sender, RoutedEventArgs e)
        {
            BusinessMenu.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Collapsed;
            ClientMenu.Visibility = Visibility.Visible;
            CreateClientMenu.Visibility = Visibility.Collapsed;
            EDITClientMenu.Visibility = Visibility.Collapsed;
            UpdateClientText();
        }
        private void MoneyClick(object sender, RoutedEventArgs e)
        {

        }
        private void DebtClick(object sender, RoutedEventArgs e)
        {

        }
        private void ChangeNameClick(object sender, RoutedEventArgs e)
        {
            using var db = new AppDbContext();
            var B = db.business.First();
            B.name = NewBusinessNameTextBox.Text;
            db.SaveChanges();
            UpdateBusinessText();
        }
        private void ChangeAddressClick(object sender, RoutedEventArgs e)
        {
            using var db = new AppDbContext();
            var B = db.business.First();
            B.address = NewBusinessAddressTextBox.Text;
            db.SaveChanges();
            UpdateBusinessText();
        }
        private void ChangeWebsiteClick(object sender, RoutedEventArgs e)
        {
            using var db = new AppDbContext();
            var B = db.business.First();
            B.website = NewBusinessWebsiteTextBox.Text;
            db.SaveChanges();
            UpdateBusinessText();
        }
        private void ChangeEmailClick(object sender, RoutedEventArgs e)
        {
            using var db = new AppDbContext();
            var B = db.business.First();
            B.email = NewBusinessEmailTextBox.Text;
            db.SaveChanges();
            UpdateBusinessText();
        }
        private void ChangePhoneClick(object sender, RoutedEventArgs e)
        {
            using var db = new AppDbContext();
            var B = db.business.First();
            B.phonenumber = NewBusinessPhoneTextBox.Text;
            db.SaveChanges();
            UpdateBusinessText();
        }
        private void SearchClientClick(object sender, RoutedEventArgs e)
        {
            string text = SearchClientTextBox.Text;
            
            HandleClient hc = new HandleClient();
            hc.SearchClient(text);
            UpdateClientText();
        }
        private void CreateClientClick(object sender, RoutedEventArgs e)
        {
            CreateClientMenu.Visibility = Visibility.Visible;
            BusinessMenu.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Collapsed;
            ClientMenu.Visibility = Visibility.Collapsed;

        }
        private void BackToClientMenuClick(object sender, RoutedEventArgs e)
        {
            CreateClientMenu.Visibility = Visibility.Collapsed;
            BusinessMenu.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Collapsed;
            ClientMenu.Visibility = Visibility.Visible;
        }
        private void AddClientClick(object sender, RoutedEventArgs e)
        {
            //NewClientAddressTextBox 
            //NewClientEmailTextBox
            //NewClientNameTextBox
            //NewClientNumberTextBox
            string address = NewClientAddressTextBox.Text;
            string email = NewClientEmailTextBox.Text;
            string name = NewClientNameTextBox.Text;
            string number = NewClientNumberTextBox.Text;

            HandleClient hc = new HandleClient();
            hc.CreateClient(number, name, address, email);

            CreateClientMenu.Visibility = Visibility.Collapsed;
            BusinessMenu.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Collapsed;
            ClientMenu.Visibility = Visibility.Visible;
            UpdateClientText();

        }
        private void EditClientClick(object sender, RoutedEventArgs e)
        {
            //EDITClientMenu
            BusinessMenu.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Collapsed;
            ClientMenu.Visibility = Visibility.Collapsed;
            CreateClientMenu.Visibility = Visibility.Collapsed;
            EDITClientMenu.Visibility = Visibility.Visible;

            EditClientAddDebtTextBox.Text = "0";
            EditClientRemoveDebtTextBox.Text = "0";
            EditClientRemoveIncomeTextBox.Text = "0";
            EditClientAddIncomeTextBox.Text = "0";
        }
        private void EditBackToClientMenuClick(object sender, RoutedEventArgs e)
        {
            BusinessMenu.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Collapsed;
            ClientMenu.Visibility = Visibility.Visible;
            CreateClientMenu.Visibility = Visibility.Collapsed;
            EDITClientMenu.Visibility = Visibility.Collapsed;
        }
        private void ApplyEditClientClick(object sender, RoutedEventArgs e)
        {
            using var db = new AppDbContext();

            string name = EditClientNameTextBox.Text;

            string newnumber = EditClientNumberTextBox.Text;
            string newaddress =EditClientAddressTextBox.Text;
            string newemail = EditClientEmailTextBox.Text;
            string Saddincome = EditClientAddIncomeTextBox.Text;
            string Sadddebt = EditClientAddDebtTextBox.Text;
            string Sremovedebt = EditClientRemoveDebtTextBox.Text;
            string Sremoveincome = EditClientRemoveIncomeTextBox.Text;
            
            if (float.TryParse(Sadddebt, out float adddebt) &&
                float.TryParse(Sremovedebt, out float removedebt) &&
                float.TryParse(Saddincome, out float addincome) &&
                float.TryParse(Sremoveincome, out float removeincome))
            {
                var clientlist = db.client.ToList();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    foreach (var client in clientlist)
                    {
                        if (client.name == name)
                        {
                            if (!string.IsNullOrWhiteSpace(newnumber)) client.number = newnumber;

                            if (!string.IsNullOrWhiteSpace(newaddress)) client.address = newaddress;

                            if (!string.IsNullOrWhiteSpace(newemail)) client.email = newemail;

                            client.income = client.income + addincome;
                            client.income = client.income - removeincome;

                            client.debt = client.debt + adddebt;
                            client.debt = client.debt - removedebt;
                            
                            db.SaveChanges();
                            MessageBox.Show("client updated");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("there must be a number in the add debt/income + subtract debt/income");
            }
           
        }
        private void RemoveClientClick(object sender, RoutedEventArgs e)
        {
            //RemoveClientTextBox 
            string name = RemoveClientTextBox.Text;
            HandleClient hc = new HandleClient();

            hc.RemoveClient(name);
            UpdateClientText();
        }
        
    }
}