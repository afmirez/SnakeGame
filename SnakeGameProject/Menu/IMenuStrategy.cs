using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public interface IMenuStrategy
    {
        void ExecuteOptions(int optionSelected = -1);
    }
}
