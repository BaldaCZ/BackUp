using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Backup_Client
{
    class Backup_Full
    {
        public static void CopyDirectory(string source, string target)
        {
            if (Directory.Exists(source))
            {
                if (Directory.Exists(target))
                {
                    DeleteDirectory(target);
                    Directory.CreateDirectory(target);
                        var stack = new Stack<Folders>();
                        stack.Push(new Folders(source, target));

            while (stack.Count > 0) //dokud ve staku sou soubory
            {
                var folders = stack.Pop();
                Directory.CreateDirectory(folders.Target);
                foreach (var file in Directory.GetFiles(folders.Source, "*.*")) //pro každý "vrchní" soubor
                {
                    // dodělat, pokud tam už je tak přepsat
                         File.Copy(file, Path.Combine(folders.Target, Path.GetFileName(file))); //kopíruje do targetu
                    
                }

                foreach (var folder in Directory.GetDirectories(folders.Source)) //pro každou složku ve staku
                {
                   
                         stack.Push(new Folders(folder, Path.Combine(folders.Target, Path.GetFileName(folder)))); //hodí do staku soubory a složky ze složky
                    
                }
            }
                }
                else
                {
                    Directory.CreateDirectory(target);
                    CopyDirectory(source, target);
                }
            }

            else
            {
                //SEND MAIL CANNOT BACKUP SOURCE BAD
            }
        }

        public class Folders
        {
            public string Source { get; private set; }
            public string Target { get; private set; }

            public Folders(string source, string target)
            {
                Source = source;
                Target = target;

            }
        }
        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }
    }
        }
        
