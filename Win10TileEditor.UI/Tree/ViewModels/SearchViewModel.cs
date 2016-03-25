using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Win10TileEditor.Tree.Interaction;

namespace Win10TileEditor.Tree.ViewModels
{
    public class SearchViewModel : BindableBase
    {
        private readonly ICommand storeInPreviousCommand;

        private ObservableCollection<SearchTreeItem> roots = new ObservableCollection<SearchTreeItem>();
        private ObservableCollection<string> previousCriteria = new ObservableCollection<string>();
        private string selectedCriteria = String.Empty;
        private string currentCriteria = String.Empty;

        [Obsolete]
        public SearchViewModel(IEnumerable<SearchTreeItem> roots) {
            foreach (var node in roots)
                this.roots.Add(node);

            storeInPreviousCommand = new Command(StoreInPrevious);
        }

        public SearchViewModel()
        {
            storeInPreviousCommand = new Command(StoreInPrevious);
        }
        
        private void StoreInPrevious(object dummy) {
            if (String.IsNullOrEmpty(CurrentCriteria))
                return;

            if (!previousCriteria.Contains(CurrentCriteria))
                previousCriteria.Add(CurrentCriteria);

            SelectedCriteria = CurrentCriteria;
        }

        /// <summary>
        /// Gives the <see cref="CurrentCriteria"/> to all root nodes using SearchTreeItem.ApplyCriteria() or RemoveCriteria() if CurrentCriteria is null or empty
        /// </summary>
        private void ApplyFilter() {
            if(String.IsNullOrEmpty(CurrentCriteria))
                foreach (SearchTreeItem node in roots)
                    node.RemoveCriteria(new Stack<SearchTreeItem>());
            else
                foreach (SearchTreeItem node in roots)
                    node.ApplyCriteria(CurrentCriteria.ToLower(), new Stack<SearchTreeItem>());
        }

        public ICommand StoreInPreviousCommand {
            get { return storeInPreviousCommand; }
        }

        public ObservableCollection<SearchTreeItem> Roots {
            get { return roots; }
            set { this.SetProperty(ref roots, value, "Roots"); }
        }
        
        public ObservableCollection<string> PreviousCriteria {
            get { return previousCriteria; }
        }

        public string SelectedCriteria {
            get { return selectedCriteria; }
            set {
                if (value == selectedCriteria)
                    return;

                selectedCriteria = value;
                OnPropertyChanged("SelectedCriteria");
            }
        }

        public string CurrentCriteria {
            get { return currentCriteria; }
            set {
                if (value == currentCriteria)
                    return;

                currentCriteria = value;
                OnPropertyChanged("CurrentCriteria");
                ApplyFilter();                
            }
        }
    }
}
