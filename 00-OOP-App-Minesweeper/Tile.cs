using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_OOP_App_Minesweeper
{
    internal class Tile
    {
        public enum TileState { Intact, Revealed, Flagged }

        public bool IsMine { get; init; } //init lze změnit jen v konstruktoru

        public TileState State { get; private set; }

        private int neighbours;

        public int Neighbours
        {
            get { return neighbours; }
            set 
            {
                if (value < 0 || value > 8)
                    throw new ArgumentOutOfRangeException();
                
                neighbours = value; 
            }
        }

        //public bool HasExploded => IsMine && State == TileState.Revealed;
        
        public bool HasExploded
        {
            get
            {
                return IsMine && State == TileState.Revealed;
            }
        }

        public bool HasProperFlag
        {
            get
            {
                if (!IsMine && State != TileState.Flagged)
                    return true;

                else if (IsMine && State == TileState.Flagged)
                    return true;

                else
                    return false;
            }
        }

        public Tile(bool isMine)
        {
            IsMine = isMine;
            State = TileState.Intact;
        }

        public void Reveal()
        {
            if (State == TileState.Intact)
                State = TileState.Revealed;
        }

        public void Flag()
        {
            switch (State)
            {
                case TileState.Intact:
                    State = TileState.Flagged;
                    break;

                case TileState.Flagged:
                    State = TileState.Intact;
                    break;
            }
        }


    }
}
