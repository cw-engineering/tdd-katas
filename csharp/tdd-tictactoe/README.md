# Tic Tac Toe

_TDD kata with NUnit and Shouldly._

#### Implement gameplay logic for the Tic Tac Toe game.

Given the following contracts:

```c#
interface IGamePlay {
    void Play(int x, int y, Player player);
    IGameState State();
}
```
```c#
interface IGameState {
    Player?[,] Board { get; }
    Player? Winner { get; }
    bool IsDraw { get; }
}
```

#### 1. Create a public class that implements the `IGamePlay` contract and write the logic for the `IGamePlay.Play()` method that will allow to progress the game. Whenever the game cannot progress, an exception is thrown with a suitable message.

Requirements:

 * The board is made up of 3x3 grid of empty spaces
 * The first player decides whether they want to use "X" or "O" symbol
 * Symbols can be placed only in an empty space on the grid
 * The same player can not play twice in one row
 * The player that first gets three symbols in a row, column or diagonal wins
 * If there are no more available moves, the game is a draw

Layout:

```js
   |  0  1  2   (x)
--------------
 0 | [ ][ ][ ]
 1 | [ ][ ][ ]
 2 | [ ][ ][ ]

(y)
```

#### 2. Report the game state using the `IGamePlay.State()` method.

Requirements:

 * It needs to represent the current state of the game
 * Users should not be able to tinker the state (i.e. by modifying the Board contents)

