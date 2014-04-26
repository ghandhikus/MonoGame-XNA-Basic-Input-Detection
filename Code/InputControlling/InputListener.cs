#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Game
{
    class InputListener
    {
        virtual public void Down() { }
        virtual public void Up() { }
        virtual public void Click() { }
        virtual public void Hold() { }
    }
}
