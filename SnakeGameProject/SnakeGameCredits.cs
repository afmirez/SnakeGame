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

    public static class SnakeGameCredits
    {
        private static string projectDirectory;
        private static GameCredits? gameCredits;

        static SnakeGameCredits()
        {
            projectDirectory = GetProjectDirectory();
        }
        
        private static string GetProjectDirectory()
        {
            var pd = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent;
            return pd?.FullName ?? string.Empty;
        }
        
        public static void ShowCredits()
        {
            bool sucess = CreditsBuildier();
            if (sucess)
            {
                Type type = typeof(GameCredits);
                PropertyInfo[] properties = type.GetProperties();
                Console.Clear();
                SnakeGameVisualRenders.RenderAppBanner();
                Console.WriteLine("\n");

                foreach (PropertyInfo property in properties)
                {
                    string name = property.Name;
                    object? value = property.GetValue(gameCredits);

                    if (value is Dictionary<string, string>)
                    {
                        SnakeGameVisualRenders.SetForeGroundColor(ForeGroundColors.Yellow);
                        SnakeGameVisualRenders.CenterElement($"{name}".ToUpperInvariant());
                        SnakeGameVisualRenders.ResetForeGroundColor();
                        HandleCreditDictionary((Dictionary<string, string>)value);
                        SnakeGameVisualRenders.RenderExitSpacebar();
                    }
                    else
                    {
                        string n = Regex.Replace(name, "(?<!^)([A-Z])", " $1").ToUpper();
                        SnakeGameVisualRenders.SetForeGroundColor(ForeGroundColors.Yellow);
                        ; SnakeGameVisualRenders.CenterElement($"{n}");
                        SnakeGameVisualRenders.ResetForeGroundColor();
                        SnakeGameVisualRenders.CenterElement($"{value}\n");
                    }
                }
            }
            ExitCredits();
        }
        
        private static bool CreditsBuildier()
        {
            try
            {
                string jsonString = File.ReadAllText($"{projectDirectory}/credits.json");
                GameCredits? deserializedData = JsonSerializer.Deserialize<GameCredits?>(jsonString);
                if (deserializedData == null)
                {
                    Console.Clear();
                    SnakeGameVisualRenders.RenderAppBanner();
                    SnakeGameVisualRenders.RenderExitSpacebar();
                    Console.WriteLine($"\n\x1b[91mError retreving procesing credits data\x1b[39m");
                    return false;
                }
                gameCredits = deserializedData;
                return true;
            }
            catch (Exception e)
            {
                Console.Clear();
                SnakeGameVisualRenders.RenderAppBanner();
                SnakeGameVisualRenders.RenderExitSpacebar();
                Console.WriteLine($"\n\x1b[91mError retreving credits data: {e.Message}\x1b[39m");
                return false;
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
    }
}