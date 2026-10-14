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
    public class HandleMoney
    {
        //update balance
        //update debt
        //total income should be handled in MainWindow.xaml.cs - add all clients total income up and display on ui
        //outstanding balance (client debt) - same thing with total income - simply adding varaibles and displaying on ui
        public void AddBalance(float amount)
        {
            using var db = new AppDbContext();
            var money = db.money.First();
            money.balance = money.balance + amount;
            db.SaveChanges();
            MessageBox.Show("Balance updated ", "", MessageBoxButton.OK);
        }
        public void RemoveBalance(float amout)
        {
            using var db = new AppDbContext();
            var money = db.money.First();
            money.balance = money.balance - amout;
            db.SaveChanges();
            MessageBox.Show("Balance updated ", "", MessageBoxButton.OK);
        }
        public void AddDebt(float amount)
        {
            using var db = new AppDbContext();
            var money = db.money.First();
            money.totaldebt = money.totaldebt + amount;
            db.SaveChanges();
            MessageBox.Show("Debt updated ", "", MessageBoxButton.OK);

        }
        public void RemoveDebt(float amount)
        {
            using var db = new AppDbContext();
            var money = db.money.First();
            money.totaldebt = money.totaldebt - amount;
            db.SaveChanges();
            MessageBox.Show("Debt updated ", "", MessageBoxButton.OK);
        }
    }
}
