using CardActionService.Models;

namespace CardActionService.Interfaces.Services
{
    public interface IAllowedActionService
    {
        public List<string> GetAllowedActions(CardType cardType, CardStatus cardStatus, bool isPinSet);
    }
}
