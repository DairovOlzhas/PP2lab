using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class Game
    {
        public Snake snake = new Snake();
        public Wall wall = new Wall();
        public Food food = new Food();

        public Game()
        {
            snake = new Snake(1);
            wall = new Wall();
            food = new Food();
        }

        public void Draw()
        {
            snake.Draw();
            wall.Draw();
            food.Draw();

        }
    }
}
