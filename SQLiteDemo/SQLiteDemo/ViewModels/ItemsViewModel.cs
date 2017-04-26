using System;
using System.Diagnostics;
using System.Threading.Tasks;

using SQLiteDemo.Helpers;
using SQLiteDemo.Models;
using SQLiteDemo.Views;

using Xamarin.Forms;

namespace SQLiteDemo.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableRangeCollection<Item>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            DeleteCommand = new Command<Item>(DelteItem);

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Item;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        private async void DelteItem(Item item)
        {
            var confirm = await App.Current.MainPage.DisplayAlert("Delete item", "Are you sure?", "Delete it", "Cancel");
            if(!confirm)return;

            await DataStore.DeleteItemAsync(item);

            await ExecuteLoadItemsCommand();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync();
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}