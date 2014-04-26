#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class G : Game
    {
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        InputChecker inputChecker;
        public static Texture2D tile;

        private static G instance;
        public G() : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            instance = this;
        }

        protected override void Initialize()
        {
            base.Initialize();

            inputChecker = new InputChecker();

            /////////////////
            ///
            ///if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            ///    Exit();
            ///    
            /// This code will be turned into InputChecker code
            /// 
            /////////////////

            InputEvents.Exit exitListener = new InputEvents.Exit();

            inputChecker.AddListener(Buttons.Back, exitListener);
            inputChecker.AddListener(Keys.Escape, exitListener);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            inputChecker.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }

        public void Quit()
        {
            Exit();
        }

        public static G GetInstance()
        {
            return instance;
        }
    }
}
