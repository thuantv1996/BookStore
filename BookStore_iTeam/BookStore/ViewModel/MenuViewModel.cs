using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookStore.View;

namespace BookStore.ViewModel
{
    public class MenuViewModel
    {
        public ICommand BookCommand { get; set; }
        public ICommand BookInfoCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ImportBookCommand { get; set; }
        public ICommand SellCommand { get; set; }
        public ICommand CashCommand { get; set; }
        public ICommand FindCommand { get; set; }
        public ICommand SearchCustomerCommand { get; set; }
        public ICommand SettingCommand { get; set; }
        public ICommand InventoryReportCommand { get; set; }
        public ICommand IndebtednessReportCommand { get; set; }
        public MenuViewModel()
        {
            BookCommand = new RelayCommand<object>((p) =>
            {
                Books();
            }, true);
            BookInfoCommand = new RelayCommand<object>((p) =>
            {
                Info();
            }, true);
            CustomerCommand = new RelayCommand<object>((p) =>
            {
                Customer();
            }, true);
            ImportBookCommand = new RelayCommand<object>((p) =>
            {
                ImportBook();
            }, true);
            SellCommand = new RelayCommand<object>((p) =>
            {
                Sell();
            }, true);
            CashCommand = new RelayCommand<object>((p) =>
            {
                Cash();
            }, true);
            FindCommand = new RelayCommand<object>((p) =>
            {
                Find();
            }, true);
            SearchCustomerCommand = new RelayCommand<object>((p) =>
            {
                SearchCustomer();
            }, true);
            SettingCommand = new RelayCommand<object>((p) =>
            {
                Setting();
            }, true);
            InventoryReportCommand = new RelayCommand<object>((p) =>
            {
                InventoryReport();
            }, true);

            IndebtednessReportCommand = new RelayCommand<object>((p) =>
            {
                IndebtednessReport();
            },true);
        }
        private void Books()
        {
            Switcher.Switch(new Books());
        }

        private void Info()
        {
            Switcher.Switch(new BookInfo());

        }
        private void Customer()
        {
            Switcher.Switch(new Customers());
        }

        private void ImportBook()
        {
            Switcher.Switch(new ImportBook());
        }

        private void Sell()
        {
            Switcher.Switch(new Sell());
        }

        private void Cash()
        {
            Switcher.Switch(new Cash());
        }

        private void Find()
        {
            Switcher.Switch(new Find());
        }

        private void SearchCustomer()
        {
            Switcher.Switch(new SearchCustomer());
        }

        private void Setting()
        {
            Switcher.Switch(new Setting());
        }
        private void InventoryReport()
        {
            Switcher.Switch(new InventoryReport());
        }
        private void IndebtednessReport()
        {
            Switcher.Switch(new IndebtednessReport());
        }
    }
}
