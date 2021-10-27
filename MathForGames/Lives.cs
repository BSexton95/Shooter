using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class Lives : UIText
    {
        public Player _player;

        public Lives(float x, float y, Color color, Player player, string name)
            : base(x, y, color, name)
        {
            _player = player;
            Text = "Lives: " + player.Lives.ToString();
        }

        public override void Update(float deltaTime, Scene currentScene)
        {
            base.Update(deltaTime, currentScene);

            Text = "Lives: " + _player.Lives.ToString();
        }
    }
}
