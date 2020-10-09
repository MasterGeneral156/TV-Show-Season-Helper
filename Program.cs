/*
The MIT License (MIT)
Copyright © 2020 MasterGeneral156

Permission is hereby granted, free of charge, to any person 
obtaining a copy of this software and associated documentation 
files (the “Software”), to deal in the Software without 
restriction, including without limitation the rights to use, 
copy, modify, merge, publish, distribute, sublicense, and/or 
sell copies of the Software, and to permit persons to whom the 
Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be 
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TV_Show_Season_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get the app's current directory
            string currentDir = Directory.GetCurrentDirectory();

            Console.WriteLine("TV Show Season Sorter!! Version 1.0.0");
            Console.WriteLine("====================================================");
            Console.WriteLine("Loading the MKVs...");
            Console.WriteLine("Working directory: " + currentDir);
            try
            {
                var txtFiles = Directory.EnumerateFiles(currentDir, "*.mkv", SearchOption.TopDirectoryOnly);
                foreach (string currentFile in txtFiles)
                {
                    var fileName = Path.GetFileName(currentFile);
                    Console.WriteLine("Detected " + currentFile + ".");
                    Console.WriteLine("What season does this video belong to?");
                    string seasonNumber = Console.ReadLine().Trim();
                    string newDir = currentDir + "\\Season " + seasonNumber + "\\";
                    if (!Directory.Exists(newDir))
                        System.IO.Directory.CreateDirectory(newDir);
                    string newFile = newDir + fileName;
                    File.Copy(currentFile, newFile, true);
                    File.Delete(currentFile);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            System.Threading.Thread.Sleep(1000);
        }
    }
}
