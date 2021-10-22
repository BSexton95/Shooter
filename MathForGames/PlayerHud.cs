using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class PlayerHud : Actor
    {
        private Player _player;
        private UIText _lives;
        private UIText _points;

        public PlayerHud(Player player, UIText lives, UIText points)
        {
            _player = player;
            _lives = lives;
            _points = points;
        }

        public override void Start()
        {
            base.Start();
            _lives.Start();
            _points.Start();
        }

        public override void Update(float deltaTime, Scene currentScene)
        {
            _lives.Text = "Lives: " + _player.Lives.ToString();
            _points.Text = "Points: " + _player.Points.ToString();
        }

        public override void Draw()
        {
            _lives.Draw();
            _points.Draw();
        }
    }
}
