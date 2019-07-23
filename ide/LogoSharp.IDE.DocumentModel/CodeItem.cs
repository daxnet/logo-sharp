using FormsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoSharp.IDE.DocumentModel
{
    public class CodeItem : PropertyChangedNotifier
    {
        private string name;
        private string sourceCode;

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string SourceCode
        {
            get => sourceCode;
            set
            {
                if (sourceCode != value)
                {
                    sourceCode = value;
                    OnPropertyChanged(nameof(SourceCode));
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is CodeItem item &&
                   Name == item.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
