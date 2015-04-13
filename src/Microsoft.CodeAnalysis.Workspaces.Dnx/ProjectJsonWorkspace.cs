using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.Text;
using Microsoft.Framework.Runtime;
using Microsoft.Framework.Runtime.Compilation;
using Microsoft.Framework.Runtime.Caching;
using DnxProject = Microsoft.Framework.Runtime.Project;

namespace Microsoft.CodeAnalysis.Workspaces.Dnx
{
    public class ProjectJsonWorkspace : Workspace
    {
        private readonly string[] _projectPaths;

        public ProjectJsonWorkspace(string projectPath) : this(new[] { projectPath })
        {
        }

        public ProjectJsonWorkspace(string[] projectPaths) : base(MefHostServices.DefaultHost, "Custom")
        {
            _projectPaths = projectPaths;

            Initialize();
        }

        private void Initialize()
        {
            foreach(var projectPath in _projectPaths)
            {
                var model = ProjectModel.GetModel(projectPath);
            }

            /*foreach (var p in model.Projects)
            {
                Console.WriteLine(p.Project.Name + "+" + p.Framework);

                foreach (var reference in p.DependencyInfo.References)
                {
                    Console.WriteLine(reference);
                }

                foreach (var reference in p.DependencyInfo.ProjectReferences)
                {
                    Do(reference.Path);
                }
            }*/
        }
    }
}