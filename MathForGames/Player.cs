﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Player : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Bullets _bullet;
        private Scene _scene;
        private int _lives = 3;
        
        

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

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        

        public Player() { }

        public Player(char icon, float x, float y, float speed, Color color, string name = "Actor")
            : base(icon, x, y, color, name)
        {
            _speed = speed;
        }

        public override void Update(float deltaTime, Scene currentScene)
        {
            UIText tempPoints = new UIText(20, 20, Color.VIOLET, "Points", "Points = 0");
            currentScene.AddUIElement(tempPoints);

            //Get the player input direction
            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));
            int yDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
                _speed = 150;
            else
                _speed = 100;

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                Bullets bullet = new Bullets('.', Position, Forward, Color.BLACK, 150, "Bullet");
                CircleCollider bulletCollider = new CircleCollider(10, bullet);
                bullet.Collider = bulletCollider;

                PointsCounter points = new PointsCounter(20, 20, bullet, Color.VIOLET, "Bullets");
                currentScene.UpdateUI(deltaTime, points);
                currentScene.AddUIElement(points);
                currentScene.AddActor(bullet);
            }
            

            if (xDirection != 0 || yDirection != 0)
            {
                //Create a vector that stores the move input
                Vector2 moveDirection = new Vector2(xDirection, yDirection);

                Velocity = moveDirection.Normalized * Speed * deltaTime;

                Position += Velocity;

                Forward = moveDirection;
            }
            //Prints players position
            base.Update(deltaTime, currentScene);

        }

        public override void OnCollision(Actor actor, Scene scene)
        {
            

            if (actor is Enemy)
            {
                Position = new Vector2(20, 20);
                Lives--;
            }

           
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
