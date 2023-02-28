using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext __context;
        private readonly IMapper _mapper;

        public MessageRepository(DataContext _context, IMapper mapper)
        {
            _mapper = mapper;
            __context = _context;
            
        }
        public void AddMessage(Message message)
        {
            __context.Messages.Add(message);
        }

        public void DeleteMessage(Message message)
        {
            __context.Messages.Remove(message);
        }

        public async Task<Message> GetMessage(int id)
        {
            return await __context.Messages.FindAsync(id);
        }

        public async Task<PagedList<MessageDto>> GetMessageForUser(MessageParams messageParams)
        {
            var query = __context.Messages
            .OrderByDescending(x => x.MessageSent)
            .AsQueryable();

            query = messageParams.Container switch
            {
                "Inbox" => query.Where(u => u.RecipientUsername == messageParams.Username && u.RecipientDeleted == false),
                "Outbox" => query.Where(u => u.SenderUsername == messageParams.Username && u.SenderDeleted ==false),
                _ => query.Where(u => u.RecipientUsername == messageParams.Username && u.RecipientDeleted == false && u.DateRead == null),
            };

            var messages = query.ProjectTo<MessageDto>(_mapper.ConfigurationProvider);
            return await PagedList<MessageDto>.CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
        }

        public async Task<IEnumerable<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername)
        {
            var messages = await __context.Messages.Include(u => u.Sender).ThenInclude(p => p.Photos)
                .Include(u => u.Recipient).ThenInclude(p => p.Photos)
                .Where(
                    m => m.RecipientUsername == currentUsername && m.RecipientDeleted == false &&
                    m.SenderUsername == recipientUsername ||
                    m.RecipientUsername == recipientUsername && m.SenderDeleted == false &&
                    m.SenderUsername == currentUsername
                )
                .OrderBy(m => m.MessageSent)
                .ToListAsync();

                var unreadMessages = messages.Where(m => m.DateRead == null && m.RecipientUsername == currentUsername).ToList();

                if(unreadMessages.Any())
                {
                    foreach(var message in unreadMessages)
                    {
                        message.DateRead = DateTime.UtcNow;
                    }

                    await __context.SaveChangesAsync();
                }

                return _mapper.Map<IEnumerable<MessageDto>>(messages);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await __context.SaveChangesAsync() > 0;
        }
    }
}