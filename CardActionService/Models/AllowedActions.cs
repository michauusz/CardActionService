using Newtonsoft.Json;

namespace CardActionService.Models
{
    public class AllowedActions
    {
        [JsonProperty("Prepaid")]
        public Dictionary<CardStatus, List<string>> Prepaid { get; set; }

        [JsonProperty("Debit")]
        public Dictionary<CardStatus, List<string>> Debit { get; set; }

        [JsonProperty("Credit")]
        public Dictionary<CardStatus, List<string>> Credit { get; set; }

        public Dictionary<CardType, Dictionary<CardStatus, List<string>>> Actions => new() {
            { CardType.Prepaid, Prepaid },
            { CardType.Debit, Debit },
            { CardType.Credit, Credit } 
        };
    }
}
