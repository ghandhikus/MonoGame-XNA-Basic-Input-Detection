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
        public override void Down() { Console.WriteLine("+Down has fired."); }

        public override void Up() { Console.WriteLine("-Up has fired."); }

        public override void Click()
        {
            Console.WriteLine("=Click has fired.");
            G.GetInstance().Quit();
        }

        public override void Hold() { Console.WriteLine("||Hold has fired."); }
    }
}
