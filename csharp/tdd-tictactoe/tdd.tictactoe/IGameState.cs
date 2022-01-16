﻿namespace Tdd;

public interface IGameState
{
    Player?[,] Board { get; }
    Player? Winner { get; }
    bool IsDraw { get; }
}
