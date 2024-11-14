using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class GameCredits
    {
        public string? gameTitle { get; set; }
        public string? gameVersion { get; set; }
        public string? year { get; set; }
        public Dictionary<string, string>? credits { get; set; }
    }
}