using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class Player
    {
        private string _id;
        private string _name;
        public int MaxScore {  get; private set; }
        public Player(string name)
        {
            _name = name;
            _id = Guid.NewGuid().ToString();
        }
        public string GetName() { return _name; }
        public string GetId() { return _id; }
        public bool UpdateMaxScore (int newMaxScore)
        {
            if (newMaxScore > MaxScore)
            {
                MaxScore = newMaxScore; 
                return true;
            }
            return false;
        }
    }
}
