using System.Windows;
using System.Collections.ObjectModel;
using System.Linq;
using Practa1.Laba1DataSetTableAdapters;
using Practa1.Data;
using System.ComponentModel;

namespace Practa1
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly StoreContext _context;
        private ObservableCollection<Product> _products;
        private Product _selectedProduct;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyPropertyChanged(nameof(Products));
            }
        }

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                NotifyPropertyChanged(nameof(SelectedProduct));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            _context = new StoreContext();
            LoadData();
            DataContext = this;
        }

        private void LoadData()
        {
            Products = new ObservableCollection<Product>(_context.Products);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateProduct()
        {
            _context.SaveChanges();
        }

        private void DeleteProduct()
        {
            _context.Products.Remove(SelectedProduct);
            _context.SaveChanges();
            Products.Remove(SelectedProduct);
        }

        private void AddProduct()
        {
            var newProduct = new Product
            {
                Name = "New Product",
                Category = "Category",
                Brand = "Brand",
                Price = 9.99m,
                Quantity = 10
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            Products.Add(newProduct);

            SelectedProduct = newProduct;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProduct != null)
            {
                UpdateProduct();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProduct != null)
            {
                DeleteProduct();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProduct();
        }
    }
}
