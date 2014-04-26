#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Game
{
    abstract class InputListener
    {
        abstract public void Down();
        abstract public void Up();
        abstract public void Click();
        abstract public void Hold();
    }
}
