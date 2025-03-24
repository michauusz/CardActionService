using CardActionService.Models;
using CardActionService.Rules;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardActionService.Tests.Tests
{
    public class RemoveAction6IfNoPinRuleTests
    {
        private readonly RemoveAction6IfNoPinRule _removeAction6IfNoPinRule;
        private readonly List<string> actions =
            [
                "ACTION6"
            ];

        public RemoveAction6IfNoPinRuleTests()
        {
            _removeAction6IfNoPinRule = new RemoveAction6IfNoPinRule();
        }

        [Fact]
        public void ApplyRule_ShouldRemoveAction6_IfNoPinAndOrdered()
        {
            var cardStatus = CardStatus.Ordered;
            var isPinSet = false;

            _removeAction6IfNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().NotContain("ACTION6");
        }

        [Fact]
        public void ApplyRule_ShouldRemoveAction6_IfNoPinAndActive()
        {
            var cardStatus = CardStatus.Active;
            var isPinSet = false;

            _removeAction6IfNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().NotContain("ACTION6");
        }

        [Fact]
        public void ApplyRule_ShouldRemoveAction6_IfNoPinAndInactive()
        {
            var cardStatus = CardStatus.Inactive;
            var isPinSet = false;

            _removeAction6IfNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().NotContain("ACTION6");
        }

        [Fact]
        public void ApplyRule_ShouldNotRemoveAction6_IfPinAndOrdered()
        {
            var cardStatus = CardStatus.Ordered;
            var isPinSet = true;

            _removeAction6IfNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().Contain("ACTION6");
        }

        [Fact]
        public void ApplyRule_ShouldNotRemoveAction6_IfPinAndActive()
        {
            var cardStatus = CardStatus.Active;
            var isPinSet = true;

            _removeAction6IfNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().Contain("ACTION6");
        }

        [Fact]
        public void ApplyRule_ShouldNotRemoveAction6_IfPinAndInactive()
        {
            var cardStatus = CardStatus.Inactive;
            var isPinSet = true;

            _removeAction6IfNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().Contain("ACTION6");
        }
    }
}
