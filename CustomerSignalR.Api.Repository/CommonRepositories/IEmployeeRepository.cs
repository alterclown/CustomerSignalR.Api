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
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeeList();
        Task<Employee> GetEmployeeById(int Id);
        Task<Employee> InsertEmployee(Employee employee);
        Task<string> UpdateEmployee(int id, Employee employee);
        Task<string> DeleteEmployee(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SignalContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public EmployeeRepository(SignalContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public async Task<string> DeleteEmployee(int id)
        {
            try
            {

                var res = await _context.Employee.FindAsync(id);
                Notification notification = new Notification()
                {
                    EmployeeName = res.Name,
                    TranType = "Delete"
                };

                _context.Employee.Remove(res);
                _context.Notification.Add(notification);
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.BroadcastMessage();
                return "Deleted";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> GetEmployeeById(int Id)
        {
            try
            {
                var res = await _context.Employee.FirstOrDefaultAsync(m => m.Id == Id);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeeList()
        {
            try
            {
                var response = from c in _context.Employee
                               orderby c.Id descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> InsertEmployee(Employee employee)
        {
            try
            {
                _context.Employee.Add(employee);
                Notification notification = new Notification()
                {
                    EmployeeName = employee.Name,
                    TranType = "Add"
                };
                _context.Notification.Add(notification);
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.BroadcastMessage();
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                var res = await _context.Employee.FirstOrDefaultAsync(m => m.Id == id);
                res.Name = employee.Name;
                res.Designation = employee.Designation;
                res.Company = employee.Company;
                res.Cityname = employee.Cityname;
                res.Address = employee.Address;
                res.Gender = employee.Gender;
                _context.Update(res);
                Notification notification = new Notification()
                {
                    EmployeeName = employee.Name,
                    TranType = "Edit"
                };
                _context.Notification.Add(notification);
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.BroadcastMessage();
                return "Updated Record";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
