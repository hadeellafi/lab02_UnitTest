using lab02;
using Xunit;
namespace ATMtest
{
    public class UnitTest1
    {
        [Fact]
        public void TestViewBalance()
        {
            Program.Balance = 1000;
            Assert.Equal(Program.Balance, Program.ViewBalance());
        }

        [Theory]
        [InlineData(1200, 1000, 1000)]//withdraw>balance
        [InlineData(-1, 1000, 1000)]//withdraw<0
        //amount more than balance
        public void TestWithdrawInvaildAmount1(decimal withdrawAmount, decimal expectedNewBalance, decimal balance)
        {
            Program.Balance = balance;
            decimal newActualBalance = Program.Withdraw(withdrawAmount);

            Assert.Equal(expectedNewBalance, newActualBalance);
        }

        

        [Fact]
       

        public void TestWithdrawVaildAmount()
        {
            decimal balance = 1000;
            Program.Balance = balance;
            decimal withdrawAmount = 500;

            decimal expectedBalance = Program.Balance - withdrawAmount;
            decimal actual = Program.Withdraw(withdrawAmount);
            Assert.Equal(expectedBalance, actual);
        }

        [Theory]

        [InlineData(-300, 1000, 1000)]//Invalid
        [InlineData(1500, 2500, 1000)]//valid
        public void TestDeposit(decimal depositeAmount, decimal expectedNewBalance, decimal balance)
        {
            Program.Balance = balance;

            decimal newAcutalBalance = Program.Deposit(depositeAmount);

            Assert.Equal(expectedNewBalance, newAcutalBalance);
        }
    }
}