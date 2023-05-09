namespace LuckySpinUTest;
using LuckySpin.Repositories;
using LuckySpin.Models;

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
        Assert.Equal(9.5m,p.Balance, 2);

    }
}
