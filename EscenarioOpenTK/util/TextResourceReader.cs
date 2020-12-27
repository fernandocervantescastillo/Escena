using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EscenarioOpenTK.util
{
    class TextResourceReader
    {
        public static String readTextFileFromResource(String fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
            return streamReader.ReadToEnd();
        }
    }
}
