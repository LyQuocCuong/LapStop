using Common.Models.DynamicObjects;
using Contracts.Utilities;
using Contracts.Utilities.DataShaper;
using Contracts.Utilities.Hateoas;
using Contracts.Utilities.Logger;
using Contracts.Utilities.Mapper;

namespace Utilities
{
    public sealed class UtilityServices : IUtilityServices
    {
        private readonly ILogService _logService;
        private readonly IMappingService _mappingService;

        private readonly IHateoasService<CustomerDto> _hateoasForCustomer;
        private readonly IHateoasWithShaperService<BrandDto, ExpandoForXmlObject> _hateoasShaperForBrand;
        private readonly IDataShaperService<EmployeeDto, ExpandoForXmlObject> _dataShaperForEmployee;
        private readonly IDataShaperService<ProductDto, ExpandoForXmlObject> _dataShaperForProduct;
        private readonly IDataShaperService<BrandDto, ExpandoForXmlObject> _dataShaperForBrand;

        public UtilityServices(ILogService logService, IMappingService mappingService,
                                IHateoasService<CustomerDto> hateoasForCustomer,
                                IHateoasWithShaperService<BrandDto, ExpandoForXmlObject> hateoasShaperForBrand,
                                IDataShaperService<EmployeeDto, ExpandoForXmlObject> dataShaperForEmployee,
                                IDataShaperService<ProductDto, ExpandoForXmlObject> dataShaperForProduct,
                                IDataShaperService<BrandDto, ExpandoForXmlObject> dataShaperForBrand)
        {
            _logService = logService;
            _mappingService = mappingService;

            _hateoasForCustomer = hateoasForCustomer;
            _hateoasShaperForBrand = hateoasShaperForBrand;
            _dataShaperForEmployee = dataShaperForEmployee;
            _dataShaperForProduct = dataShaperForProduct;
            _dataShaperForBrand = dataShaperForBrand;
        }

        public ILogService Logger => _logService;

        public IMappingService Mapper => _mappingService;

        public IHateoasService<CustomerDto> HateoasForCustomer => _hateoasForCustomer;

        public IHateoasWithShaperService<BrandDto, ExpandoForXmlObject> HateoasShaperForBrand => _hateoasShaperForBrand;

        public IDataShaperService<EmployeeDto, ExpandoForXmlObject> DataShaperForEmployee => _dataShaperForEmployee;

        public IDataShaperService<ProductDto, ExpandoForXmlObject> DataShaperForProduct => _dataShaperForProduct;

        public IDataShaperService<BrandDto, ExpandoForXmlObject> DataShaperForBrand => _dataShaperForBrand;
    }
}
