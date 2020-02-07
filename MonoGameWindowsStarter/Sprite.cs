using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameWindowsStarter
{
    public class Sprite
    {
        public BoundaryRectangle bounds;

        Game1 game;

        public Texture2D sprite;

        float jumpHeight;

        bool canJump;

        public float groundLevel;

        public Sprite(Game1 game)
        {
            this.game = game;
        }

        public void Initialize(float width, float height, float x, float y)
        {
            bounds.Width = width;
            bounds.Height = height;
            bounds.X = x;
            bounds.Y = y;
            groundLevel = game.GraphicsDevice.Viewport.Height - bounds.Height;
            jumpHeight = 0;
            canJump = true;
        }

        public void LoadContent(ContentManager cm, string name)
        {
            sprite = cm.Load<Texture2D>(name);
        }

        public void Update(GameTime gameTime)
        {
            float runDirection = 0;
            float jumpDirection = 0;
            
            //run left
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                runDirection -= (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.2);

            }
            //run right
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                runDirection += (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.2);
            }

            //jump
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && jumpHeight < 90 && canJump)
            {
                jumpDirection -= (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.3);
                jumpHeight += 3;
            }
            if (jumpHeight >= 90)
            {
                canJump = false;
            }
            if (!canJump)
            {
                jumpHeight -= 3;
                jumpDirection += (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.3);
            }

            if (bounds.Y >= groundLevel && jumpHeight <= 0)
            {
                canJump = true;
            }

            bounds.X += runDirection;
            bounds.Y += jumpDirection;

            //collisions

            //staying in the screen
            if (bounds.X < 0)
            {
                bounds.X = 0;
            }
            if (bounds.X > game.GraphicsDevice.Viewport.Width - bounds.Width)
            {
                bounds.X = game.GraphicsDevice.Viewport.Width - bounds.Width;
            }
            if (bounds.Y < 0)
            {
                bounds.Y = 0;
            }
            if (bounds.Y > groundLevel)
            {
                bounds.Y = groundLevel;
            }

            //if (bounds.Y > game.GraphicsDevice.Viewport.Height - bounds.Height)
            //{
            //    bounds.Y = game.GraphicsDevice.Viewport.Height - bounds.Height;
            //}
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, bounds, Color.White);
        }



    }
}
