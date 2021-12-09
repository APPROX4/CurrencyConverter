using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CurrencyConverter
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            ClearControls();


            BindCurrency();
        }

        #region Bind Currency From and To Combobox
        private void BindCurrency()
        {

            DataTable dtCurrency = new DataTable();


            dtCurrency.Columns.Add("Text");


            dtCurrency.Columns.Add("Value");


            dtCurrency.Rows.Add("--SELECT--", 0);
            dtCurrency.Rows.Add("Bangladeshi Takas", 1);
            dtCurrency.Rows.Add("US Dollars", 85.6049);
            dtCurrency.Rows.Add("Euros", 96.8544);
            dtCurrency.Rows.Add("Argentine Pesos", 0.846165);
            dtCurrency.Rows.Add("Indian Rupees", 1.13492);
            dtCurrency.Rows.Add("Turkish Lire", 6.26088);


            cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;


            cmbFromCurrency.DisplayMemberPath = "Text";


            cmbFromCurrency.SelectedValuePath = "Value";


            cmbFromCurrency.SelectedIndex = 0;


            cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
        }
        #endregion

        #region Button Click Event
        private void Button1_click(object sender, EventArgs e)
        {
            // Launch browser to Discord...
            System.Diagnostics.Process.Start("http://www.discord.gg/RPr5v3d");
        }


        private void Convert_Click(object sender, RoutedEventArgs e)
        {



            double ConvertedValue;


            if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {

                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                txtCurrency.Focus();
                return;
            }
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {

                MessageBox.Show("Please Select Currency From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                cmbFromCurrency.Focus();
                return;
            }

            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {

                MessageBox.Show("Please Select Currency To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                cmbToCurrency.Focus();
                return;
            }


            if (cmbFromCurrency.Text == cmbToCurrency.Text)
            {

                ConvertedValue = double.Parse(txtCurrency.Text);


                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
            else
            {

                ConvertedValue = (double.Parse(cmbFromCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbToCurrency.SelectedValue.ToString());


                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
        }


        private void Clear_Click(object sender, RoutedEventArgs e)
        {

            ClearControls();
        }
        #endregion

        #region Extra Events


        private void ClearControls()
        {
            txtCurrency.Text = string.Empty;
            if (cmbFromCurrency.Items.Count > 0)
                cmbFromCurrency.SelectedIndex = 0;
            if (cmbToCurrency.Items.Count > 0)
                cmbToCurrency.SelectedIndex = 0;
            lblCurrency.Content = "";
            txtCurrency.Focus();
        }
        #endregion

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
