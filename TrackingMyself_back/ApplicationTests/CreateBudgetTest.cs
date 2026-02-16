using Dto.Budget;
using UseCases;

namespace ApplicationTests
{
    [TestClass]
    public sealed class CreateBudgetTEst
    {
        [TestMethod]
        public void CrearBudget_DtoMappedToDomain()
        {
            //ARRANGE
            CreateBudgetDto dto = new CreateBudgetDto()
            {
                Description = "Test Budget",
                Income = 5000,
                Month = 10,
                Year = 2024,
                TimeTense = "FUTURE"
            };

            //ACT
            CreateBudget command = new CreateBudget();
            command.Execute(dto);

            Assert.IsNotNull(command.Budget);
            Assert.AreEqual("Future", command.Budget.Time.TimeTenseDescription);
            Assert.AreEqual(2024, command.Budget.Time.Year);
            Assert.AreEqual(10, command.Budget.Time.Month);
            Assert.AreEqual(10, command.Budget.Time.Month);
            Assert.AreEqual("Test Budget", command.Budget.Decription);
            Assert.AreEqual(5000, command.Budget.Income);
            Assert.AreEqual(5000, command.Budget.Available);
        }
    }
}
