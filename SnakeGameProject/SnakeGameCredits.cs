using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Security.Authentication;
using System.Text.RegularExpressions;

namespace SnakeGameProject
{
    public class GameCreditsModel
    {
        public string? gameTitle { get; set; }
        public string? gameVersion { get; set; }
        public string? year { get; set; }
        public Dictionary<string, string>? credits { get; set; }
    }

    public static class SnakeGameCredits
    {
        // Workaround to get the project directory. Not optimal, refactor:
        private static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private static GameCreditsModel? gameCredits;

        private static void ExitCredits()
        {
            ConsoleKeyInfo selectedKey;
            do
            {
                selectedKey = Console.ReadKey(true);
            }
            while (selectedKey.Key != ConsoleKey.Spacebar);

            if (selectedKey.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                SnakeGameVisualRenders.RenderAppBanner();
            }
        }
        private static void CreditsBuildier()
        {
            try
            {
                string jsonString = File.ReadAllText($"{projectDirectory}/credits.json");
                GameCreditsModel? deserializedData = new GameCreditsModel();
                gameCredits = JsonSerializer.Deserialize<GameCreditsModel>(jsonString);
            }
            catch (Exception e ){
                Console.WriteLine($"Error retreving credits data: {e.Message}\n\n");
                SnakeGameVisualRenders.RenderExitSpacebar();
                Console.ReadLine();
            }
        }

        private static void HandleCreditDictionary (Dictionary<string,string> creditDic)
        {
            int maxKeyLength = 0;
            int maxValueLength = 0;

            foreach (KeyValuePair<string, string> kvp in creditDic)
            {
                int currentKeyLength = kvp.Key.Length;
                int currentValueLength = kvp.Value.Length;
                maxKeyLength = currentKeyLength > maxKeyLength ? currentKeyLength : maxKeyLength;
                maxValueLength = currentValueLength > maxValueLength ? currentValueLength : maxValueLength;
            }

            SnakeGameVisualRenders.CenterCreditElement(creditDic, maxKeyLength, maxValueLength);
            Console.WriteLine("\n\n");
        }

        public static void ShowCredits()
        {
            CreditsBuildier();

            Type type = typeof(GameCreditsModel);
            PropertyInfo[] properties = type.GetProperties();

            Console.Clear();

            SnakeGameVisualRenders.RenderAppBanner();
            Console.WriteLine("\n");
            foreach (PropertyInfo property in properties) {
                string name = property.Name;
                object? value = property.GetValue(gameCredits);

                if (value is Dictionary<string, string>)
                {
                    SnakeGameVisualRenders.SetForeGroundColor(ForeGroundColors.Yellow);
                    SnakeGameVisualRenders.CenterElement($"{name}".ToUpperInvariant());
                    SnakeGameVisualRenders.ResetForeGroundColor();
                    HandleCreditDictionary((Dictionary<string, string>)value);
                    SnakeGameVisualRenders.RenderExitSpacebar();
                } else
                {
                    string n = Regex.Replace(name, "(?<!^)([A-Z])", " $1").ToUpper();
                    SnakeGameVisualRenders.SetForeGroundColor(ForeGroundColors.Yellow);
;                   SnakeGameVisualRenders.CenterElement($"{n}");
                    SnakeGameVisualRenders.ResetForeGroundColor();
                    SnakeGameVisualRenders.CenterElement($"{value}\n");
                }
            }
            ExitCredits();
        }
    }
}