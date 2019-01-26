using System;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameTests
    {
        private GameBoard GetBoard(int h, int w)
        {
            return new GameBoard(h, w);
        }

        [TestMethod]
        public void SingleGameIteration_CellAliveAndNoNeighbor_ChangesToDead()
        {
            Game g = new Game();
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();
            b.Board = g.SingleGameIteration(b);

            Assert.IsFalse(b.CellAlive(1, 1));
        }

        [TestMethod]
        public void SingleGameIteration_CellAliveAndOneNeighbor_ChangesToDead()
        {
            Game g = new Game();
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[0, 0].FlipState();
            b.Board[0, 1].FlipState();
            b.Board = g.SingleGameIteration(b);

            Assert.IsFalse(b.CellAlive(0, 0));
        }

        [TestMethod]
        public void SingleGameIteration_CellAliveAndTwoNeighbors_StaysAlive()
        {
            Game g = new Game();
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();
            b.Board[0, 0].FlipState();
            b.Board[1, 0].FlipState();
            b.Board = g.SingleGameIteration(b);

            Assert.IsTrue(b.CellAlive(0, 0));
        }

        [TestMethod]
        public void SingleGameIteration_CellAliveAndThreeNeighbors_StaysAlive()
        {
            Game g = new Game();
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();
            b.Board[0, 0].FlipState();
            b.Board[1, 0].FlipState();
            b.Board[0, 1].FlipState();
            b.Board = g.SingleGameIteration(b);

            Assert.IsTrue(b.CellAlive(1, 1));
        }

        [TestMethod]
        public void SingleGameIteration_CellAliveAndFourNeighbors_ChangesToDead()
        {
            Game g = new Game();
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();
            b.Board[0, 0].FlipState();
            b.Board[1, 0].FlipState();
            b.Board[0, 1].FlipState();
            b.Board[2, 0].FlipState();
            b.Board = g.SingleGameIteration(b);

            Assert.IsFalse(b.CellAlive(1, 1));
        }

        [TestMethod]
        public void SingleGameIteration_CellDeadAndThreeNeighbors_ChangesToAlive()
        {
            Game g = new Game();
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[0, 0].FlipState();
            b.Board[1, 0].FlipState();
            b.Board[0, 1].FlipState();
            b.Board = g.SingleGameIteration(b);

            Assert.IsTrue(b.CellAlive(1, 1));
        }
    }
}
