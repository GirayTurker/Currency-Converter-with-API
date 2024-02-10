using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
using Newtonsoft.Json;

namespace CurrencyConverterAPI
{
    
    public partial class MainWindow : Window
    {
        //Empty Root Object
        Root val = new Root();
        public MainWindow()
        {
            
            InitializeComponent();
            GetValue();
        }

        //Method to clear all user entries
        private void ClearUserInputs()
        {
            try
            {
                txtCurrency.Text = string.Empty;
                if (cmbFromCurrency.Items.Count > 0) { cmbFromCurrency.SelectedIndex = 0; }
                if (cmbToCurrency.Items.Count > 0) { cmbToCurrency.SelectedIndex = 0; }
                lblCurrency.Content = "";
                txtCurrency.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Data Validation for Amount Text Box
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            //ClearControls method is used to clear all control values
            ClearUserInputs();
        }

        public void BindCurrencyFromHTTP()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Rate");

            //Add rows in DataTable with text and value
            //Set a value which fetch from API
            dt.Rows.Add("--SELECT--", 0);
            var properties = typeof(Rate).GetProperties();
            foreach (var property in properties)
            {
                // Get the name of the property
                string propertyName = property.Name;

                // Get the value of the property using reflection
                var propertyValue = property.GetValue(val.rates);

                // Add the name and value to the DataTable
                dt.Rows.Add(propertyName, propertyValue);
            }

            //Datatable data assign From currency Combobox
            cmbFromCurrency.ItemsSource = dt.DefaultView;

            //DisplayMemberPath property is used to display data in Combobox
            cmbFromCurrency.DisplayMemberPath = "Text";

            //SelectedValuePath property is used to set value in Combobox
            cmbFromCurrency.SelectedValuePath = "Rate";

            //SelectedIndex property is used for when bind Combobox it's default selected item is first
            cmbFromCurrency.SelectedIndex = 0;

            //All Property Set For To Currency Combobox As From Currency Combobox
            cmbToCurrency.ItemsSource = dt.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Rate";
            cmbToCurrency.SelectedIndex = 0;
        }

        //Method to async API HTTP request / data serialize & deserialize
        public static async Task<Root> GetData<T>(string url)
        {
            var myRoot = new Root();
            try
            {
                //HttpClient sending and receiving HTTP request
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //Serialize HTTP content as string
                        var ResponseString = await response.Content.ReadAsStringAsync();
                        //Deserialize Json Object
                        var ResponseObject = JsonConvert.DeserializeObject<Root>(ResponseString);

                        MessageBox.Show("TimeStamp: " + ResponseObject.timestamp, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        return ResponseObject;
                    }
                    return myRoot;
                }
            }
            catch
            {
                return myRoot;
            }
        }
        //Get Value from http with App ID (API Call)
        private async void GetValue()
        {
            val = await GetData<Root>("https://openexchangerates.org/api/latest.json?app_id=YOUR_KEY_IS_HERE");
            BindCurrencyFromHTTP();
        }
    }
}