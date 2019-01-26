namespace GameOfLife
{
    public class Cell
    {
        public CellState CState { get; set; }

        public Cell(CellState cState)
        {
            this.CState = cState;
        }

        public void FlipState()
        {
            if (CState == CellState.Alive)
                CState = CellState.Dead;
            else if (CState == CellState.Dead)
                CState = CellState.Alive;
        }
    }
}
