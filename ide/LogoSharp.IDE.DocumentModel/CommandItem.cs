using FormsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.IDE.DocumentModel
{
    public class CommandItem : PropertyChangedNotifier
    {
        private string commandLine;

        public string CommandLine
        {
            get => commandLine;
            set
            {
                if (commandLine != value)
                {
                    commandLine = value;
                    OnPropertyChanged(nameof(CommandLine));
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is CommandItem item &&
                   CommandLine == item.CommandLine;
        }

        public override int GetHashCode()
        {
            return -761075104 + EqualityComparer<string>.Default.GetHashCode(CommandLine);
        }
    }
}
