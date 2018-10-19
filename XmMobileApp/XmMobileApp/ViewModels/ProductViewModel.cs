using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XmMobileApp.Models;
using XmMobileApp.Services;

namespace XmMobileApp.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private ProductService productService = new ProductService();

        private Product product = new Product();

        public Product Product
        {
            get => product;
            set
            {
                product = value;
                OnPropertyChanged();
            }
        }


        private List<Product> products;

        public List<Product> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public ProductViewModel()
        {
            Task.Run(async () => { await InitializeGetProductAsync(); });
        }

        public async Task InitializeGetProductAsync()
        {
            Products = await productService.GetProducts();
        }

        public Command SubmitCreateProduct
        {
            get
            {
                return new Command(async () =>
                {
                    if (await productService.CreateProduct(product))
                    {
                        await Application.Current.MainPage.DisplayAlert("Success", "Product has been successfully saved", "Okay");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong. Product didn't save", "Okay");
                    }
                });
            }
        }

        public Command SubmitUpdateProduct
        {
            get
            {
                return new Command(async () =>
                {
                    if (await productService.UpdateProduct(product.ProductId, product))
                    {
                        await Application.Current.MainPage.DisplayAlert("Success", "Product has been successfully updated", "Okay");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong. Product didn't update", "Okay");
                    }
                });
            }
        }

        public Command SubmitDeleteProduct
        {
            get
            {
                return new Command(async () =>
                {
                    if (await productService.DeleteProduct(product.ProductId))
                    {
                        await Application.Current.MainPage.DisplayAlert("Success", "Product has been successfully deleted", "Okay");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong. Product didn't delete", "Okay");
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

