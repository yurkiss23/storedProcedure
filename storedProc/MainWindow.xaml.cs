using Newtonsoft.Json;
using storedProc.Entities;
using storedProc.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace storedProc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static EFContext _context;
        public static List<UserViewModel> userList;
        public MainWindow()
        {
            InitializeComponent();
            _context = new EFContext();
        }

        static void GetDataSQLStorage()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var jsonOut = new SqlParameter();
            jsonOut.ParameterName = "@JSONOutput";
            jsonOut.Direction = ParameterDirection.Output;
            jsonOut.SqlDbType = SqlDbType.NVarChar;
            jsonOut.Size = -1;
            string sql = @"EXEC [dbo].[selectUsers] @From, @To, @JSONOutput";
            _context.Database.ExecuteSqlCommand(sql,
                new SqlParameter("@From", Convert.ToInt32(5002)),
                new SqlParameter("@To", Convert.ToInt32(7001)),
                jsonOut);
            userList = JsonConvert.DeserializeObject<List<UserViewModel>>(jsonOut.Value.ToString());
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string elTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            MessageBox.Show(elTime);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetDataSQLStorage();
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnFind.IsEnabled = true;
        }
    }
}
