using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Domain.Services.Communication;
using API.Infrastructure;

namespace API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IAddressRepository addressRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(
            ICustomerRepository customerRepository,
            IAddressRepository addressRepository,
            IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.addressRepository = addressRepository;
            this.unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Customer>> ListAsync()
        {
            return customerRepository.ListAsync();
        }

        public async Task<CustomerResponse> FindByIdAsync(int id)
        {
            var customer = await customerRepository.FindByIdAsync(id);
            return customer == null ? new CustomerResponse("Customer not found") : new CustomerResponse(customer);
        }

        public async Task<CustomerResponse> SaveAsync(Customer customer)
        {
            try
            {
                var address = customer.Address;
                await addressRepository.AddAsync(address);
                await unitOfWork.CompleteAsync();
                customer.Password = CryptographyTool.CryptSHA512(customer.Password);
                customer.AddressId = address.AddressId;
                await customerRepository.AddAsync(customer);
                await unitOfWork.CompleteAsync();
                return new CustomerResponse(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message);
                return new CustomerResponse($"An error occurred when saving the customer: {e.Message}");
            }
        }

        public async Task<CustomerResponse> UpdateAsync(int id, Customer customer)
        {
            var existingCustomer = await customerRepository.FindByIdAsync(id);

            if (existingCustomer == null)
                return new CustomerResponse("Customer not found.");

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.Password = customer.Password;

            try
            {
                customerRepository.Update(existingCustomer);
                await unitOfWork.CompleteAsync();
                return new CustomerResponse(existingCustomer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message);
                return new CustomerResponse($"An error occurred when updating the customer: {e.Message}");
            }
        }

        public async Task<CustomerResponse> Authenticate(string email, string password)
        {
            var authenticateCustomer = await customerRepository.Authenticate(email, password);
            if (authenticateCustomer == null)
                return new CustomerResponse("Email or/and password is incorrect");

            authenticateCustomer.Token = JWTProvider.GenerateJWT(authenticateCustomer);
            return new CustomerResponse(authenticateCustomer);
        }
    }
}