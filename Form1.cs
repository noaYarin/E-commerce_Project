using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_2
{

    public partial class CommerceForm : Form
    {
        const string programName = "E-commerce Project\nBy Noa-Yarin Levi and Chen Brown";
        Manager manager;
        public CommerceForm()
        {
            InitializeComponent();
            manager = new Manager(programName, "sellers_data.txt");
            //InitalBuyers(manager);
        }

    private void InitalBuyers(Manager manager)
        {
            Address addr1 = new Address("Zamenhof", 7, "Netanya", "ISR");
            Address addr3 = new Address("Zamenhoffff", 77, "Netanya", "ISR");
            Address addr4 = new Address("Za", 12, "Netanya", "ISR");

            manager.AddUserBuyer("Chen", "123@!!tg", addr1);
            Address addr2 = new Address("abc", 123, "Ruppin", "ISR");
            manager.AddUserBuyer("Noa", "123@!!tg", addr1);
        }

        private void errorEnableVisible() 
        {
            txtErrorFields.Visible = true;
            lblErrorFields.Visible = true;
        }
        private void errorDisableVisible() 
        {
            txtErrorFields.Text = "";
            txtErrorFields.Visible = false;
            lblErrorFields.Visible = false;
        }

        private void btnAddBuyer_Click(object sender, EventArgs e)
        {
            DialogResult drAddBuyer = MessageBox.Show("Please confirm all the details are correct", "are you sure?", MessageBoxButtons.OKCancel);
            if (drAddBuyer == System.Windows.Forms.DialogResult.OK)
            {
                AddBuyer(manager);
            }
            else
            {
                DialogResult adCorrectBuyer = MessageBox.Show("Byer does no added");
            }
        }

        private void AddBuyer(Manager manager)
        {
            string buyerName = txtNameBuyer.Text;
            string city = txtCity.Text;
            string country = txtCountry.Text;
            string street = txtStreet.Text;
            int streetNumber = (int)numStreetNamber.Value;
            string password = txtPassword.Text;

            try
            {
                Address currentAddr = new Address(street, streetNumber, city, country);
                manager.AddUserBuyer(buyerName, password, currentAddr);
                errorDisableVisible();
                ShowBuyers(manager);
                DialogResult adCorrectBuyer = MessageBox.Show("Byer added");
            }
            catch (Exception ex)
            {
                DialogResult adCorrectBuyer = MessageBox.Show("Byer does no added");
                errorEnableVisible();
                txtErrorFields.Text = ex.Message;
            }
           
        }


        private void btnShowBuyers_Click(object sender, EventArgs e)
        {
            ShowBuyers(manager);
        }

        private void ShowBuyers(Manager manager)
        {
            try
            {
                string resultBuyers = manager.ShowAllBuyers();
                richShowBuyers.Text = resultBuyers;
                errorDisableVisible();
            }
            catch (Exception ex)
            {
                errorEnableVisible();
                txtErrorFields.Text = ex.Message;
            }
        }


        private void btnAddSeller_Click(object sender, EventArgs e)
        {
            DialogResult drAddBuyer = MessageBox.Show("Please confirm all the details are correct", "are you sure?", MessageBoxButtons.OKCancel);
            if (drAddBuyer == System.Windows.Forms.DialogResult.OK)
            {
                AddSeller(manager);
            }
            else
            {
                MessageBox.Show("Seller does not added");
            }
        }


        private void AddSeller(Manager manager)
        {
            string SellerName = txtNameSeller.Text;
            string city = txtCity.Text;
            string country = txtCountry.Text;
            string street = txtStreet.Text;
            int streetNumber = (int)numStreetNamber.Value;
            string password = txtPassword.Text;

            try
            {
                Address currentAddr = new Address(street, streetNumber, city, country);
                manager.AddUserSeller(SellerName, password, currentAddr);
                errorDisableVisible();
                ShowSellers(manager);
                DialogResult adCorrectBuyer = MessageBox.Show("Seller added");
            }
            catch (Exception ex)
            {
                errorEnableVisible();
                txtErrorFields.Text = ex.Message;
                MessageBox.Show("Seller does not added");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ShowSellers(manager);
        }

        private void ShowSellers(Manager manager)
        {
            try
            {
                string resultSellers = manager.ShowAllSellers();
                richShowSellers.Text = resultSellers;
                errorDisableVisible();

            }
            catch (Exception ex)
            {
                errorEnableVisible();
                txtErrorFields.Text = ex.Message;
            }
        }

        private void btnAddProductSeller_Click(object sender, EventArgs e)
        {
            if(txtProductNameSeller.Text.Equals(string.Empty) || txtProductPrice.Text.Equals(string.Empty))
            {
                errorEnableVisible();  
                txtErrorFields.Text = "Not all information provided!";
                return;
            }
            if(!radChildren.Checked && !radClothes.Checked && !radElectricity.Checked && !radOffice.Checked) 
            {
                errorEnableVisible();
                txtErrorFields.Text = "category didn't choosed";
                return;
            }
            errorDisableVisible();

            try
            {
                AddProductToSeller(manager);
                ShowSellers(manager);
                MessageBox.Show("Product added");
            }
            catch (Exception ex)
            {
                txtErrorFields.Text = ex.Message;
                errorEnableVisible();
                MessageBox.Show("Product not added");
            }
        }


        private void AddProductToSeller(Manager manager)
        {
            string name = txtProductNameSeller.Text.ToLower();
            int price = int.Parse(txtProductPrice.Text);
            string sellerName = txtNameSellerAddProduct.Text.ToLower();
            int index = 0;
            try
            {
                if (radChildren.Checked)
                    index = 1;
                else if (radElectricity.Checked)
                    index = 2;
                else if (radOffice.Checked)
                    index= 3;
                else if (radClothes.Checked)
                    index = 4;


                Category category = manager.AddCategory(index);
                if (category != null)
                {
                    manager.AddNewProduct(new Product(name, price, category), sellerName);
                    Console.WriteLine("\nProduct successfully added!");
                }
                else
                {
                    throw new Exception("Product not added");
                    
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"An error occurred: Fields are empty");
                throw new Exception("An error occurred: Fields are empty");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                throw new Exception($"An error occurred: {e.Message}");
            }
        }

        private void btnAddProductBuyer_Click(object sender, EventArgs e)
        {
            if(txtNameBuyerAddProduct.Text.Equals(string.Empty) || txtSellerNameToBuy.Text.Equals(string.Empty) || txtProductNameBuyer.Text.Equals(string.Empty))
            {
                errorEnableVisible();
                txtErrorFields.Text = "Not all information provided!";
                MessageBox.Show("Product not added");
                return;
            }
            errorDisableVisible();

            try
            {
                AddProductToCart(manager);
                ShowBuyers(manager);
                MessageBox.Show("Product added");

            }
            catch (Exception ex)
            {
                txtErrorFields.Text = ex.Message;
                errorEnableVisible();
                MessageBox.Show("Product not added");
            }
        }


        private void AddProductToCart(Manager manager)
        {
            string buyerName = txtNameBuyerAddProduct.Text.ToLower();
            string sellerName = txtSellerNameToBuy.Text.ToLower();
            string productName  = txtProductNameBuyer.Text.ToLower();

            try
            {
                if (chkBoxSpecialPackage.Checked)
                {
                    manager.AddProductToCart(buyerName, sellerName, productName, true);
                }
                else
                {
                    manager.AddProductToCart(buyerName, sellerName, productName, false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            manager.SaveData();
            manager.ClearData();
            base.OnFormClosing(e);
        }
    }
}
