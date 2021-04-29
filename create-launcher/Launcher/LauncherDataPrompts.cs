using System;
using McMaster.Extensions.CommandLineUtils;

namespace create_launcher.Launcher
{
    public static class LauncherDataPrompts
    {
        public static LauncherData GetLauncherDataInteractively()
        {
            var name = NullCheck(Prompt.GetString("Launcher display name (required):"));
            var command = NullCheck(Prompt.GetString("Command to run when clicking the launcher (required):"));
            var icon = Prompt.GetString("Path to launcher icon:");
            var proceed = Prompt.GetYesNo("Do you want to add advanced options?", false);

            if (!proceed)
            {
                return new LauncherData
                {
                    Name = name,
                    Comment = null,
                    Exec = command,
                    Icon = icon,
                    Terminal = false,
                    Type = "Application",
                    Categories = new []{"Application"}
                };
            }

            var terminal = Prompt.GetYesNo("Should this run in a terminal?", false);
            var type = Prompt.GetString("Launcher type:");
            var categories = Prompt.GetString("Launcher categories (comma-separated):")?.Split(",");
            var comment = Prompt.GetString("Launcher description:");

            return new LauncherData
            {
                Name = name,
                Comment = comment,
                Exec = command,
                Icon = icon,
                Terminal = terminal,
                Type = type ?? "Application",
                Categories = categories
            };
        }

        private static string NullCheck(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("This value cannot be null, exiting.");
                Environment.Exit(-1);
            }
            return value;
        }
    }
}