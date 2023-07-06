using appTemplate.Logics;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace appTemplate.Views
{
    /// <summary>
    /// MngCar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MngCar : MetroWindow
    {
        public MngCar()
        {
            InitializeComponent();
        }

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            this.DataContext = null;

            List<CarList> cars = new List<CarList>();
            try 
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.MyConnString)) 
                {
                    if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                    var query = $@"SELECT Id,
                                         RoomNum,
                                         CarNum,
                                         PhoneNum,
                                         SpecialNote
                                    FROM miniproject.carmng";

                    var cmd = new MySqlCommand(query, conn);
                    var adapter = new MySqlDataAdapter(cmd);
                    var dSet = new DataSet();
                    adapter.Fill(dSet, "CarList");

                    foreach (DataRow dr in dSet.Tables["CarList"].Rows)
                    {
                        cars.Add(new CarList
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            RoomNum = Convert.ToInt32(dr["RoomNum"]),
                            CarNum = Convert.ToInt32(dr["CarNum"]),
                            PhoneNum = Convert.ToString(dr["PhoneNum"]),
                            SpecialNote = Convert.ToString(dr["SpecialNote"])
                        });
                    }
                    Debug.WriteLine("테스트");
                    Debug.WriteLine(cars[0]);

                    this.DataContext = cars;
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("오류", $"DB조회 오류 {ex.Message}", MessageDialogStyle.Affirmative, null);
            }
        }

        private async void BtnCarlist_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = null;

            List<CarList> cars = new List<CarList>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.MyConnString))
                {
                    if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                    var query = $@"SELECT Id,
                                         RoomNum,
                                         CarNum,
                                         PhoneNum,
                                         SpecialNote
                                    FROM miniproject.carmng";

                    var cmd = new MySqlCommand(query, conn);
                    var adapter = new MySqlDataAdapter(cmd);
                    var dSet = new DataSet();
                    adapter.Fill(dSet, "CarList");

                    foreach (DataRow dr in dSet.Tables["CarList"].Rows)
                    {
                        cars.Add(new CarList
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            RoomNum = Convert.ToInt32(dr["RoomNum"]),
                            CarNum = Convert.ToInt32(dr["CarNum"]),
                            PhoneNum = Convert.ToString(dr["PhoneNum"]),
                            SpecialNote = Convert.ToString(dr["SpecialNote"])
                        });
                    }
                    this.DataContext = cars;
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("오류", $"DB조회 오류 {ex.Message}", MessageDialogStyle.Affirmative, null);
            }
        }
    }
}
