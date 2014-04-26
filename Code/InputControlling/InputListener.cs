#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
#endregion

namespace Game
{
    class InputListener
    {
        virtual public void Down() { }
        virtual public void Up() { }
        virtual public void Click() { }
        virtual public void Hold() { }
        virtual public void Tick(GameTime gameTime) { }
    }
}
