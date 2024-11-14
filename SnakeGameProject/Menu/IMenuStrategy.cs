using System;
using System.Collections.Generic;

namespace SnakeGameProject
{
    public interface IMenuStrategy
    {
        void ExecuteOptions(int optionSelected = -1);
    }
}
