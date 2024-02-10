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
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            // Declare ConvertedValue with double DataType for store currency converted value

            double ConvertedValue;

            //Check amount textbox is Null or Blank
            if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {
                //If amount textbox is Null or Blank then show this message box
                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                //After click on Messagebox OK set focus on amount textbox
                txtCurrency.Focus();
                return;
            }

            //currencyfrom is not selected or default text --SELECT--
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0 || cmbFromCurrency.Text == "--SELECT--")
            {
                //Then show message box
                MessageBox.Show("Please Select Currency From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                //Set focus on From Combobox
                cmbFromCurrency.Focus();
                return;
            }
            // currencyTo is not selected or default text --SELECT--
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0 || cmbToCurrency.Text == "--SELECT--")
            {
                //Then show message
                MessageBox.Show("Please Select Currency To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                //Set focus on To Combobox
                cmbToCurrency.Focus();
                return;
            }
            //From and To Combobox selects same value
            if (cmbFromCurrency.Text == cmbToCurrency.Text)
            {
                //Amount textbox value set in ConvertedValue. double.parse is used to change Datatype String To Double. Textbox text have String and ConvertedValue is double datatype
                ConvertedValue = double.Parse(txtCurrency.Text);

                //Show in label converted currency and converted currency name. And ToString("N3") is used for placing 000 after dot(.)
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
            else
            {
                //Calculation for currency converter is From currency value is multiplied(*) with amount textbox value and then that total is divided(/) with To currency value.                
                ConvertedValue = (double.Parse(cmbToCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbFromCurrency.SelectedValue.ToString());

                //Show the label converted currency and converted currency name.
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
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
                    if (response.StatusCode == System.Net.HttpStatusCode.OK && response.IsSuccessStatusCode)
                    {
                        // Set the ellipse fill to green if the connection is successful
                        ChangeEllipseFill("StatusEllipse", Colors.Green);

                        //Serialize HTTP content as string
                        var ResponseString = await response.Content.ReadAsStringAsync();
                        //Deserialize Json Object
                        var ResponseObject = JsonConvert.DeserializeObject<Root>(ResponseString);

                        //MessageBox.Show("TimeStamp: " + ResponseObject.timestamp, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        return ResponseObject;
                    }
                    else
                    {
                        // Set the ellipse fill to red if the connection failed
                        ChangeEllipseFill("StatusEllipse", Colors.Red);
                    }
                    return myRoot;
                }
            }
            catch
            {
                // Set the ellipse fill to red if there's an error connecting to the API
                ChangeEllipseFill("StatusEllipse", Colors.Red);
                return myRoot;
            }
        }
        static void ChangeEllipseFill(string StatusEllipse, Color color)
        {
            // Find the ellipse by name in the application resources
            Ellipse ellipse = Application.Current.MainWindow.FindName(StatusEllipse) as Ellipse;

            // Change the fill color of the ellipse
            if (ellipse != null)
            {
                ellipse.Fill = new SolidColorBrush(color);
            }
        }
        //Get Value from http with App ID (API Call)
        private async void GetValue()
        {
            // Define the URL of the API
            string apiUrl = "https://openexchangerates.org/api/latest.json?app_id=YOUR_KEY_IS_HERE";
            //https://openexchangerates.org/
            try
            {
                // Call the GetData method to fetch data from the API
                val = await GetData<Root>(apiUrl);

                // If the data retrieval is successful, bind the data
                BindCurrencyFromHTTP();
            }
            catch (Exception ex)
            {
                // Handle the exception by displaying a message box
                MessageBoxResult result = MessageBox.Show($"Error retrieving data from the API: Check your API URL! \n\nError Details: {ex.Message}, \n{ex.StackTrace}\n\nDO YOU WANT TO EXIT?", "API Error", MessageBoxButton.YesNo, MessageBoxImage.Error);

                // If the user clicks Yes, exit the application
                if (result == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }
        }

    }
}