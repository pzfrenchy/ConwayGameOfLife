using System;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameBoardTests
    {
        private GameBoard GetBoard(int h, int w)
        {
            return new GameBoard(h, w);
        }

        [TestMethod]
        public void CreateBoard_3x3_Returns3x3Board()
        {
            GameBoard b = GetBoard(3, 3);
            Cell[,] expected = new Cell[3, 3];

            CollectionAssert.AreEqual(expected, b.Board);
        }

        [TestMethod]
        public void CreateBoard_5x5_Returns5x5Board()
        {
            GameBoard b = GetBoard(5, 5);
            Cell[,] expected = new Cell[5, 5];

            CollectionAssert.AreEqual(expected, b.Board);
        }

        [TestMethod]
        public void SetAllBoardCellsToDead_ChangesAllCellsToDead()
        {
            GameBoard b = GetBoard(3, 3);
            Cell[,] expected = new Cell[3, 3];
            b.PopulateBoardCells(CellState.Dead);
            b.Board[0, 0].CState.Equals(CellState.Alive);
            b.SetAllBoardCellsToDead();

            Assert.IsTrue(b.Board[0, 0].CState.Equals(CellState.Dead));
        }

        [TestMethod]
        public void CheckEdgeCaseNegativeRows_True_ReturnsTrue()
        {
            GameBoard b = GetBoard(5, 5);
            int r = -1;
            int c = 0;

            Assert.IsTrue(b.EdgeCase(r, c));
        }

        [TestMethod]
        public void CheckEdgeCaseNegativeColumns_True_ReturnsTrue()
        {
            GameBoard b = GetBoard(5, 5);
            int r = 0;
            int c = -1;

            Assert.IsTrue(b.EdgeCase(r, c));
        }

        [TestMethod]
        public void CheckEdgeCaseExceededRows_True_ReturnsTrue()
        {
            GameBoard b = GetBoard(5, 5);
            int r = 5;
            int c = 0;

            Assert.IsTrue(b.EdgeCase(r, c));
        }

        [TestMethod]
        public void CheckEdgeCaseExceededColumns_True_ReturnsTrue()
        {
            GameBoard b = GetBoard(5, 5);
            int r = 0;
            int c = 5;

            Assert.IsTrue(b.EdgeCase(r, c));
        }

        [TestMethod]
        public void CheckEdgeCase_False_ReturnsFalse()
        {
            GameBoard b = GetBoard(5, 5);
            int r = 1;
            int c = 1;

            Assert.IsFalse(b.EdgeCase(r, c));
        }

        [TestMethod]
        public void CellAlive_Dead_ReturnsFalse()
        {
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);

            Assert.IsFalse(b.CellAlive(0, 0));
        }

        [TestMethod]
        public void CellAlive_Alive_ReturnsTrue()
        {
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[0, 0].FlipState();

            Assert.IsTrue(b.CellAlive(0, 0));
        }

        [TestMethod]
        public void CountNeighbors_NoNeighbors_Returns0()
        {
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();

            Assert.AreEqual(0, b.CountNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_OneNeighborToTop_Returns1()
        {
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();
            b.Board[0, 1].FlipState();

            Assert.AreEqual(1, b.CountNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_OneNeighborTopRight_Returns1()
        {
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();
            b.Board[0, 2].FlipState();

            Assert.AreEqual(1, b.CountNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_OneNeighborToRight_Returns1()
        {
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();
            b.Board[1, 2].FlipState();

            Assert.AreEqual(1, b.CountNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_OneNeighborToBottomRight_Returns1()
        {
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();
            b.Board[2, 2].FlipState();

            Assert.AreEqual(1, b.CountNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_OneNeighborToBottom_Returns1()
        {
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();
            b.Board[2, 1].FlipState();

            Assert.AreEqual(1, b.CountNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_OneNeighborToBottomLeft_Returns1()
        {
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();
            b.Board[2, 0].FlipState();

            Assert.AreEqual(1, b.CountNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_OneNeighborToLeft_Returns1()
        {
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();
            b.Board[1, 0].FlipState();

            Assert.AreEqual(1, b.CountNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_OneNeighborToTopLeft_Returns1()
        {
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();
            b.Board[0, 0].FlipState();

            Assert.AreEqual(1, b.CountNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_TwoNeighbors_Returns2()
        {
            GameBoard b = GetBoard(5, 5);
            b.PopulateBoardCells(CellState.Dead);
            b.Board[1, 1].FlipState();
            b.Board[0, 0].FlipState();
            b.Board[1, 0].FlipState();

            Assert.AreEqual(2, b.CountNeighbors(1, 1));
        }
    }
}
