using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeConsole;

namespace TicTacToeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void columnWins()
        {

            GameLogic g1 = new GameLogic();
            g1.PlaceInput("1", "x");
            g1.PlaceInput("4", "x");
            g1.PlaceInput("7", "x");

            Assert.AreEqual(g1.CheckForWin("x"), true);

            GameLogic g2 = new GameLogic();
            g2.PlaceInput("2", "x");
            g2.PlaceInput("5", "x");
            g2.PlaceInput("8", "x");

            Assert.AreEqual(g2.CheckForWin("x"), true);

            GameLogic g3 = new GameLogic();
            g3.PlaceInput("3", "x");
            g3.PlaceInput("6", "x");
            g3.PlaceInput("9", "x");

            Assert.AreEqual(g2.CheckForWin("x"), true);

        }

        [TestMethod]
        public void rowWins()
        {
            GameLogic g1 = new GameLogic();
            g1.PlaceInput("1", "o");
            g1.PlaceInput("2", "o");
            g1.PlaceInput("3", "o");

            Assert.AreEqual(g1.CheckForWin("o"), true);

            GameLogic g2 = new GameLogic();
            g2.PlaceInput("4", "o");
            g2.PlaceInput("5", "o");
            g2.PlaceInput("6", "o");

            Assert.AreEqual(g2.CheckForWin("o"), true);

            GameLogic g3 = new GameLogic();
            g3.PlaceInput("7", "o");
            g3.PlaceInput("8", "o");
            g3.PlaceInput("9", "o");

            Assert.AreEqual(g2.CheckForWin("o"), true);

        }

        [TestMethod]
        public void diagonalWins()
        {

            GameLogic g1 = new GameLogic();
            g1.PlaceInput("1", "o");
            g1.PlaceInput("5", "o");
            g1.PlaceInput("9", "o");

            Assert.AreEqual(g1.CheckForWin("o"), true);

            GameLogic g2 = new GameLogic();
            g2.PlaceInput("3", "x");
            g2.PlaceInput("5", "x");
            g2.PlaceInput("7", "x");

            Assert.AreEqual(g2.CheckForWin("x"), true);

        }
    }
}
