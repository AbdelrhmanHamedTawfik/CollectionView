using System;
using System.Windows.Input;
using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class IncrementalLoadingPage : ContentPage
    {
        AnimalsViewModel animals = new AnimalsViewModel();
        public ICommand NavigateCommand { get; private set; }
        public IncrementalLoadingPage()
        {
            InitializeComponent();
            //BindingContext = new AnimalsViewModel();
            NavigateCommand = new Command<Type>(
                async (Type pageType) =>
                {
                    Page page = (Page)Activator.CreateInstance(pageType);
                    await Navigation.PushAsync(page);
                });
            BindingContext = this;
        }

        void OnCollectionViewRemainingItemsThresholdReached(object sender, EventArgs e)
        {
            // Retrieve more data here, or via the RemainingItemsThresholdReachedCommand.
            // This sample retrieves more data using the RemainingItemsThresholdReachedCommand.
        }

    }
}
