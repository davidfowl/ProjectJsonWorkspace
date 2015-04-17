using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.CodeAnalysis.Workspaces.Dnx;
using Microsoft.Framework.Runtime;


public class Program
{
    private readonly IApplicationEnvironment _appEnv;

    public Program(IApplicationEnvironment appEnv)
    {
        _appEnv = appEnv;
    }

    public void Main()
    {
        Do(_appEnv.ApplicationBasePath);
    }

    private void Do(string path)
    {
        // This is so meta!
        var workspace = new ProjectJsonWorkspace(path);
        var thisDocument = workspace.CurrentSolution.GetDocumentIdsWithFilePath(Path.Combine(path, "Program.cs")).First();
        var project = workspace.CurrentSolution.GetProject(thisDocument.ProjectId);
    }
}