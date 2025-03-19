using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace FIAP.TechChallenge.ContactsDeleteConsumer.Domain.DTOs.EntityDTOs
{
    [ExcludeFromCodeCoverage]
    public class ContactCreateDto
    {
        [JsonProperty(PropertyName = "id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "areaCode")]
        [JsonPropertyName("areaCode")]
        public string AreaCode { get; set; }

        [JsonProperty(PropertyName = "phone")]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
