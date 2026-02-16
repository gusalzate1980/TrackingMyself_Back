using Entity;
using Services;
using TrackingMyself.Domain.Entities;

namespace DomainServicesTest
{
    [TestClass]
    public sealed class BudgetServiceTests
    {
        private BudgetDomainService _budgetServiceCanCreate;
        
        private BudgetDomainService _budgetServicePastNotAllowed;
        
        private BudgetDomainService _budgetServiceFutureDuplicated;
        
        [TestInitialize]
        public void Setup()
        {
            _budgetServiceCanCreate = new BudgetDomainService();
            _budgetServicePastNotAllowed = new BudgetDomainService();
            _budgetServiceFutureDuplicated = new BudgetDomainService();
        }


        [TestMethod]
        public void CrearBudget_CanCreate()
        {
            //ARRANGE
            var time = new TimeDomain { Id = 1, Year = 2026, Month = 4, TimeTense = TimeTenseEnum.FUTURE };
            BudgetDomain budget = new BudgetDomain() 
            {
                Time = time,
                Income = 1000,
                Description = "Can Create"
            };
            
            //ACT
            budget = _budgetServiceCanCreate.CreateBudget(budget, SetCurrentAndFutureBudgets());

            Assert.IsNotNull(budget);
            Assert.IsTrue(budget.IsValid);
        }

        [TestMethod]
        public void CrearBudget_PastNotAllowed()
        {
            //ARRANGE
            var time = new TimeDomain { Id = 1, Year = 2025, Month = 12, TimeTense = TimeTenseEnum.PAST };
            BudgetDomain budget = new BudgetDomain()
            {
                Time = time,
                Income = 1000,
                Description = "Past Not Allowed"
            };
            
            //ACT
            budget = _budgetServicePastNotAllowed.CreateBudget(budget, SetCurrentAndFutureBudgets());

            Assert.IsNotNull(budget);
            Assert.AreEqual("Budget cannot be created for past tenses.", _budgetServicePastNotAllowed.Errors[0].ErrorDetail[0]);        
        }

        [TestMethod]
        public void CrearBudget_FutureDuplicated()
        {
            //ARRANGE
            var time = new TimeDomain { Id = 3, Year = 2026, Month = 3, TimeTense = TimeTenseEnum.FUTURE };
            BudgetDomain budget = new BudgetDomain()
            {
                Time = time,
                Income = 1250,
                Description = "Future Duplicated"
            };
            
            //ACT
            budget = _budgetServiceFutureDuplicated.CreateBudget(budget, SetCurrentAndFutureBudgets());

            Assert.IsNotNull(budget);
            Assert.AreEqual("There is already a budget in the same future period.", _budgetServiceFutureDuplicated.Errors[0].ErrorDetail[0]);
        }

        private List<BudgetDomain> SetCurrentAndFutureBudgets()
        {
            var time1 = new TimeDomain { Id = 1, Year = 2025, Month = 12, TimeTense = Entity.TimeTenseEnum.PAST };
            var time2 = new TimeDomain { Id = 2, Year = 2026, Month = 2, TimeTense = Entity.TimeTenseEnum.PRESENT };
            var time3 = new TimeDomain { Id = 3, Year = 2026, Month = 3, TimeTense = Entity.TimeTenseEnum.FUTURE };

            return new List<BudgetDomain>()
            {
                new BudgetDomain { Id = 1, Time = time1, Income = 1000, Available = 0 },
                new BudgetDomain { Id = 2, Time = time2, Income = 1500, Available = 0 },
                new BudgetDomain { Id = 3, Time = time3, Income = 2000, Available = 2000 }
            };
        }

    }
}
