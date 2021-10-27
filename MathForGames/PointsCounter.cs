using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class PointsCounter : UIText
    {
        public Bullets _bullets;
        public Player _player;

        public PointsCounter(float x, float y, Bullets bullets, Color color, string name)
            : base(x, y, color, name)
        {
            _bullets = bullets;
            Text = "Points: " + 
        }
    }
}
