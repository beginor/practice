using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace CandySearch {

    [Activity(Label = "CandySearch", MainLauncher = true)]
    public class MainActivity : Activity, SearchView.IOnQueryTextListener {

        private ListView listView;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            listView = FindViewById<ListView>(Resource.Id.activity_main_listview);
            var candyAdapter = new CandyAdapter(this);
            listView.Adapter = candyAdapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu) {
            MenuInflater.Inflate(Resource.Menu.activity_main_options, menu);
            var searchView = (SearchView)menu.FindItem(Resource.Id.activity_main_options_search).ActionView;
            searchView.SetOnQueryTextListener(this);
            return true;
        }

        public bool OnQueryTextChange(string newText) {
            //throw new NotImplementedException();
            //Console.WriteLine("OnQueryTextChange: {0}", newText);
            var candyAdapter = (CandyAdapter)listView.Adapter;
            candyAdapter.Filter(newText);
            return true;
        }

        public bool OnQueryTextSubmit(string query) {
            Console.WriteLine("OnQueryTextSubmit: {0}", query);
            return true;
        }

        void OnQueryTextChange (object sender, SearchView.QueryTextChangeEventArgs e) {
            //
        }
    }

    public class CandyAdapter : BaseAdapter {

        private readonly Activity context;

        private IList<Candy> candyList;

        public CandyAdapter(Activity context) {
            this.context = context;
            candyList = Candy.DefaultList();
        }

        public override int Count {
            get {
                return candyList.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position) {
            return candyList[position];
        }

        public override long GetItemId(int position) {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent) {
            View result = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.activity_main_listview_item, parent, false);
            var textView = result.FindViewById<TextView>(Resource.Id.activity_main_listview_item_textview);
            textView.Text = candyList[position].Name;
            return result;
        }

        public void Filter(string searchText) {
            if (!string.IsNullOrEmpty(searchText)) {
                candyList = Candy.DefaultList().Where(c => c.Name.Contains(searchText.ToLower())).ToList();
            }
            else {
                candyList = Candy.DefaultList();
            }
            NotifyDataSetChanged();
        }
    }
}