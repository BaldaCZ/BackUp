using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Backup_Client
{
    class Backup_Diff
    {
        public static void CopyDirectory(string source, string target, int kdy) //kdy je poslední full
        {
            if (Directory.Exists(source))
            {
                if (Directory.Exists(target))
                {
                    var stack = new Stack<Folders>();
            stack.Push(new Folders(source, target));

            while (stack.Count > 0)
            {
                var folders = stack.Pop();
                Directory.CreateDirectory(folders.Target);
                foreach (var file in Directory.GetFiles(folders.Source, "*.*"))
                {
                  
                        if (DateTime.Compare(File.GetLastWriteTime(Path.GetFullPath(file)), DateTime.Today.AddDays(-kdy)) > 0) // porovná datum od kdy do teď
                        {
                            File.Copy(file, Path.Combine(folders.Target, Path.GetFileName(file)));
                        }
                   
                }
                foreach (var folder in Directory.GetDirectories(folders.Source))
                {
                    
                        if (DateTime.Compare(File.GetLastWriteTime(Path.GetFullPath(folder)), DateTime.Today.AddDays(-kdy)) > 0)
                        {
                            stack.Push(new Folders(folder, Path.Combine(folders.Target, Path.GetFileName(folder))));
                        }
                }
            }
                }
                else
                {
                    Directory.CreateDirectory(target);
                    CopyDirectory(source, target, kdy);

                }
            }

            else
            {
                //SEND MAIL CANNOT BACKUP SOURCE BAD
            }
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
}
