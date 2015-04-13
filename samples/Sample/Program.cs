using System;
using System.Collections.Generic;
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
        
    }
}