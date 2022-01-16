namespace Tdd.Tests;

[TestFixture]
public class GameTests
{
    [Test]
    public void Game_ImplementsIGamePlayContract()
    {
        var game = new Game();

        (game is IGamePlay).ShouldBeTrue();
    }

}
