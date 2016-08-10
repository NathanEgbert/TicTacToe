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
            g1.placeInput("1", "x");
            g1.placeInput("4", "x");
            g1.placeInput("7", "x");

            Assert.AreEqual(g1.checkForwin("x"), true);

            GameLogic g2 = new GameLogic();
            g2.placeInput("2", "x");
            g2.placeInput("5", "x");
            g2.placeInput("8", "x");

            Assert.AreEqual(g2.checkForwin("x"), true);

            GameLogic g3 = new GameLogic();
            g3.placeInput("3", "x");
            g3.placeInput("6", "x");
            g3.placeInput("9", "x");

            Assert.AreEqual(g2.checkForwin("x"), true);

        }

        [TestMethod]
        public void rowWins()
        {
            GameLogic g1 = new GameLogic();
            g1.placeInput("1", "o");
            g1.placeInput("2", "o");
            g1.placeInput("3", "o");

            Assert.AreEqual(g1.checkForwin("o"), true);

            GameLogic g2 = new GameLogic();
            g2.placeInput("4", "o");
            g2.placeInput("5", "o");
            g2.placeInput("6", "o");

            Assert.AreEqual(g2.checkForwin("o"), true);

            GameLogic g3 = new GameLogic();
            g3.placeInput("7", "o");
            g3.placeInput("8", "o");
            g3.placeInput("9", "o");

            Assert.AreEqual(g2.checkForwin("o"), true);

        }

        [TestMethod]
        public void diagonalWins()
        {

            GameLogic g1 = new GameLogic();
            g1.placeInput("1", "o");
            g1.placeInput("5", "o");
            g1.placeInput("9", "o");

            Assert.AreEqual(g1.checkForwin("o"), true);

            GameLogic g2 = new GameLogic();
            g2.placeInput("3", "x");
            g2.placeInput("5", "x");
            g2.placeInput("7", "x");

            Assert.AreEqual(g2.checkForwin("x"), true);

        }
    }
}
