using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    internal class GameContext
    {
        private ILevel _currentLevel;
        // Manejar el tiempo sobrevivido en propiedad
        // La snake
        // El Mapa en si que debe ser maleable lol
        // la comida
        // EL PLAYER  --> maz score
        // CURRENT SCORE esto es de aca interno

        // ver de todo esto que voy a recibir desde afuear y definirlo en el constructoir
        // o inizilizarlo todo manualmente

             public void SetLevel(ILevel newLevel)
                {
                    //currentLevel = newLevel;
                    //currentLevel.EnterLevel(this);
                }

        //public void Update()
        //{
        //    _currentLevel.Update(this);  // Actualiza el nivel actual
        //}



        // En el con

        //public GameContext(ILevel level)
        //{
        //    _currentLevel = level;
        //}
        //public void StartGame()
        //{
        //    _currentLevel.StartLevel();
        //}
        //public void UpdateGame()
        //{
        //    _currentLevel.UpdateLevel();
        //}
        //public void EndGame()
        //{
        //    _currentLevel.EndLevel();
        //}
    }
}
