
using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Cn.Beginor.ContextActionMode {

	[Activity (Label = "MyListActivity")]			
	public class MyListActivity : Activity, AbsListView.IMultiChoiceModeListener {

		private ListView _listView;
		private ActionMode _actionMode;

		private IList<int> _checkedPositions;

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			this.SetContentView(Resource.Layout.activity_list);
			this._listView = this.FindViewById<ListView>(Resource.Id.activity_list_listview);
			var countries = this.Resources.GetStringArray(Resource.Array.country);
			var adapter = new ArrayAdapter<string>(this, Resource.Layout.activity_list_listview_item, Resource.Id.activity_list_listview_item_textview, countries);
			this._listView.Adapter = adapter;
			this._listView.ChoiceMode = ChoiceMode.Multiple;
			this._listView.ItemClick += OnListViewItemClick;
			this._listView.SetMultiChoiceModeListener(this);
			this._checkedPositions = new List<int>();
		}

		void OnListViewItemClick (object sender, AdapterView.ItemClickEventArgs e) {
			//var checkState = this._listView.IsItemChecked(e.Position);
			//this._listView.SetItemChecked(e.Position, !checkState);
		}

		public override bool OnCreateOptionsMenu(IMenu menu) {
			this.MenuInflater.Inflate(Resource.Menu.activity_list, menu);
			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item) {
			switch (item.ItemId) {
				case Resource.Id.activity_list_action1:
					this.StartActionMode();
					return true;
				case Resource.Id.activity_list_action2:
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}

		private void StartActionMode() {
			if (this._actionMode == null) {
				this._actionMode = this._listView.StartActionMode(this);
			}
		}

		#region IMultiChoiceModeListener implementation
		public void OnItemCheckedStateChanged(ActionMode mode, int position, long id, bool isChecked) {
			if (isChecked) {
				this._checkedPositions.Add(position);
			}
			else {
				this._checkedPositions.Remove(position);
			}
		}
		#endregion

		AbsListViewChoiceMode _choiceMode;

		#region ICallback implementation
		public bool OnActionItemClicked(ActionMode mode, IMenuItem item) {
			return true;
		}

		public bool OnCreateActionMode(ActionMode mode, IMenu menu) {
			mode.SetTitle(Resource.String.activity_list_context_mode_title);
			mode.MenuInflater.Inflate(Resource.Menu.activity_list_context, menu);
			return true;
		}

		public void OnDestroyActionMode(ActionMode mode) {
			this.ClearSelections();
			//this._listView.ChoiceMode = ChoiceMode.Single;
			this._actionMode = null;
		}

		public bool OnPrepareActionMode(ActionMode mode, IMenu menu) {
			this._listView.ChoiceMode = (ChoiceMode)AbsListViewChoiceMode.MultipleModal;
			return true;
		}
		#endregion

		private void ClearSelections() {
			foreach (var item in _checkedPositions) {
				this._listView.SetItemChecked(item, false);
			}
			this._listView.RequestLayout();
		}
	}
}

