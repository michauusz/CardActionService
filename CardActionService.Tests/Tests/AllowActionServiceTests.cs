using CardActionService.Interfaces.Rules;
using CardActionService.Models;
using CardActionService.Rules;
using CardActionService.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardActionService.Tests.Tests
{
    public class AllowActionServiceTests
    {
        private readonly AllowedActionService _allowedActionService;

        public AllowActionServiceTests()
        {
            var mockEnv = new Mock<IWebHostEnvironment>();
            mockEnv.Setup(env => env.ContentRootPath).Returns(Directory.GetCurrentDirectory());

            var rules = new List<IActionRule>
            {
                new BlockedNoPinRule(),
                new RemoveAction6IfNoPinRule(),
                new RemoveAction7IfNoPinRule()
            };

            _allowedActionService = new AllowedActionService(mockEnv.Object, rules);
        }

        [Fact]
        public void GetAllowedActions_ShouldNotRemoveAction6And7_IfPinSetAndBlocked()
        {
            var cardType = CardType.Prepaid;
            var cardStatus = CardStatus.Blocked;
            var isPinSet = true;

            var result = _allowedActionService.GetAllowedActions(cardType, cardStatus, isPinSet);

            Assert.NotNull(result);
            result.Should().Contain("ACTION6");
            result.Should().Contain("ACTION7");
        }

        [Fact]
        public void GetAllowedActions_ShouldRemoveAction6And7_IfNoPinSetAndNoBlocked()
        {
            var cardType = CardType.Prepaid;
            var cardStatus = CardStatus.Blocked;
            var isPinSet = false;

            var result = _allowedActionService.GetAllowedActions(cardType, cardStatus, isPinSet);

            Assert.NotNull(result);
            result.Should().NotContain("ACTION6");
            result.Should().NotContain("ACTION7");
        }

        [Fact]
        public void GetAllowedActions_ShouldRemoveAction6_IfNoPinAndOrdered()
        {
            var cardType = CardType.Prepaid;
            var cardStatus = CardStatus.Ordered;
            var isPinSet = false;

            var result = _allowedActionService.GetAllowedActions(cardType, cardStatus, isPinSet);

            Assert.NotNull(result);
            result.Should().NotContain("ACTION6");
            result.Should().Contain("ACTION7");
        }

        [Fact]
        public void GetAllowedActions_ShouldRemoveAction6_IfNoPinAndInactive()
        {
            var cardType = CardType.Prepaid;
            var cardStatus = CardStatus.Inactive;
            var isPinSet = false;

            var result = _allowedActionService.GetAllowedActions(cardType, cardStatus, isPinSet);

            Assert.NotNull(result);
            result.Should().NotContain("ACTION6");
            result.Should().Contain("ACTION7");
        }

        [Fact]
        public void GetAllowedActions_ShouldRemoveAction6_IfNoPinAndActive()
        {
            var cardType = CardType.Prepaid;
            var cardStatus = CardStatus.Active;
            var isPinSet = false;

            var result = _allowedActionService.GetAllowedActions(cardType, cardStatus, isPinSet);

            Assert.NotNull(result);
            result.Should().NotContain("ACTION6");
            result.Should().Contain("ACTION7");
        }

        [Fact]
        public void GetAllowedActions_ShouldRemoveAction7_IfPinAndOrdered()
        {
            var cardType = CardType.Prepaid;
            var cardStatus = CardStatus.Ordered;
            var isPinSet = true;

            var result = _allowedActionService.GetAllowedActions(cardType, cardStatus, isPinSet);

            Assert.NotNull(result);
            result.Should().NotContain("ACTION7");
            result.Should().Contain("ACTION6");
        }

        [Fact]
        public void GetAllowedActions_ShouldRemoveAction7_IfPinAndInactive()
        {
            var cardType = CardType.Prepaid;
            var cardStatus = CardStatus.Inactive;
            var isPinSet = true;

            var result = _allowedActionService.GetAllowedActions(cardType, cardStatus, isPinSet);

            Assert.NotNull(result);
            result.Should().NotContain("ACTION7");
            result.Should().Contain("ACTION6");
        }

        [Fact]
        public void GetAllowedActions_ShouldRemoveAction7_IfPinAndActive()
        {
            var cardType = CardType.Prepaid;
            var cardStatus = CardStatus.Active;
            var isPinSet = true;

            var result = _allowedActionService.GetAllowedActions(cardType, cardStatus, isPinSet);

            Assert.NotNull(result);
            result.Should().NotContain("ACTION7");
            result.Should().Contain("ACTION6");
        }
    }
}
