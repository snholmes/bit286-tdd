namespace LuckySpinUTest;
using LuckySpin.Models;
using LuckySpin.Repositories;

public class SpinTest
{
    [Fact]
    public void Spin_Charging_ReducesBalanceByFiftyCents()
    {
        //Assign
        ISpinRepository repo = new SpinRepository();
        Player p = new Player();
        p.AddCredit(10);
        repo.AddPlayer(p);

        //Act
        repo.ChargePlayer();

        //Assert
        Assert.Equal(9.5m, p.Balance, 2);

    }

    //New Test
    [Fact]
    public void Spin_Charging_ReturnsFalseIfBalanceIsLessThanZero()
    {
        //Assign
        ISpinRepository repo = new SpinRepository();
        Player p = new Player();
        p.AddCredit(0.49m);
        repo.AddPlayer(p);

        //Act
        Boolean b = repo.ChargePlayer();

        //Assert
        Assert.False(b);
    }

    //New Test
    [Fact]
    public void Spin_Charging_ReturnsFalseIfBalanceIsGreaterThan100()
    {
        //Assign
        ISpinRepository repo = new SpinRepository();
        Player p = new Player();
        p.AddCredit(100);
        repo.AddPlayer(p);

        //Act
        Boolean b = repo.ChargePlayer();

        //Assert
        Assert.False(b);
    }
}
