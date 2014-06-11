using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace CandySearch {

    partial class CandyTableViewController : UITableViewController, IUISearchBarDelegate {

        private IList<Candy> candies;
        private IList<Candy> filteredCandies;

        public CandyTableViewController(IntPtr handle) : base(handle) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            TableView.SetContentOffset(new PointF(0f, SearchBar.Bounds.Height), false);

            candies = Candy.DefaultList();
            filteredCandies = new List<Candy>();
        }

        public override int RowsInSection(UITableView tableview, int section) {
            return tableview == searchDisplayController.SearchResultsTableView ? filteredCandies.Count : candies.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
            var cellId = "CandyCell";
            var cell = tableView.DequeueReusableCell(cellId);
            if (cell == null) {
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellId) {
                    Accessory = UITableViewCellAccessory.DisclosureIndicator
                };
            }
            var candy = tableView == searchDisplayController.SearchResultsTableView ? filteredCandies[indexPath.Row] : candies[indexPath.Row];
            cell.TextLabel.Text = candy.Name;
            return cell;
        }

        private void FilterContent(string searchText, string scope) {
            IEnumerable<Candy> query =candies;
            if (!string.IsNullOrEmpty(searchText)) {
                query = query.Where(c => c.Name.Contains(searchText));
            }
                var category = scope.ToLower();
            if (category != "all") {
                query = query.Where(c => c.Category == category);
            }
            filteredCandies = query.ToList();
        }

        [Export("searchDisplayController:shouldReloadTableForSearchString:")]
        public virtual bool ShouldReloadForSearchString(UISearchDisplayController controller, string searchText) {
            FilterContent(searchText, controller.SearchBar.ScopeButtonTitles[controller.SearchBar.SelectedScopeButtonIndex]);
            return true;
        }

        [Export("searchDisplayController:shouldReloadTableForSearchScope:")]
        public virtual bool ShouldReloadForSearchScope(UISearchDisplayController controller, int searchOption) {
            FilterContent(controller.SearchBar.Text, controller.SearchBar.ScopeButtonTitles[searchOption]);
            return true;
        }

        partial void GoToSearch(UIBarButtonItem sender) {
            TableView.SetContentOffset(new PointF(0f, 0f), true);
            SearchBar.BecomeFirstResponder();
        }
    }
}
