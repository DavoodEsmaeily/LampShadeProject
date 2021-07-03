using _0_Framework.Application;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System;
using System.Collections.Generic;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            var operation = new OperationResult();
            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var customerDiscount = new CustomerDiscount(command.Reason , command.DiscountRate, command.StartDate.ToGeorgianDateTime(), command.EndDate.ToGeorgianDateTime(), command.ProductId);

            _customerDiscountRepository.Create(customerDiscount);
            _customerDiscountRepository.SaveChanges();

            return operation.Succeded();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operaton = new OperationResult();
            var customerDiscount = _customerDiscountRepository.Get(command.Id);

            if (customerDiscount == null)
                return operaton.Failed(ApplicationMessages.RecordNotFound);

            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operaton.Failed(ApplicationMessages.DuplicatedRecord);

            customerDiscount.Edit(command.Reason, command.DiscountRate, command.StartDate.ToGeorgianDateTime(), command.EndDate.ToGeorgianDateTime(), command.ProductId);

            _customerDiscountRepository.SaveChanges();

            return operaton.Succeded();
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _customerDiscountRepository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountRepository.Search(searchModel);
        }
    }
}
