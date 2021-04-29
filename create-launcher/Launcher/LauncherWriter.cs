using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace create_launcher.Launcher
{
    public static class LauncherWriter
    {
        public static void WriteToFile(string path, LauncherData data)
        {
            var lines = new List<string> {"[Desktop Entry]"};
            
            lines.AddLine("Version", LauncherData.Version);
            lines.AddLine("Name", data.Name);
            lines.AddLine("Comment", data.Comment);
            lines.AddLine("Exec", data.Exec);
            lines.AddLine("Icon", data.Icon);
            lines.AddLine("Terminal", data.Terminal);
            lines.AddLine("Type", LauncherData.Type);
            lines.AddLine("Categories", data.Categories);
            
            File.WriteAllLines(path, lines);
            
            Exec($"chmod +x {path}");
        }

        private static void AddLine(this ICollection<string> collection, string name, bool value) =>
            collection.Add($"{name}={value.ToString().ToLower()}");
        
        private static void AddLine(this ICollection<string> collection, string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                collection.Add($"{name}={value}");
            }
        }
        
        private static void AddLine(this ICollection<string> collection, string name, string[] values)
        {
            if (values != null && values.Length != 0)
            {
                collection.Add($"{name}={string.Join(";", values)}");
            }
        }

        private static void Exec(string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");
        
            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\""
                }
            };

            process.Start();
            process.WaitForExit();
        }
    }
}