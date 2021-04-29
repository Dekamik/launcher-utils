namespace create_launcher.Launcher
            
{
    public class LauncherData
    {
        public static string Version => "1.0";

        public string Name { get; init; }
        
        public string Comment { get; init; }
        
        public string Exec { get; init; }
        
        public string Icon { get; init; }

        public bool Terminal { get; init; }

        public static string Type => "Application";

        public string[] Categories { get; init; }
    }
}