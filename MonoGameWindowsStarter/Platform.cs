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
    public class Platform
    {
        public BoundaryRectangle bounds;

        Game1 game;

        public Texture2D platform;

        //bool isOnPlatform;

        public Platform(Game1 game)
        {
            this.game = game;
        }

        public void Initialize(float width, float height, float x, float y)
        {
            bounds.Width = width;
            bounds.Height = height;
            bounds.X = x;
            bounds.Y = y;
            //isOnPlatform = false;
        }
        public void LoadContent(ContentManager cm, string name)
        {
            platform = cm.Load<Texture2D>(name);
        }

        public void Update(GameTime gameTime)
        {
           
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(platform, bounds, Color.Red);
        }

    }
}
