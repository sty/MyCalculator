using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MyCalculatorProject.CheckBook
{
   
    /// <summary>
    /// Interaction logic for MyCheckBook.xaml
    /// </summary>
    public partial class MyCheckBook : Window
    {
        SqlConnection con;
        CheckBookDataSet ds;
        SqlDataAdapter adap;
        SqlCommandBuilder build;
        SqlCommand command;

        public MyCheckBook()
        {
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\CheckBook.mdf;Integrated Security=True";
            con.Open();
            adap = new SqlDataAdapter("Select * from Account", con);
            ds = new CheckBookDataSet();
            adap.Fill(ds, "Account");
            dataGridView.ItemsSource = ds.Tables[0].DefaultView;

           
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            /*build = new SqlCommandBuilder(adap);
            adap.DeleteCommand = build.GetDeleteCommand(true);
           
            adap.UpdateCommand = build.GetUpdateCommand(true);
            adap.InsertCommand = build.GetInsertCommand(true);
            



            adap.Update(ds, "Account");
           Boolean ap = adap.AcceptChangesDuringUpdate();*/
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\CheckBook.mdf;Integrated Security=True";
            con.Open();

            SqlTransaction t = con.BeginTransaction();
            command = con.CreateCommand();
            command.Transaction = t;
                command.CommandText = "INSERT INTO Account (AccountID,Name, Business, Institution,AccountType) VALUES(5,'Bbbbboy', 'film', 'SuNY', 'checking')";
                command.ExecuteNonQuery();
                con.Close();
            
           

        }
      
    }
}
