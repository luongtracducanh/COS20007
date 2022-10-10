using System;
using NUnit.Framework;
using Swin_Adventure;

namespace Tests
{
    public class MoveTest
    {
        Move _moveCommand;
        Player _testPlayer;
        Location _testRoomA;
        Location _testRoomB;
        Path _testPath;

        [Test]
        public void TestMoveOnPlayer()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("Klim", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            _moveCommand.Execute(_testPlayer, new string[] { "move", "to", "north" });

            String _expected = _testRoomB.Name;
            String _actual = _testPlayer.Location.Name;
            Assert.AreEqual(_expected, _actual, "Testing that move can move the player");
        }

        [Test]
        public void TestMoveString()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("Klim", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            String _expected = "You have moved north through a Door to the Room B.\r\n\nRoom B";
            String _actual = _moveCommand.Execute(_testPlayer, new string[] { "move", "to", "north" }); ;
            Assert.AreEqual(_expected, _actual, "Testing that move string is correct");
        }

        [Test]
        public void TestInvalidMoveNoArg()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("Klim", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);

            String _expected = "Move where?";
            String _actual = _moveCommand.Execute(_testPlayer, new string[] { "move" }); ;
            Assert.AreEqual(_expected, _actual, "Testing invalid move: no path specified");
        }

        [Test]
        public void TestInvalidMoveBadArg()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("Klim", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);

            String _expected = "Error in move input.";
            String _actual = _moveCommand.Execute(_testPlayer, new string[] { "move", "east" }); ;
            Assert.AreEqual(_expected, _actual, "Testing invalid move: non existent path");
        }

        [Test]
        public void TestInvalidMoveNoLocation()
        {
            _moveCommand = new Move();
            _testPlayer = new Player("Klim", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testPlayer.Location = _testRoomA;

            String _expected = "Error in move input.";
            String _actual = _moveCommand.Execute(_testPlayer, new string[] { "move", "east" }); ;
            Assert.AreEqual(_expected, _actual, "Testing invalid move: non existent path");
        }
    }
}
