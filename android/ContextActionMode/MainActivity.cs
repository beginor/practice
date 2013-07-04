
using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Cn.Beginor.ContextActionMode {

	[Activity (Label = "@string/app_name", MainLauncher = true, Theme = "@android:style/Theme.Holo")]
	public class MainActivity : Activity, ActionMode.ICallback, View.IOnLongClickListener {

		ActionMode _actionMode;

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.activity_main);
			var textView = this.FindViewById<TextView>(Resource.Id.activity_main_hello_textview);
			textView.LongClickable = true;
			textView.SetOnLongClickListener(this);
		}

		#region IOnLongClickListener implementation
		bool View.IOnLongClickListener.OnLongClick(View v) {
			return StartActionMode();
		}
		#endregion

		bool StartActionMode() {
			if (this._actionMode != null) {
				return false;
			}
			this._actionMode = this.StartActionMode(this);
			return true;
		}

		#region ICallback implementation
		bool ActionMode.ICallback.OnActionItemClicked(ActionMode mode, IMenuItem item) {
			switch (item.ItemId) {
				case Resource.Id.activity_main_context_action1:
					Toast.MakeText(this.BaseContext, "Context Action1 Selected", ToastLength.Short).Show();
					this._actionMode.Finish();
					break;
				case Resource.Id.activity_main_context_action2:
					Toast.MakeText(this.BaseContext, "Context Action2 Selected", ToastLength.Short).Show();
					break;
				case Resource.Id.activity_main_context_action3:
					Toast.MakeText(this.BaseContext, "Context Action3 Selected", ToastLength.Short).Show();
					break;
			}
			return false;
		}

		bool ActionMode.ICallback.OnCreateActionMode(ActionMode mode, IMenu menu) {
			mode.SetTitle(Resource.String.activity_main_context_mode_title);
			this.MenuInflater.Inflate(Resource.Menu.activity_main_context, menu);
			return true;
		}

		void ActionMode.ICallback.OnDestroyActionMode(ActionMode mode) {
			this._actionMode = null;
		}

		bool ActionMode.ICallback.OnPrepareActionMode(ActionMode mode, IMenu menu) {
			return false;
		}
		#endregion

		public override bool OnCreateOptionsMenu(IMenu menu) {
			this.MenuInflater.Inflate(Resource.Menu.activity_main, menu);
			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item) {
			switch (item.ItemId) {
				case Resource.Id.activity_main_action1:
					this.StartActionMode();
					return true;
				case Resource.Id.activity_main_action2:
					this.StartActivity(typeof(MyListActivity));
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}

		}
	}
}


