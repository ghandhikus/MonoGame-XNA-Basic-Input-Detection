#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
#endregion

namespace MapEditor
{
    class InputListener
    {
        virtual public void Down(GameTime gameTime) { }
        virtual public void Up(GameTime gameTime) { }
        virtual public void Click(GameTime gameTime) { }
        virtual public void Hold(GameTime gameTime) { }
        virtual public void Tick(GameTime gameTime) { }
    }
}
