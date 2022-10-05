using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyFileClass
{
    public static class FileClass
    {
        private static object _locker = new Object();

        public static void CopyFile(string oldPath, string newPath)
        {
            if (File.Exists(oldPath))
            {
                try
                {
                    var file = new FileInfo(oldPath);

                    file.CopyTo(newPath);
                }
                catch (Exception)
                {
                }
            }
        }

        public static void CopyDirectory(string oldPath, string newPath)
        {
            //Создать идентичную структуру папок
            foreach (string dirPath in Directory.GetDirectories(oldPath, "*",
                SearchOption.AllDirectories))
            {
                try
                {
                    Directory.CreateDirectory(dirPath.Replace(oldPath, newPath));
                }
                catch (Exception e)
                {
                    //здесь обрабатывай ошибки
                }
            }

            //Копировать все файлы и перезаписать файлы с идентичным именем
            foreach (string newPaths in Directory.GetFiles(oldPath, "*.*",
                SearchOption.AllDirectories))
            {
                try
                {
                    File.Copy(newPath, newPath.Replace(oldPath, newPath), true);
                }
                catch (Exception e)
                {
                    //здесь обрабатывай ошибки
                }
            }
        }

        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public static void DeleteFiles(string[] array)
        {
            foreach (var item in array)
            {
                DeleteFile(item);
            }
        }

        public static void DeleteFileOnMask(string path,string mask)
        {
            try
            {
                var a = Directory.GetFiles(path);

                var maskFile = a.Where(x => new FileInfo(x).Name.Contains(mask));

                foreach (var item in maskFile)
                {
                    DeleteFile(item);
                }
            }
            catch (Exception)
            { 
            }
        }

        public static void MoveFile(string oldPath, string newPath)
        {
            if (File.Exists(oldPath))
            {
                var a = new FileInfo(oldPath);

                if (!File.Exists(newPath))
                {
                    a.MoveTo(newPath);
                }
            }
        }

        public static void SearchWord(string pathFile, string searchWord, string pathReport)
        {
            if (File.Exists(pathFile))
            {
                using (StreamReader sr = new StreamReader(pathFile))
                {
                    string buffer = sr.ReadToEnd();

                    string pattern = $@"\b({searchWord}\b)";

                    if (Regex.IsMatch(buffer, pattern, RegexOptions.IgnoreCase))
                    {
                        if (!Directory.Exists(pathReport))
                        {
                            Directory.CreateDirectory(pathReport);
                        }

                        File.Create(Path.Combine(pathReport, $"{new FileInfo(pathFile).Name}Report.txt")).Close();

                        lock (_locker)
                        {
                            using (StreamWriter sw = new StreamWriter(Path.Combine(pathReport, $"{new FileInfo(pathFile).Name}Report.txt")))
                            {
                                sw.WriteLine($"В файле {pathFile} найдено слово {searchWord}");
                            }
                        }
                    }
                    else
                    {
                        if (!Directory.Exists(pathReport))
                        {
                            Directory.CreateDirectory(pathReport);
                        }

                        File.Create(Path.Combine(pathReport, "Report.txt")).Close();

                        using (StreamWriter sw = new StreamWriter(Path.Combine(pathReport, "Report.txt"), true))
                        {
                            sw.WriteLine($"В файле {pathFile} не найдено слово {searchWord}");
                        }
                    }
                }
            }
        }

        public static void SearchWordOnFolder(string pathFolder, string word)
        {
            if (Directory.Exists(pathFolder))
            {
                foreach (var file in Directory.GetFiles(pathFolder).Where(x=>new FileInfo(x).Name.Contains(".txt")))
                {
                    SearchWord(file, word, pathFolder);
                }
            }
        }
    }
}
