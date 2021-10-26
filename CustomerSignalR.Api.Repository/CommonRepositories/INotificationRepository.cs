using CustomerSignalR.Api.Data.Context;
using CustomerSignalR.Api.Data.Entities;
using CustomerSignalR.Api.SignalR.Hub;
using CustomerSignalR.Api.SignalR.Interface;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSignalR.Api.Repository.CommonRepositories
{
    public interface INotificationRepository
    {
        Task<NotificationCountResult> GetNotificationCount();
        Task<List<NotificationResult>> GetNotificationMessageList();
        Task<string> DeleteNotifications();
    }
    public class NotificationRepository : INotificationRepository
    {
        private readonly SignalContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public NotificationRepository(SignalContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public async Task<string> DeleteNotifications()
        {
            try
            {
                var res = await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Notification");
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.BroadcastMessage();
                return "Deleted";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<NotificationCountResult> GetNotificationCount()
        {
            try
            {
                var count = (from not in _context.Notification
                             select not).CountAsync();
                NotificationCountResult result = new NotificationCountResult
                {
                    Count = await count
                };
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<NotificationResult>> GetNotificationMessageList()
        {
            try
            {
                var results = from message in _context.Notification
                              orderby message.Id descending
                              select new NotificationResult
                              {
                                  EmployeeName = message.EmployeeName,
                                  TranType = message.TranType
                              };
                return await results.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
