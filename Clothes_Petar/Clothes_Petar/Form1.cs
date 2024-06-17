using Clothes_Petar.Controller;
using Clothes_Petar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clothes_Petar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductController productController = new ProductController();
        ProductTypeController productTypeController = new ProductTypeController();

        private void Form1_Load(object sender, EventArgs e)
        {
            List<ProductType> allVegetables = productTypeController.GetAllProductTypes();
            comboBox1.DataSource = allVegetables;
            comboBox1.DisplayMember = "TypeName";
            comboBox1.ValueMember = "Id";

            AddList();
        }

        private void AddList()
        {
            List<Product> allClothes = productController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allClothes)
            {
                listBox1.Items.Add($"{item.Id}-{item.Name}, Price: {item.Price} Size: {item.Size} gender: {item.Gender} type: {item.ProductType.TypeName}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || comboBox1.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                comboBox1.Focus();
                return;
            }

            Product product = new Product();
            product.Name = textBox2.Text;
            product.Price = double.Parse(textBox3.Text);
            product.ProductTypeId = (int)comboBox1.SelectedValue;
            product.Size = textBox4.Text;
            product.Gender = textBox6.Text;
            product.Description = textBox5.Text;

            productController.Create(product);
            MessageBox.Show("Записът е успешно добавен!");
            ClearScreen();
            AddList();
        }
        private void ClearScreen()
        {
            textBox1.BackColor = Color.White; textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            listBox1.Text = "";
            comboBox1.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }

            Product foundedcloth = productController.Get(findId);
            if (foundedcloth == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }

            LoadRecord(foundedcloth);

            DialogResult answer = MessageBox.Show($"Наистина ли искате да изтриете запис No {findId}?",
                "PROMPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                productController.Delete(findId);
            }

            AddList();
        }

        private void LoadRecord(Product product)
        {
            textBox1.BackColor = Color.White;
            textBox1.Text = product.Id.ToString();
            textBox2.Text = product.Name;
            textBox3.Text = product.Price.ToString();
            textBox4.Text = product.Size;
            textBox5.Text = product.Description;
            textBox6.Text = product.Gender;
            comboBox1.Text = product.ProductTypeId.ToString();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }
            //tursi po id
            Product findedDog = productController.Get(findId);
            if (findedDog == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }

            LoadRecord(findedDog);
        }

        

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }
    }
}
