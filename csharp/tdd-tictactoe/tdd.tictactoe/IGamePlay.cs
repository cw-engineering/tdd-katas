namespace Tdd;

public interface IGamePlay
{
    void Play(int x, int y, Player player);

    IGameState State();
}
