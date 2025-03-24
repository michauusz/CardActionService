using CardActionService.Models;

namespace CardActionService.Interfaces.Services
{
    public interface ICardService
    {
        Task<CardDetails?> GetCardDetails(string userId, string cardNumber);
    }
}