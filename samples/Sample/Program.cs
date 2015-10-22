using System;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis.Workspaces.Dnx;
using Microsoft.Dnx.Runtime;

/// <summary>
/// This is a doc comment
/// </summary>
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

        var program = project.GetCompilationAsync().Result.Assembly.GetTypeByMetadataName("Program");
        Console.WriteLine(program.GetDocumentationCommentXml());
    }
}