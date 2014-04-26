#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Game.InputEvents
{
    class Exit : InputListener
    {
        public override void Down(GameTime gameTime) { Console.WriteLine("+Down has fired."); }

        public override void Up(GameTime gameTime) { Console.WriteLine("-Up has fired."); }

        public override void Click(GameTime gameTime)
        {
            Console.WriteLine("=Click has fired.");
            G.GetInstance().Quit();
        }

        public override void Hold(GameTime gameTime) { Console.WriteLine("||Hold has fired."); }
        public override void Tick(GameTime gameTime) { Console.WriteLine("@Tick has fired."); }
    }
}
