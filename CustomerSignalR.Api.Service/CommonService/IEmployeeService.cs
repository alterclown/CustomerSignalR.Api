using CustomerSignalR.Api.Data.Entities;
using CustomerSignalR.Api.Repository.CommonRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSignalR.Api.Service.CommonService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeeList();
        Task<Employee> GetEmployeeById(int Id);
        Task<Employee> InsertEmployee(Employee employee);
        Task<string> UpdateEmployee(int id, Employee employee);
        Task<string> DeleteEmployee(int id);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> DeleteEmployee(int id)
        {
            try
            {
                var res = await _repository.DeleteEmployee(id);
                return res;
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
                var res = await _repository.GetEmployeeById(Id);
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
                var res = await _repository.GetEmployeeList();
                return res;
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
                var res = await _repository.InsertEmployee(employee);
                return res;
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
                var res = await _repository.UpdateEmployee(id,employee);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
