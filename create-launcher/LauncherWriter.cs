using System.Collections.Generic;
using System.IO;

namespace create_launcher
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
            lines.AddLine("Terminal", data.Terminal.ToString());
            lines.AddLine("Type", data.Type);
            lines.AddLine("Categories", data.Categories);
            
            File.WriteAllLines(path, lines);
        }

        private static void AddLine(this ICollection<string> collection, string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                collection.Add($"{name}={value}");
            }
        }
        
        private static void AddLine(this ICollection<string> collection, string name, string[] values)
        {
            if (values.Length != 0)
            {
                collection.Add($"{name}={string.Join(";", values)}");
            }
        }
    }
}