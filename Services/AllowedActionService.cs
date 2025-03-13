using CardActionService.Models;
using Newtonsoft.Json;

namespace CardActionService.Services
{
    public class AllowedActionService
    {
        private readonly AllowedActions _allowedActions;

        public AllowedActionService(IWebHostEnvironment env)
        {
            var filePath = Path.Combine(env.ContentRootPath, "Resources", "allowedActions.json");
            var json = File.ReadAllText(filePath);
            _allowedActions = JsonConvert.DeserializeObject<AllowedActions>(json) ?? throw new Exception("Failed to deserialize json");
        }

        public List<string> GetAllowedActions(CardType cardType, CardStatus cardStatus, bool isPinSet)
        {
            if (_allowedActions.Actions.TryGetValue(cardType, out var cardActions))
            {
                var actionsForCardType = cardActions;

                if (actionsForCardType != null && actionsForCardType.TryGetValue(cardStatus, out var actions))
                {
                    if (isPinSet)
                    {
                        if (cardStatus == CardStatus.Blocked)
                        {
                            actions.Add("ACTION6");
                            actions.Add("ACTION7");
                        }
                    }
                    else
                    {
                        if (cardStatus == CardStatus.Ordered || cardStatus == CardStatus.Inactive || cardStatus == CardStatus.Active)
                        {
                            actions.Remove("ACTION6");
                            actions.Add("ACTION7");
                        }
                    }

                    return actions;
                }
            }
            return [];
        }
    }
}