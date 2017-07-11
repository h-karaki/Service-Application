using System;
using System.Collections.Generic;
using System.IO;
using ServiceApplication.Interfaces;

namespace ServiceApplication.Modules
{
    class FileInputData : IReadData
    {
        List<string> _data;
        string[] _temp;

        public List<string> ReadDataFromFileSource(string fileSourceName)
        {
            try
            {
                _temp = File.ReadAllLines(fileSourceName);
                _data = new List<string>();
                foreach (string x in _temp)
                {
                    _data.Add(x);
                }
                return _data;
            }
            catch(Exception e)
            {
                Logger.PrintToLog("Exception Thrown in FileInputData Class:");
                Logger.PrintToLog(e.Message);
                throw;
            }
   
        }
    }
}
