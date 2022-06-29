using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace index.html
{
    class Program
    {
        static List<string> codeLines = new List<string>();
        static string filename = "code";
        static int line = 1;

        static int pointer = 0;
        static List<int> ints = new List<int>();

        static string printed = "";

        static void Main(string[] args)
        {
            TextReader tr = new StreamReader(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\" + @filename + ".indexx");

            for (int i = 0; i < 30000; i++) {
                ints.Add(0);
            }

            string code = tr.ReadLine();
            while (code != null)
            {
                codeLines.Add(code);
                code = tr.ReadLine();
            }
            while (line <= codeLines.Count)
            {
                string contents = "fortnite battle pass";
                using (WebClient client = new WebClient())
                {
                    contents = client.DownloadString(codeLines[line-1] + "/index.html");
                }
                int lines = contents.Split('\n').Length;

                Console.WriteLine(lines);

                while (lines > 10) {
                    lines -= 10;
                }

                switch (lines)
                {
                    case 1:
                        Console.Write(Encoding.ASCII.GetString(new byte[] { (byte)ints[pointer] }));
                        printed += Encoding.ASCII.GetString(new byte[] { (byte)ints[pointer] });
                        break;
                    case 2:
                        if (pointer > 0)
                        {
                            pointer -= 1;
                        }
                        break;
                    case 3:
                        pointer += 1;
                        break;
                    case 4:
                        ints[pointer] -= 1;
                        if (ints[pointer] < 0)
                        {
                            ints[pointer] = 255;
                        }
                        break;
                    case 5:
                        ints[pointer] += 1;
                        if (ints[pointer] > 255)
                        {
                            ints[pointer] = 0;
                        }
                        break;
                    case 6:
                        Console.Write("\n");
                        printed += "  ";
                        break;
                    case 7:
                        Console.Title = printed;
                        printed = "";
                        Console.Clear();
                        break;
                    case 8:
                        ints[pointer] = (int)Console.ReadKey().KeyChar;
                        Console.Write("\n");
                        break;
                    case 9:
                        line = ints[pointer] - 1;
                        break;
                    case 10:
                        if (ints[pointer] == 0)
                        {
                            line += 5;
                        }
                        break;
                }

                line += 1;
            }
        }
    }
}
