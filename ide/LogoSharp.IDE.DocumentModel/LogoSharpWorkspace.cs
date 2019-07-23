using FormsUI.Workspaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogoSharp.IDE.DocumentModel
{
    public sealed class LogoSharpWorkspace : Workspace
    {
        protected override string WorkspaceFileDescription => "LogoSharp Project File";

        protected override string WorkspaceFileExtension => "logosharp";

        protected override string OpenDialogTitle => "Open LogoSharp Project";

        protected override string SaveDialogTitle => "Save LogoSharp Project";

        protected override IWorkspaceModel Create() => new Project();

        protected override IWorkspaceModel OpenFromFile(string fileName)
        {
            var xmlSerializer = new XmlSerializer(typeof(Project));
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var project = (Project)xmlSerializer.Deserialize(fs);
                return project;
            }
        }

        protected override void SaveToFile(IWorkspaceModel model, string fileName)
        {
            var xmlSerializer = new XmlSerializer(typeof(Project));
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fs, model);
            }
        }
    }
}
