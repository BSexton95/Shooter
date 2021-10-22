using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Bullets : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Vector2 _position;
        private Player _player;
        private Vector2 _bulletDirection;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Bullets(char icon, Vector2 position, Vector2 bulletDirection, Color color, float speed, string name = "Bullet") 
            : base(icon, position, color, name)
        {
            _bulletDirection = bulletDirection;
            _speed = speed;
        }

        public override void Update(float deltaTime, Scene currentScene)
        {

            Position += _bulletDirection.Normalized * Speed * deltaTime;;

            base.Update(deltaTime, currentScene);
        }

        public override void Draw()
        {
            Raylib.DrawText(Icon.Symbol.ToString(), (int)Position.X, (int)Position.Y, 50, Icon.Color);
            base.Draw();
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Enemy)
                Engine.CloseApplication();
        }
    }
}
