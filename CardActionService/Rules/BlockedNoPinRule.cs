using CardActionService.Interfaces.Rules;
using CardActionService.Models;

namespace CardActionService.Rules
{
    public class BlockedNoPinRule : IActionRule
    {
        public void ApplyRule(CardStatus cardStatus, bool isPinSet, List<string> actions)
        {
            if (!isPinSet && cardStatus == CardStatus.Blocked)
            {
                actions.Remove("ACTION6");
                actions.Remove("ACTION7");
            }
        }
    }
}
