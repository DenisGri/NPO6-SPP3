using System;
using System.Collections.Generic;
using AssemblyBrowserLib.Data;

namespace AssemblyBrowserLib
{
    public interface IAssemblyBrowser
    {
        List<DataContainer> GetAssemblyInfo(string filePath);

        List<DataContainer> GetAssemblyContainersMock(string filePath);


    }
}