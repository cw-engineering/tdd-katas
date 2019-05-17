using NUnit.Framework;
using Shouldly;
using tdd.tictactoe.contracts;
using System;

namespace tdd.tictactoe.tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Play_ShouldImplementTheContract()
        {
            var game = new Game();

            (game is IGamePlay).ShouldBeTrue();
        }

        [TestCase(4, 5)]
        [TestCase(-1, -1)]
        [TestCase(0, -1)]
        public void Play_WithInvalidCoordinates_ShouldThrowException(int x, int y)
        {
            var game = new Game();

            Should.Throw<ArgumentException>(() => { game.Play(x, y, Player.O); });
        }

        [Test]
        public void Play_WithValidCoordinates_ShouldReflectTheState()
        {
            var game = new Game();

            game.Play(1, 1, Player.O);
            game.State().ShouldNotBeNull();
        }

        [Test]
        public void Play_PlayerShouldNotBeAbleToPlayTwiceInARow()
        {
            var game = new Game();

            game.Play(1, 1, Player.O);
            Should.Throw<ArgumentException>(() => { game.Play(0, 0, Player.O); });
        }

        [Test]
        public void Play_PlayerShouldNotBeAbleToPlaceASymbolAtAlreadyTakenLocation()
        {
            var game = new Game();
            game.Play(1, 1, Player.X);
            Should.Throw<ArgumentException>(() => { game.Play(1, 1, Player.O); });
        }

        [Test]
        public void Play_BoardHas3SymbolsInARow()
        {
            var game = new Game();
            game.Play(0, 0, Player.X);
            game.Play(1, 0, Player.O);
            game.Play(0, 1, Player.X);
            game.Play(1, 1, Player.O);
            game.Play(0, 2, Player.X);

            var board = game.State().Board;
            board[0, 0].ShouldBe(Player.X);
            board[0, 1].ShouldBe(Player.X);
            board[0, 2].ShouldBe(Player.X);
        }

        [Test]
        public void Play_StateHasCorrectWinner()
        {
            var game = new Game();
            game.Play(0, 0, Player.X);
            game.Play(1, 0, Player.O);
            game.Play(0, 1, Player.X);
            game.Play(1, 1, Player.O);
            game.Play(0, 2, Player.X);

            var state = game.State();
            state.Winner.ShouldBe(Player.X);

        }

        [Test]
        public void Play_StateDoesNotHaveAWinnerIfAWinConditionHasNotBeenMet()
        {
            var game = new Game();
            game.Play(0, 0, Player.X);

            var state = game.State();
            state.Winner.ShouldBeNull();

        }

        [Test]
        public void Play_WinnerIsNullIfBoardDoesNotHave3InARow()
        {
            var game = new Game();
            game.Play(0, 0, Player.X);
            game.Play(1, 0, Player.O);
            game.Play(0, 1, Player.X);

            var state = game.State();
            state.Winner.ShouldBeNull();
        }

        [Test]
        public void Play_StateHasCorrectWinnerFor3InALine()
        {
            var game = new Game();
            game.Play(1, 0, Player.X);
            game.Play(2, 0, Player.O);
            game.Play(1, 1, Player.X);
            game.Play(2, 1, Player.O);
            game.Play(1, 2, Player.X);

            var state = game.State();
            state.Winner.ShouldBe(Player.X);
        }

        [Test]
        public void PlayShouldThrowWhenThereIsAlreadyAWinner()
        {
            var game = new Game();
            game.Play(1, 0, Player.X);
            game.Play(2, 0, Player.O);
            game.Play(1, 1, Player.X);
            game.Play(2, 1, Player.O);
            game.Play(1, 2, Player.X);

            Should.Throw<ArgumentException>(() => game.Play(2,2,Player.O));
        }
    }
}
