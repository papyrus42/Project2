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

        public Sprite(Game1 game)
        {
            this.game = game;
        }

        public void LoadContent(ContentManager cm, string name)
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }



    }
}
