using Common.Models.DynamicObjects;
using Contracts.Utilities.DataShaper;
using Contracts.Utilities.Hateoas;
using Contracts.Utilities.Logger;
using Contracts.Utilities.Mapper;
using DTO.Output.Data;

namespace Contracts.Utilities
{
    public interface IUtilityServices
    {
        ILogService Logger { get; }

        IMappingService Mapper { get; }

        IHateoasService<CustomerDto> HateoasForCustomer { get; }

        IHateoasWithShaperService<BrandDto, ExpandoForXmlObject> HateoasShaperForBrand { get; }

        IDataShaperService<EmployeeDto, ExpandoForXmlObject> DataShaperForEmployee { get; }

        //IDataShaperService<CustomerDto, ExpandoForXmlObject> dataShaperCustomerService,

        IDataShaperService<ProductDto, ExpandoForXmlObject> DataShaperForProduct { get; }

        IDataShaperService<BrandDto, ExpandoForXmlObject> DataShaperForBrand { get; }
    }
}
