using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class PointsCounter : UIText
    {
        public Bullets _bullets;

        public PointsCounter(float x, float y, Bullets bullets, Color color, string name)
            : base(x, y, color, name)
        {
            _bullets = bullets;
            Text = "Points: " + bullets.Points.ToString();
        }

        public override void Update(float deltaTime, Scene currentScene)
        {
            base.Update(deltaTime, currentScene);

            UIText tempPoints = new UIText(20, 20, Color.VIOLET, "Points", "Points = 0");
            currentScene.AddUIElement(tempPoints);

            Text = "Points: " + _bullets.Points.ToString();
        }
    }
}
