using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Enemy : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Actor _target;
        private float _maxViewAngle;
        private float _maxSightDistance;

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Enemy(char icon, float x, float y, Color color, float speed, float maxSightDistance, float maxViewAngle, Actor target, string name)
            : base(icon, x, y, color, name)
        {
            _speed = speed;
            _target = target;
            _maxViewAngle = maxViewAngle;
            _maxSightDistance = maxSightDistance;
        }

        public override void Update(float deltaTime, Scene currentScene)
        {

            Vector2 enemyDistance = (_target.Position - Position).Normalized;

            Velocity = enemyDistance * _speed * deltaTime;

            if (GetTargetInSight())
                Position += Velocity;

            base.Update(deltaTime, currentScene);
        }

        public bool GetTargetInSight()
        {
            Vector2 directionOfTarget = (_target.Position - Position).Normalized;
            float distanceToTarget = Vector2.Distance(_target.Position, Position);

            float dotProduct = Vector2.DotProduct(directionOfTarget, Forward);

            return Math.Acos(dotProduct) < _maxViewAngle && distanceToTarget < _maxSightDistance;
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }

    }
}
