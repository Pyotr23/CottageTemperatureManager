using System.Linq;
using AutoMapper;
using CottageTemperature.Libraries.Core.DTOes.Telegram;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Message = CottageTemperature.Libraries.Core.DTOes.Telegram.Message;

namespace CottageTemperature.Web.MapperProfiles
{
    /// <summary>
    ///     Profile for mapping of telegram entities to DTO.
    /// </summary>
    public class TelegramMapperProfile : Profile
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        public TelegramMapperProfile()
        {
            CreateMap<Update, Message>(MemberList.Destination)
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src
                        => src.Id))
                .ForMember(dest => dest.ChatId,
                    opt => opt.MapFrom(src
                        => src.Message.Chat.Id))
                .ForMember(dest => dest.Text,
                    opt => opt.MapFrom(src
                        => src.Message.Text ?? string.Empty))
                .ForMember(dest => dest.ChatName,
                    opt => opt.MapFrom(src
                        => src.Message.Chat.Type == ChatType.Group
                            ? src.Message.Chat.Title
                            : src.Message.Chat.Username))
                .ForMember(dest => dest.SenderUsername,
                    opt => opt.MapFrom(src
                        => src.Message.From.Username))
                .ForMember(dest => dest.IsCommand,
                    opt => opt.MapFrom(src
                        => src.Message.Entities.First().Type == MessageEntityType.BotCommand));
        }
    }
}