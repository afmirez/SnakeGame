using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public interface ILevel
    {
        string Name { get; }
        void StartLevel();
        void EndLevel();
        void FinishLevel(); 
    }
}
