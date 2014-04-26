#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
#endregion

namespace MapEditor
{
    class InputChecker
    {
        #region Config
        double clickTime = 0.4D;
        #endregion
        #region Event Lists
        List<a> keyboardKeyEvents = new List<a>();
        List<b> gamepadOneButtonEvents = new List<b>();
        List<b> gamepadTwoButtonEvents = new List<b>();
        List<b> gamepadThreeButtonEvents = new List<b>();
        List<b> gamepadFourButtonEvents = new List<b>();
        #endregion

        #region Device States
        KeyboardState lastKeyboardState = Keyboard.GetState();
        GamePadState lastGamePadOneState = GamePad.GetState(PlayerIndex.One);
        GamePadState lastGamePadTwoState = GamePad.GetState(PlayerIndex.Two);
        GamePadState lastGamePadThreeState = GamePad.GetState(PlayerIndex.Three);
        GamePadState lastGamePadFourState = GamePad.GetState(PlayerIndex.Four);
        #endregion

        #region InputListener States
        class a
        {
            public Keys key;
            public InputListener listener;
            public double clickTime = 0.0f;
            public bool holdHasFired = false;
        }
        class b
        {
            public Buttons button;
            public InputListener listener;
            public double clickTime = 0.0f;
            public bool holdHasFired = false;
        }
        #endregion

        #region AddListener Overloads
        public void AddListener(Keys key, InputListener listener)
        {
            a meow = new a();
            meow.key = key;
            meow.listener = listener;
            keyboardKeyEvents.Add(meow);
        }
        public void AddListener(Buttons button, InputListener listener, PlayerIndex player = PlayerIndex.One)
        {
            b meow = new b();
            meow.button = button;
            meow.listener = listener;
            if(player == PlayerIndex.One)
                switch(player)
                {
                    case PlayerIndex.One:
                        gamepadOneButtonEvents.Add(meow);
                        break;
                    case PlayerIndex.Two:
                        gamepadTwoButtonEvents.Add(meow);
                        break;
                    case PlayerIndex.Three:
                        gamepadThreeButtonEvents.Add(meow);
                        break;
                    case PlayerIndex.Four:
                        gamepadFourButtonEvents.Add(meow);
                        break;
                    default:
                        throw new Exception("Unknown PlayerIndex");
                }
        }
        #endregion

        #region Update
        public void Update(GameTime gameTime)
        {

            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadOneState = GamePad.GetState(PlayerIndex.One);
            GamePadState gamePadTwoState = GamePad.GetState(PlayerIndex.Two);
            GamePadState gamePadThreeState = GamePad.GetState(PlayerIndex.Three);
            GamePadState gamePadFourState = GamePad.GetState(PlayerIndex.Four);

            ParseKeyboardEvents(gameTime, keyboardState);
            ParseGamePadEvents(gameTime, gamePadOneState, lastGamePadOneState);
            ParseGamePadEvents(gameTime, gamePadOneState, lastGamePadTwoState);
            ParseGamePadEvents(gameTime, gamePadOneState, lastGamePadThreeState);
            ParseGamePadEvents(gameTime, gamePadOneState, lastGamePadFourState);

            lastKeyboardState = keyboardState;
            lastGamePadOneState = gamePadOneState;
            lastGamePadTwoState = gamePadTwoState;
            lastGamePadThreeState = gamePadThreeState;
            lastGamePadFourState = gamePadFourState;
        }
        #endregion

        #region Event Parsers
        private void ParseGamePadEvents(GameTime gameTime, GamePadState gamePadState, GamePadState lastGamePadState)
        {
            double delta = gameTime.ElapsedGameTime.TotalSeconds;

            foreach(b meow in gamepadOneButtonEvents)
            {
                if(gamePadState.IsButtonDown(meow.button))
                {
                    meow.clickTime += delta;
                    meow.listener.Tick(gameTime);
                    if(meow.holdHasFired == false && meow.clickTime > clickTime)
                    {
                        meow.listener.Hold(gameTime);
                        meow.holdHasFired = true;
                    }
                }


                if(gamePadState.IsButtonDown(meow.button) == true && lastGamePadState.IsButtonDown(meow.button) == false)
                {
                    meow.listener.Down(gameTime);
                }
                else if(lastGamePadState.IsButtonDown(meow.button) == true && gamePadState.IsButtonDown(meow.button) == false)
                {
                    if(meow.clickTime <= clickTime)
                        meow.listener.Click(gameTime);
                    meow.listener.Up(gameTime);
                }


                if(gamePadState.IsButtonDown(meow.button) == false)
                {
                    meow.clickTime = 0;
                    meow.holdHasFired = false;
                }
            }
        }

        private void ParseKeyboardEvents(GameTime gameTime, KeyboardState keyboardState)
        {
            double delta = gameTime.ElapsedGameTime.TotalSeconds;

            foreach(a meow in keyboardKeyEvents)
            {
                if(keyboardState.IsKeyDown(meow.key))
                {
                    meow.clickTime += delta;
                    meow.listener.Tick(gameTime);
                    if(meow.holdHasFired == false && meow.clickTime > clickTime)
                    {
                        meow.listener.Hold(gameTime);
                        meow.holdHasFired = true;
                    }
                }


                if(keyboardState.IsKeyDown(meow.key) == true && lastKeyboardState.IsKeyDown(meow.key) == false)
                {
                    meow.listener.Down(gameTime);
                }
                else if(lastKeyboardState.IsKeyDown(meow.key) == true && keyboardState.IsKeyDown(meow.key) == false)
                {
                    meow.listener.Up(gameTime);
                    if(meow.clickTime <= clickTime)
                        meow.listener.Click(gameTime);
                }


                if(keyboardState.IsKeyDown(meow.key) == false)
                {
                    meow.clickTime = 0;
                    meow.holdHasFired = false;
                }
            }
        }
        #endregion
    }
}
