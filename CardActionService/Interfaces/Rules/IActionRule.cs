using CardActionService.Models;

namespace CardActionService.Interfaces.Rules
{
    public interface IActionRule
    {
        void ApplyRule(CardStatus cardStatus, bool isPinSet, List<string> actions);
    }
}
