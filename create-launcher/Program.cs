﻿using McMaster.Extensions.CommandLineUtils;

namespace create_launcher
{
    [HelpOption("-h")]
    class Program
    {
        static void Main(string[] args) => CommandLineApplication.Execute<Program>(args);
        
        [Argument(0, Description = "Command to run when clicking the launcher")]
        private string LauncherName { get; }
        
        [Argument(1, Description = "Command to run when clicking the launcher")]
        private string LaunchCommand { get; }
        
        [Option("-i|--image", Description = "Launcher icon")]
        private string ImagePath { get; }

        [Option("-p|--path", Description = "Path to created launcher. Defaults to /usr/share/application")]
        private string LauncherPath { get; } = "/usr/share/application";
        
        [Option("-c|--comment", Description = "Launcher comment")]
        private string Comment { get; }

        [Option("-t|--terminal", "Run command in terminal", CommandOptionType.NoValue)]
        private bool Terminal { get; } = false;

        [Option("--type", Description = "Launcher type")]
        private string Type { get; } = "Application";

        [Option("--categories", "Launcher categories", CommandOptionType.MultipleValue)]
        private string[] Categories { get; } = {"Application"};

        private void OnExecute()
        {
            var data = new LauncherData
            {
                Name = LauncherName,
                Comment = Comment,
                Exec = LaunchCommand,
                Icon = ImagePath,
                Terminal = Terminal,
                Type = Type,
                Categories = Categories
            };
            
            LauncherWriter.WriteToFile(LauncherPath, data);
        }
    }
}