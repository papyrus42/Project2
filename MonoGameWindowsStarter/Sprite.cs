using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace MonoGameWindowsStarter
{
    enum State
    {
        South = 0,
        East = 1,
        West = 2,
        North = 3,
        Idle = 4,
    }
    public class Sprite
    {
        public BoundaryRectangle bounds;

        Game1 game;

        public Texture2D sprite;

        public float jumpHeight;

        public bool canJump;

        public float groundLevel;

        SoundEffect jumpSFX;

        bool soundHasPlayed;

        public bool isOnPlatform;

        const int ANIMATION_FRAME_RATE = 124;
        const int FRAME_WIDTH = 49;

        /// <summary>
        /// The hieght of the animation frames
        /// </summary>
        const int FRAME_HEIGHT = 63;

        State state;
        TimeSpan timer;
        int frame;
        Vector2 position;

        //bool isOnPlatform;

        public Sprite(Game1 game)
        {
            this.game = game;
            timer = new TimeSpan(0);
            position = new Vector2(200, 200);
            state = State.Idle;
        }

        public void Initialize(float width, float height, float x, float y)
        {
            bounds.Width = FRAME_WIDTH;
            bounds.Height = FRAME_HEIGHT;
            bounds.X = x;
            bounds.Y = y;
            groundLevel = game.GraphicsDevice.Viewport.Height - bounds.Height;
            jumpHeight = 0;
            canJump = true;
            soundHasPlayed = false;
            isOnPlatform = false;
        }

        public void LoadContent(ContentManager cm, string name)
        {
            sprite = cm.Load<Texture2D>(name);
            jumpSFX = cm.Load<SoundEffect>("jumpSound");
        }

        public void Update(GameTime gameTime)
        {
            float runDirection = 0;
            float jumpDirection = 0;
            
            //run left
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                state = State.West;
                runDirection -= (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.2);

            }
            //run right
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                state = State.East;
                runDirection += (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.2);
            }
            

            //jump
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && jumpHeight < 90 && canJump)
            {
                state = State.North;
                jumpDirection -= (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.3);
                jumpHeight += 3;
                if (!soundHasPlayed)
                {
                    jumpSFX.Play();
                    soundHasPlayed = true;
                }
            }
            else if (isOnPlatform)
            {
                canJump = true;
                jumpHeight = 0;
                soundHasPlayed = false;
            }
            else
            {
                
                jumpDirection += (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.3);
            }
            if(Keyboard.GetState().IsKeyUp(Keys.Left)&& Keyboard.GetState().IsKeyUp(Keys.Right)&& Keyboard.GetState().IsKeyUp(Keys.Up))
            {
                state = State.Idle;
            }
            if (jumpHeight >= 90)
            {
                canJump = false;
            }
            if (!canJump)
            {
                jumpHeight -= 3;
                //jumpDirection += (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.3);
            }

            if (bounds.Y >= groundLevel && jumpHeight <= 0)
            {
                canJump = true;
                soundHasPlayed = false;
            }
            

            bounds.X += runDirection;
            bounds.Y += jumpDirection;
            if (state != State.Idle) timer += gameTime.ElapsedGameTime;

            // Determine the frame should increase.  Using a while 
            // loop will accomodate the possiblity the animation should 
            // advance more than one frame.
            while (timer.TotalMilliseconds > ANIMATION_FRAME_RATE)
            {
                // increase by one frame
                frame++;
                // reduce the timer by one frame duration
                timer -= new TimeSpan(0, 0, 0, 0, ANIMATION_FRAME_RATE);
            }

            // Keep the frame within bounds (there are four frames)
            frame %= 4;

            //collisions

            ////////////if (bounds.CollidesWith(platform.bounds))
            ////////////{
            ////////////    isOnPlatform = true;
            ////////////}
            ////////////else
            ////////////{
            ////////////    isOnPlatform = false;
            ////////////}

            ////////////if (isOnPlatform)
            ////////////{
            ////////////    jumpHeight = 0;
            ////////////    canJump = true;
            ////////////}
            ////////////else if (bounds.Y < groundLevel)
            ////////////{
            ////////////    jumpDirection += (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.3);
            ////////////}

            ////////////bounds.X += runDirection;
            ////////////bounds.Y += jumpDirection;

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
            var source = new Rectangle(
               frame * FRAME_WIDTH, // X value 
               (int)state % 4 * FRAME_HEIGHT, // Y value
               FRAME_WIDTH, // Width 
               FRAME_HEIGHT // Height
               );
            spriteBatch.Draw(sprite,new Vector2(bounds.X,bounds.Y), source, Color.White);
        }



    }
}
