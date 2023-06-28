using Common.Models.DynamicObjects;
using Contracts.Utilities.DataShaper;
using Contracts.Utilities.Hateoas;
using Contracts.Utilities.Logger;
using Contracts.Utilities.Mapper;
using DTO.Output.Data;

namespace Contracts.Utilities
{
    public sealed class UtilityServiceManager
    {
        public UtilityServiceManager(ILogService logger, IMappingService mapper,
                                IHateoasService<CustomerDto> hateoasForCustomer,
                                IHateoasWithShaperService<BrandDto, ExpandoForXmlObject> hateoasShaperForBrand,
                                IDataShaperService<EmployeeDto, ExpandoForXmlObject> dataShaperForEmployee,
                                IDataShaperService<ProductDto, ExpandoForXmlObject> dataShaperForProduct,
                                IDataShaperService<BrandDto, ExpandoForXmlObject> dataShaperForBrand)
        {
            Logger = logger;
            Mapper = mapper;
            HateoasForCustomer = hateoasForCustomer;
            HateoasShaperForBrand = hateoasShaperForBrand;
            DataShaperForEmployee = dataShaperForEmployee;
            DataShaperForProduct = dataShaperForProduct;
            DataShaperForBrand = dataShaperForBrand;
        }

        public readonly ILogService Logger;

        public readonly IMappingService Mapper;

        public readonly IHateoasService<CustomerDto> HateoasForCustomer;

        public readonly IHateoasWithShaperService<BrandDto, ExpandoForXmlObject> HateoasShaperForBrand;

        public readonly IDataShaperService<EmployeeDto, ExpandoForXmlObject> DataShaperForEmployee;

        //IDataShaperService<CustomerDto, ExpandoForXmlObject> dataShaperCustomerService,

        public readonly IDataShaperService<ProductDto, ExpandoForXmlObject> DataShaperForProduct;

        public readonly IDataShaperService<BrandDto, ExpandoForXmlObject> DataShaperForBrand;
    }
}
