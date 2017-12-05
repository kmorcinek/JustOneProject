using Newtonsoft.Json;
using Xunit;

namespace JustOneProject.VariousStuff.ValueObject
{
    public class MoneyTests
    {
        [Fact]
        public void SerializationTest()
        {
            var money = Money.Create(1, "USD");
            
            string json = JsonConvert.SerializeObject(money);
            Money result = JsonConvert.DeserializeObject<Money>(json);
            
            Assert.Equal(money.Currency, result.Currency);
        }
    }
}