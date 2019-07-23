using FormsUI;
using FormsUI.Workspaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.IDE.DocumentModel
{
    [WorkspaceModelVersion(1, 0)]
    public class Project : PropertyChangedNotifier, IWorkspaceModel
    {
        private readonly ObservableCollection<CodeItem> codes = new ObservableCollection<CodeItem>();
        private readonly ObservableCollection<CommandItem> commands = new ObservableCollection<CommandItem>();

        private string author;

        public Project()
        {
            BindObservableCollection(codes);
            BindObservableCollection(commands);
        }

        public WorkspaceModelVersion Version { get; set; }

        public ICollection<CodeItem> Codes => codes;

        public ICollection<CommandItem> Commands => commands;

        public string Author
        {
            get => author;
            set
            {
                if (author != value)
                {
                    author = value;
                    OnPropertyChanged(nameof(Author));
                }
            }
        }
    }
}
