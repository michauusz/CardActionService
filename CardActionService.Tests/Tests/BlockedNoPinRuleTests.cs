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
    public class BlockedNoPinRuleTests
    {
        private readonly BlockedNoPinRule _blockedNoPinRule;
        private readonly List<string> actions =
            [
                "ACTION6",
                "ACTION7"
            ];

        public BlockedNoPinRuleTests()
        {
            _blockedNoPinRule = new BlockedNoPinRule();
        }

        [Fact]
        public void ApplyRule_ShouldRemoveAction6_IfNoPinAndBlocked()
        {
            var cardStatus = CardStatus.Blocked;
            var isPinSet = false;

            _blockedNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().NotContain("ACTION6");
            actions.Should().NotContain("ACTION7");
        }

        [Fact]
        public void ApplyRule_ShouldNotRemoveAction6_IfPinAndBlocked()
        {
            var cardStatus = CardStatus.Blocked;
            var isPinSet = true;

            _blockedNoPinRule.ApplyRule(cardStatus, isPinSet, actions);

            actions.Should().Contain("ACTION6");
            actions.Should().Contain("ACTION7");
        }
    }
}
