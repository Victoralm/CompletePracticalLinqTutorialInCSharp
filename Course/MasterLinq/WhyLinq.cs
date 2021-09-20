using System;
using System.IO;
using System.Linq;
using Course.MasterLinq;

namespace MasterLinq
{
    class WhyLinq
    {
        /// <summary>
        /// Main static method of the class
        /// </summary>
        public static void Demo()
        {
            var location = Path.Combine(Directory.GetCurrentDirectory(), "../ChessStats/");

            System.Console.WriteLine("Without Linq:");
            DisplayLargestStatFileWithoutLinq(location);

            System.Console.WriteLine("With Linq:");
            DisplayLargestStatFileWithLinq(location);
        }

        /// <summary>
        /// The 5 largest files of a given folder
        /// </summary>
        /// <param name="path">String path of a given folder</param>
        private static void DisplayLargestStatFileWithLinq(string path)
        {
            try
            {
                new DirectoryInfo(path).GetFiles()
                    // .Where(file => file.LastWriteTime < DateTime.Now)
                    // From LinqExtensions class
                    .Filter(file => file.LastWriteTime < DateTime.Now)
                    .OrderBy(file => file.Length)
                    .Take(5)
                    // From LinqExtensions class
                    .ForEach(file => Console.WriteLine($"{file.Name} weights {file.Length}"));

                // foreach (var file in files)
                // {
                //     System.Console.WriteLine($"{file.Name} weights {file.Length}");
                // }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// The 5 largest files of a given folder
        /// </summary>
        /// <param name="path">String path of a given folder</param>
        private static void DisplayLargestStatFileWithoutLinq(string path)
        {
            try
            {
                var dirInfo = new DirectoryInfo(path);
                FileInfo[] files = dirInfo.GetFiles();
                Array.Sort(files, (x, y) =>
                {
                    if (x.Length == y.Length)
                        return 0;
                    if (x.Length > y.Length)
                        return 1;
                    return -1;
                });

                // for (int i = 0; i < 5; i++)
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo file = files[i];
                    System.Console.WriteLine($"{file.Name} weights {file.Length}");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
