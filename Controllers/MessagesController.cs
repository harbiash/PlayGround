using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlayGround.WebAPI.Helpers;
using PlayGround.WebAPI.Models.ViewModels;
using PlayGround.WebAPI.Services;

namespace PlayGround.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : Controller
    {
        private static readonly HttpClient HttpClient = new();
        private readonly IOptions<AppSettings> _appSettings;

        public MessagesController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }
        
        [Route("/messages")]
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var (apiKey, baseUrl) = GetAppSettingsValueTuple();
            var url = $"{baseUrl}/Messages?maxRecords=3&view=Grid%20view";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            var response = await HttpClient.SendAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return NotFound(response.ToString());
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MessageResponse>(responseContent);
            return Ok(Map(result));
        }
        [Route("/messages")]
        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] CreateMessageRequest messageRequest)
        {
            var (apiKey, baseUrl) = GetAppSettingsValueTuple();
            var url = $"{baseUrl}/Messages";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            request.Content = GetRecords().GetStringContent();
            var response = await HttpClient.SendAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return NotFound(response.ToString());
            }
            return Ok();

        }

        private static List<MessagesViewModel> Map(MessageResponse messageList)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MessageDTO, MessagesViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Fields != null ? src.Fields.Message : null))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Fields != null ? src.Fields.Summary : null))
                .ForMember(dest => dest.ReceivedAt, opt => opt.MapFrom(src => src.CreatedTime))
            );
            var mapper = config.CreateMapper();
            var response = mapper.Map<List<MessagesViewModel>>(messageList.Records);
            return response;
        }

        private (string apiKey, string baseUrl) GetAppSettingsValueTuple()
        {
            return (_appSettings.Value.ApiKey, _appSettings.Value.BaseApiUrl);
        }
        private static List<Record> GetRecords() =>
            new()
            {
                new Record()
                {
                    //instead of fields we could put message reqeuests values or whatever...
                    Fields = new List<Fields>()
                    {
                        new()
                        {
                            Id = 1,
                            Summary = "Test message summary",
                            Message = "Exception occurred at...",
                            ReceivedAt = DateTime.UtcNow

                        },
                        new()
                        {
                            Id=1,
                            Summary = "test",
                            Message = "Exception occurred at...",
                            ReceivedAt = DateTime.UtcNow
                        }
                    }
                }
            };
    }
}
