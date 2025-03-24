using CardActionService.Interfaces.Rules;
using CardActionService.Interfaces.Services;
using CardActionService.Models;
using Newtonsoft.Json;

namespace CardActionService.Services
{
    public class AllowedActionService : IAllowedActionService
    {
        private readonly AllowedActions _allowedActions;
        private readonly IEnumerable<IActionRule> _rules;

        public AllowedActionService(IWebHostEnvironment env, IEnumerable<IActionRule> rules)
        {
            var filePath = Path.Combine(env.ContentRootPath, "Resources", "allowedActions.json");
            var json = File.ReadAllText(filePath);
            _allowedActions = JsonConvert.DeserializeObject<AllowedActions>(json) ?? throw new Exception("Failed to deserialize json");
            _rules = rules;
        }

        public List<string> GetAllowedActions(CardType cardType, CardStatus cardStatus, bool isPinSet)
        {
            if (_allowedActions.Actions.TryGetValue(cardType, out var cardActions))
            {
                var actionsForCardType = cardActions;

                if (actionsForCardType != null && actionsForCardType.TryGetValue(cardStatus, out var actions))
                {
                    foreach (var rule in _rules)
                    {
                        rule.ApplyRule(cardStatus, isPinSet, actions);
                    }

                    return actions;
                }
            }
            return [];
        }
    }
}