using System;
using System.Collections.Generic;
using System.Text;

namespace HBSISLogicTest.GameLogic.Exceptions
{
    class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError(string wrongMoveSet) 
            : base($"Wrong move set: {wrongMoveSet}.") { }
    }
}
