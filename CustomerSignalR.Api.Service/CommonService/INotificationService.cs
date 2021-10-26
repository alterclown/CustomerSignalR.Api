using CustomerSignalR.Api.Data.Entities;
using CustomerSignalR.Api.Repository.CommonRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSignalR.Api.Service.CommonService
{
    public interface INotificationService
    {
        Task<NotificationCountResult> GetNotificationCount();
        Task<List<NotificationResult>> GetNotificationMessageList();
        Task<string> DeleteNotifications();
    }

    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> DeleteNotifications()
        {
            try
            {
                var res = await _repository.DeleteNotifications();
                return res;
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
                var res = await _repository.GetNotificationCount();
                return res;
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
                var res = await _repository.GetNotificationMessageList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
