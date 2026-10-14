using System;
using CRMwpf.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMwpf.models;
using System.Windows;

namespace CRMwpf
{
    public class HandleClient
    {
        public void CreateClient(string number, string name, string address, string email)
        {
            using var db = new AppDbContext();
            var client = new client();
            client.number = number;
            client.name = name;
            client.address = address;
            client.email = email;
            db.client.Add(client);
            db.SaveChanges();
            MessageBox.Show("client added", "client added", MessageBoxButton.OK);
            return;
        }
        public void RemoveClient(string name)
        {
            using var db = new AppDbContext();
            var clientlist = db.client.ToList();
            foreach (var client in clientlist)
            {
                if (client.name == name)
                {
                    db.client.Remove(client);
                    db.SaveChanges();
                    MessageBox.Show("client removed", "client removed", MessageBoxButton.OK);
                }
            }
            return;
        }
        public void SearchClient(string name)
        {
            //search by name and id so parsing to also check if its a number/id
            if (int.TryParse(name, out int Iid)) ;

            using var db = new AppDbContext();
            var clientlist = db.client.ToList();
            foreach (var client in clientlist)
            {
                if (client.name == name || client.Id == Iid)
                {
                   MessageBox.Show(
                     $"ID: {client.Id}\n" +
                     $"Name: {client.name}\n\n" +
                     $"Email: {client.email}\n" +
                     $"Address: {client.address}\n" +
                     $"Phone number: {client.number}\n\n" +
                     $"Money owed: £{client.debt}\n" +
                     $"Total income from client: £{client.income}",
                     "Client Details",
                     MessageBoxButton.OK,
                     MessageBoxImage.Information
                   );
                }
            }
            return;
        }
    }
}
