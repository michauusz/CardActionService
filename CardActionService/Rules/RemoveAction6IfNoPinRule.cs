using CardActionService.Interfaces.Rules;
using CardActionService.Models;

namespace CardActionService.Rules
{
    public class RemoveAction6IfNoPinRule : IActionRule
    {
        private static readonly HashSet<CardStatus> AffectedStatuses =
        [CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active];

        public void ApplyRule(CardStatus cardStatus, bool isPinSet, List<string> actions)
        {
            if (!isPinSet && AffectedStatuses.Contains(cardStatus))
            {
                actions.Remove("ACTION6");
            }
        }
    }
}
