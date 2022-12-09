
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Input;
using WpfClient.Commands;
using WpfClient.Model;

namespace WpfClient.ViewModel
{
    public class SportItemViewModel : ViewModelBase
    {
        private ObservableCollection<SportItemModel> _sportItems;
        private SportItemModel _currentItem;
        private ICommand _deleteItem;
        private ICommand _addItem;
        private ICommand _updateItem;
        private HttpClient client = new HttpClient();
        public SportItemViewModel()
        {
            var json = client.GetStringAsync("https://localhost:44335/api/Goods").Result;
            var list = JsonConvert.DeserializeObject<List<SportItemModel>>(json);
            SportItems = new ObservableCollection<SportItemModel>(list);
            AddItem = new StoredCommand(_ => AddItemMethod());
        }
        public ObservableCollection<SportItemModel> SportItems
        {
            get { return _sportItems; }
            set { _sportItems = value; }
        }
        public SportItemModel CurrentItem {
            get { return _currentItem; }
            set { _currentItem = value; }
        }
        public ICommand DeleteItem
        {
            get
            {
                _deleteItem ??= new StoredCommand(_ => DeleteItemMethod());
                return _deleteItem;
            }
        }
        public ICommand AddItem
        {
            get
            {
                return _addItem;
            }
            set { _addItem = value; }
        }
        public ICommand UpdateItem
        {
            get
            {
                _updateItem ??= new StoredCommand(_ => UpdateItemMethod());
                return _updateItem;
            }
        }
        private void DeleteItemMethod()
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = JsonContent.Create(CurrentItem),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://localhost:5001/api/Goods", UriKind.Relative)
            };
            client.SendAsync(request).Wait();
        }
        private void AddItemMethod()
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = JsonContent.Create(CurrentItem),
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:5001/api/Goods", UriKind.Relative)
            };
            client.SendAsync(request).Wait();
        }
        private void UpdateItemMethod()
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = JsonContent.Create(CurrentItem),
                Method = HttpMethod.Put,
                RequestUri = new Uri("https://localhost:5001/api/Goods", UriKind.Relative)
            };
            client.SendAsync(request).Wait();
        }
    }
}
