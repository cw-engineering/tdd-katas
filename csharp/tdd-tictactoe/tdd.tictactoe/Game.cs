using System;
using tdd.tictactoe.contracts;

namespace tdd.tictactoe
{
    public class Game: IGamePlay, IGameState
    {
        private Player? player;
        public Player?[,] Board { get; } = new Player?[3, 3];
        public Player? Winner { get; private set; }
        public bool IsDraw { get; }
        public void Play(int x, int y, Player player)
        {
            if (x < 0 || x > 2 || y < 0)
            {
                throw new ArgumentException();
            }

            if (this.Winner != null)
            {
                throw new ArgumentException();
            }

            if (this.player == player)
            {
                throw new ArgumentException();
            }

            this.player = player;
            if (this.Board[x, y] != null)
            {
                throw new ArgumentException();
            }

            this.Board[x, y] = this.player;

            for (var row = 0; row < 3; row++)
            {
                if (Board[row, 0] == this.player && Board[row, 1] == this.player && Board[row, 2] == this.player)
                {
                    this.Winner = this.player;
                }
            }
        }

        public IGameState State()
        {
            return this;
        }

    }
}
