using System;
using System.IO;

namespace org.appstreams
{
    public static class Utility
    {
        public static string ReadFromFile(string path)
        {
            string fileSample = "./metadata/services/" + path;
            if (System.IO.File.Exists(fileSample))
            {
                using (StreamReader r = new StreamReader(fileSample))
                {
                    return r.ReadToEnd();
                }
            }

            return String.Empty;
        }
    }
}
