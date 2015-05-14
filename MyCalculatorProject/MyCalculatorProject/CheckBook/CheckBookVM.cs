using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Input;


namespace MyCalculatorProject.CheckBook
{
    public class CheckBookVM : BaseVM
    {
        public CheckBookVM()
        {
        }

        CbDb _Db = new CbDb();

        public Transaction _NewTransaction = new Transaction { Date = DateTime.Now };
        public Transaction NewTransaction
        {
            get { return _NewTransaction; }
            set { _NewTransaction = value; OnPropertyChanged(); }
        }
        public Account _NewAccount = new Account{Total = 0};
        public Account NewAccount
        {
            get { return _NewAccount; }
            set { _NewAccount = value; OnPropertyChanged(); }
        }




        private ObservableCollection<Transaction> _Transactions;
        public ObservableCollection<Transaction> Transactions
        {
            get { return _Transactions; }
            set { _Transactions = value; OnPropertyChanged(); OnPropertyChanged("Accounts"); }
        }
        

        private ObservableCollection<Account> _Accounts;
        public ObservableCollection<Account> Accounts
        {
            get { return _Accounts; }
            set { _Accounts = value; OnPropertyChanged(); }
        }

        private DelegateCommand _SaveTransaction;
        public ICommand SaveTransaction
        {
            get
            {
                if (_SaveTransaction == null)
                {
                    _SaveTransaction = new DelegateCommand
                    {
                        ExecuteFunction = x =>
                        {
                            _Db.Transactions.Add(_NewTransaction);
                            Account updateAccount = (from A in Accounts where A == _NewTransaction.Account select A).Single();
                            updateAccount.Total += _NewTransaction.Amount;
                            _Db.SaveChanges(); NewTransaction = new Transaction { Date = DateTime.Now };

                        },
                        CanExecuteFunction = x => NewTransaction.Amount != 0 && NewTransaction.Account != null
                    };
                    _NewTransaction.PropertyChanged += (s, e) => _SaveTransaction.OnCanExecuteChanged();
                }
                return _SaveTransaction;
            }

        }
        public DelegateCommand SaveAccount
        {
            get
            {
                return new DelegateCommand
                {
                    ExecuteFunction = _ =>
                    {
                        var acc = _Db.Accounts.Select(x => x.Name).ToList();
                        if (!acc.Contains(_NewAccount.Name) && _NewAccount.Name != null)
                        {
                            _Db.Accounts.Add(_NewAccount);
                            _Db.SaveChanges();
                        }
                    },
                };
            }
        }

        

        public void Fill()
        {
            Transactions = _Db.Transactions.Local;
            Accounts = _Db.Accounts.Local;
            _Db.Accounts.ToList();
            _Db.Transactions.ToList();
        }

    }
}
