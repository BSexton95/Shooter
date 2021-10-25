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
        private int _points;
        

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

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public Player() { }

        public Player(char icon, float x, float y, float speed, Color color, string name = "Actor")
            : base(icon, x, y, color, name)
        {
            _speed = speed;
        }

        public override void Update(float deltaTime, Scene currentScene)
        {
            

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
                scene.RemoveActor(this);
                Lives--;
                UIText lives = new UIText(10, 10, Color.BLUE, "Lives", 50, 50, 10, "Lives = " + Lives);
                scene.AddUIElement(lives);
            }
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
