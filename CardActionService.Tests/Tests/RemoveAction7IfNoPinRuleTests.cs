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
    public class RemoveAction7IfNoPinRuleTests
    {
        private readonly RemoveAction7IfNoPinRule _removeAction7IfNoPinRule;
        private readonly List<string> actions =
            [
                "ACTION7"
            ];

        public RemoveAction7IfNoPinRuleTests()
        {
            _removeAction7IfNoPinRule = new RemoveAction7IfNoPinRule();
        }

        [Fact]
        public void ApplyRule_ShouldRemoveAction7_IfPinAndOrdered()
        {
            var cardStatus = CardStatus.Ordered;
            var isPinSet = true;

            _removeAction7IfNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().NotContain("ACTION7");
        }

        [Fact]
        public void ApplyRule_ShouldRemoveAction7_IfPinAndActive()
        {
            var cardStatus = CardStatus.Active;
            var isPinSet = true;

            _removeAction7IfNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().NotContain("ACTION7");
        }

        [Fact]
        public void ApplyRule_ShouldRemoveAction7_IfPinAndInactive()
        {
            var cardStatus = CardStatus.Inactive;
            var isPinSet = true;

            _removeAction7IfNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().NotContain("ACTION7");
        }

        [Fact]
        public void ApplyRule_ShouldNotRemoveAction7_IfNoPinAndOrdered()
        {
            var cardStatus = CardStatus.Ordered;
            var isPinSet = false;

            _removeAction7IfNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().Contain("ACTION7");
        }

        [Fact]
        public void ApplyRule_ShouldNotRemoveAction7_IfNoPinAndActive()
        {
            var cardStatus = CardStatus.Active;
            var isPinSet = false;

            _removeAction7IfNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().Contain("ACTION7");
        }

        [Fact]
        public void ApplyRule_ShouldNotRemoveAction7_IfNoPinAndInactive()
        {
            var cardStatus = CardStatus.Inactive;
            var isPinSet = false;

            _removeAction7IfNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().Contain("ACTION7");
        }
    }
}
