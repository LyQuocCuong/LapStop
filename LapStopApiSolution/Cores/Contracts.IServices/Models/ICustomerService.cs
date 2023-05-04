﻿using DTO.Creation;
using DTO.Output;
using DTO.Update;

namespace Contracts.IServices.Models
{
    public interface ICustomerService
    {
        List<CustomerDto> GetAll(bool isTrackChanges);

        CustomerDto? GetOneById(bool isTrackChanges, Guid customerId);

        CustomerForUpdateDto GetDtoForPatch(Guid customerId);

        bool IsValidId(Guid customerId);

        CustomerDto Create(CustomerForCreationDto creationDto);

        void Update(Guid customerId, CustomerForUpdateDto updateDto);

    }
}
