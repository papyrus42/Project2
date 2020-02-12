using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameWindowsStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite player;
        SpriteFont font;
        Platform plat;
        Platform plat2;
        Platform plat3;
        Platform plat4;
        Platform plat5;
        Platform plat6;
        string text;
      
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            player = new Sprite(this);
            plat = new Platform(this);
            plat2 = new Platform(this);
            plat3 = new Platform(this);
            plat4 = new Platform(this);
            plat5 = new Platform(this);
            plat6 = new Platform(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1042;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
            player.Initialize(10, 10, 0, 760);
            plat.Initialize(60, 10, 500, 650);
            plat2.Initialize(70, 10, 320, 510);
            plat3.Initialize(50, 10, 480, 400);
            plat4.Initialize(120, 10, 700, 400);
            plat5.Initialize(30, 10, 575, 250);
            plat6.Initialize(90, 10, 280, 270);
            text = "Try to make it over here!";

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(Content, "more sprite");
            plat.LoadContent(Content,"pixel");
            plat2.LoadContent(Content, "pixel");
            plat3.LoadContent(Content, "pixel");
            plat4.LoadContent(Content, "pixel");
            plat5.LoadContent(Content, "pixel");
            plat6.LoadContent(Content, "pixel");
            font = Content.Load<SpriteFont>("Font");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);
            //check for collisions
            
            plat.Update(gameTime);
            if (player.bounds.CollidesWith(plat.bounds)|| player.bounds.CollidesWith(plat2.bounds) || player.bounds.CollidesWith(plat3.bounds)
                || player.bounds.CollidesWith(plat4.bounds) || player.bounds.CollidesWith(plat5.bounds) || player.bounds.CollidesWith(plat6.bounds))
            {
                player.isOnPlatform = true;
            }
            else
            {
                player.isOnPlatform = false;
            }
            if (player.bounds.CollidesWith(plat6.bounds))
            {
                text = "You did it!";
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            plat.Draw(spriteBatch);
            plat2.Draw(spriteBatch);
            player.Draw(spriteBatch);
            plat3.Draw(spriteBatch);
            plat4.Draw(spriteBatch);
            plat5.Draw(spriteBatch);
            plat6.Draw(spriteBatch);
            spriteBatch.DrawString(font, text, new Vector2(200, 200), Color.White);
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
