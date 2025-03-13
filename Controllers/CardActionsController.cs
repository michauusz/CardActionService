using CardActionService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardActionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardActionsController : ControllerBase
    {
        private readonly CardService _cardService;
        private readonly AllowedActionService _allowedActionService;

        public CardActionsController(CardService cardService, AllowedActionService allowedActionService)
        {
            _cardService = cardService;
            _allowedActionService = allowedActionService;
        }

        [HttpGet("{userId}/{cardNumber}")]
        public async Task<IActionResult> GetAllowedActions(string userId, string cardNumber)
        {
            var cardDetails = await _cardService.GetCardDetails(userId, cardNumber);
            if (cardDetails == null)
            {
                return NotFound("Card not found");
            }

            var actions = _allowedActionService.GetAllowedActions(cardDetails.CardType, cardDetails.CardStatus, cardDetails.IsPinSet);

            return Ok(new { AllowedActions = actions });
        }

    }
}
