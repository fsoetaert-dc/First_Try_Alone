

public class GameTests
{
    private readonly Game game = new();

    [Fact]
    public void GutterGameScoresZero()
    {
        RollMany(20, 0);
        Assert.Equal(0, game.Score());
    }

    [Fact]
    public void AllOnesScoresTwenty()
    {
        RollMany(20, 1);
        Assert.Equal(20, game.Score());
    }

    private void RollMany(int times, int pins)
    {
        for (var i = 0; i < times; i++)
        {
            game.Roll(pins);
        }
    }
    [Fact]
    public void OneSpareCountsNextRollAsBonus()
    {
        game.Roll(5);
        game.Roll(5); // spare
        game.Roll(3);
        RollMany(17, 0);

        // 5 + 5 + bonus 3 + normal roll 3 = 16
        Assert.Equal(16, game.Score());
    }

    // [Fact]
    // public void OneStrikeCountsNextTwoRollsAsBonus()
    // {
    //     game.Roll(10); // strike
    //     game.Roll(3);
    //     game.Roll(4);
    //     RollMany(16, 0);

    //     // 10 + bonus 3 + bonus 4 + normal roll 3 + normal roll 4 = 24 
    //     Assert.Equal(24, game.Score());
    // }
    [Fact]
    public void PerfectGameScoresThreeHundred()
    {
        // 10 frames
        // + 2 bonus rolls for the strike in the tenth frame
        RollMany(12, 10);

        Assert.Equal(300, game.Score());
    }

    [Fact]
    public void AlmostPerfectGame1()
    {

        RollMany(9, 10);
        game.Roll(5);
        game.Roll(5); // spare
        game.Roll(3);

        Assert.Equal(268, game.Score());
    }

    [Fact]
    public void AlmostPerfectGame2()
    {

        RollMany(9, 10);
        game.Roll(5);
        game.Roll(1); // spare


        Assert.Equal(257, game.Score());
    }

    [Fact]
    public void CheckOrderPoints()
    {

        game.Roll(10);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(8);
        game.Roll(10);


        var givenList = new List<(int, int, int)>
        {(10,0,0), (2,2,0), (2,2,0), (2,2,0), (2,2,0), (2,2,0), (2,2,0), (2,2,0), (2,2,0), (8,10,0)};
        var listRolls = game.GiveInitialList();

        Assert.Equal(givenList, game.OrderPoints(listRolls));
    }

}