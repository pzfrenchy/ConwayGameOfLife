using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeTests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void FlipState_CellAlive_ChangesToDead()
        {
            Cell cell = new Cell(CellState.Alive);
            cell.FlipState();

            Assert.IsTrue(cell.CState.Equals(CellState.Dead));
        }

        [TestMethod]
        public void FlipState_CellDead_ChangesToAlive()
        {
            Cell cell = new Cell(CellState.Dead);
            cell.FlipState();

            Assert.IsTrue(cell.CState.Equals(CellState.Alive));
        }
    }
}
