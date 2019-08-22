using System;
using System.Collections.Generic;
using System.Text;

namespace HBSISLogicTest.GameLogic.Exceptions
{
    public class WrongNumberOfPlayersError : Exception
    {
        public WrongNumberOfPlayersError(int numberOfPlayersSet) 
            : base($"Number of players (incorrectly) set: {numberOfPlayersSet}.") { }
    }
}
