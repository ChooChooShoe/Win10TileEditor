using System;
using System.Collections;
using System.Windows.Forms;

namespace Win10TileEditor
{
	public class FolderItemSorter : IComparer
	{
		private string _mode;
		private SortOrder _order;

		public FolderItemSorter(string mode, SortOrder order)
		{
			_mode = mode;
			_order = order;
		}

		public int Compare(object x, object y)
		{
            BaseViewItem a = x as BaseViewItem;
            BaseViewItem b = y as BaseViewItem;
			int res = 0;

			if (_mode == "Date")
				res = DateTime.Compare(a.Date, b.Date);
			else
				res = string.Compare(a.Name, b.Name);

			if (_order == SortOrder.Descending)
				return -res;
			else
				return res;
		}
	}
}
