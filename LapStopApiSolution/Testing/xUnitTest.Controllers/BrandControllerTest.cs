using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RestfulApiHandler.Controllers;
using Shared.CustomModels.DynamicObjects;
using xUnitTest.Controllers.Roots;

namespace xUnitTest.Controllers
{
    public class BrandControllerTest : RootControllerTest
    {
        private readonly BrandController _brandController;
        private readonly List<BrandDto> _brandList;
        private readonly Mock<IValidator<BrandForCreationDto>> creationValidator = new Mock<IValidator<BrandForCreationDto>>();

        public BrandControllerTest()
        {
            _brandController = new BrandController(_mockLogService.Object, 
                                                   _mockServiceManager.Object);
            _brandList = new List<BrandDto>()
            {
                new BrandDto()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    Name = "Adidas",
                    Description = "Adidas",
                    AvatarUrl = ""
                },
                new BrandDto()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    Name = "Nike",
                    Description = "Nike",
                    AvatarUrl = ""
                },
                new BrandDto()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    Name = "Yonex",
                    Description = "Yonex",
                    AvatarUrl = ""
                }
            };
        }

        [Fact]
        public async Task GetAllBrands_ActionExecuted_ReturnsAllItems()
        {
            //// Arrange
            //BrandParameters defaultParams = new BrandParameters();

            //PagedList<ShapedModel> pagedResult = new PagedList<ShapedModel>
            //    (
            //    _brandList, 100, 1, 10
            //    );

            //_mockServiceManager
            //    .Setup(s => s.Brand.GetAllAsync(defaultParams))
            //    .ReturnsAsync(pagedResult);

            ////Act
            //var okResult = await _brandController.GetAllBrands(defaultParams) as OkObjectResult;

            ////Assert
            //Assert.NotNull(okResult);
            ////=> Cast Type when SUCCESSFUL
            //var resultList = Assert.IsType<List<BrandDto>>(okResult.Value);
            //Assert.Equal(_brandList.Count(), resultList.Count());
        }

        [Fact]
        public async Task GetAllBrands_ActionExecuted_ReturnsOkObjectResult()
        {
            //// Arrange
            //await _mockServiceManager
            //    .Setup(s => s.Brand.GetAllAsync())
            //    .Returns(_brandList);

            ////Act
            //var result = _brandController.GetAllBrands();

            //// Assert
            //Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetBrandById_UnknownBrandIdPassed_ReturnsNotFoundResult()
        {
            //Arrange
            Guid unknownBrandId = Guid.NewGuid();

            _mockServiceManager
                .Setup(s => s.Brand.GetOneByIdAsync(unknownBrandId))
                .ReturnsAsync(null as BrandDto);

            //Action
            var result = await _brandController.GetBrandById(unknownBrandId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetBrandById_ExistingBrandIdPassed_ReturnOkObjectResult()
        {
            //Arrange
            Guid existingBrandId = new Guid("00000000-0000-0000-0000-000000000001");

            _mockServiceManager
                .Setup(s => s.Brand.GetOneByIdAsync(existingBrandId))
                .ReturnsAsync(_brandList.FirstOrDefault(b => b.Id == existingBrandId));

            //Act
            var result = await _brandController.GetBrandById(existingBrandId);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetBrandById_ExistingBrandIdPassed_ReturnsRightItem()
        {
            //Arrange
            Guid existingBrandId = new Guid("00000000-0000-0000-0000-000000000001");

            _mockServiceManager
                .Setup(s => s.Brand.GetOneByIdAsync(existingBrandId))
                .ReturnsAsync(_brandList.FirstOrDefault(b => b.Id == existingBrandId));

            //Act
            var result = await _brandController.GetBrandById(existingBrandId) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            BrandDto brand = Assert.IsType<BrandDto>(result.Value);
            Assert.Equal(existingBrandId, brand.Id);
            //OR:
            //Assert.Equal(existingBrandId, (result.Value as BrandDto).Id);
        }

        [Fact]
        public async Task Create_InvalidObjectPassed_ReturnsUnprocessableEntity()
        {
            ////Arrange
            //BrandForCreationDto nameMissingBrand = new BrandForCreationDto()
            //{
            //    Description = "Test"
            //};
            //_brandController.ModelState.AddModelError("Name", "Required");

            ////Act
            //var result = await _brandController.CreateBrand(creationValidator, nameMissingBrand);

            ////Assert
            //Assert.IsType<UnprocessableEntityObjectResult>(result);
        }

        [Fact]
        public void Create_NullObjectPassed_ReturnsBadRequest()
        {
            ////Arrange

            ////Act
            //var result = _brandController.CreateBrand(null);

            ////Assert
            //Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Create_ValidObjectPassed_ReturnsCreatedResponse()
        {
            ////Arrange
            //Guid newBrandId = new Guid("00000000-0000-0000-0000-000000000011");

            //BrandForCreationDto creationDto = new BrandForCreationDto()
            //{
            //    Name = "Test",
            //    Description = "Test",
            //    AvatarUrl = ""
            //};

            //_mockServiceManager
            //    .Setup(s => s.Brand.Create(creationDto))
            //    .Returns(new BrandDto()
            //    {
            //        Id = newBrandId,
            //        Name = "Test",
            //        Description = "Test",
            //        AvatarUrl = ""
            //    });

            ////Act
            //var result = _brandController.CreateBrand(creationDto);

            ////Assert
            //Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public void Create_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            ////Arrange
            //Guid newBrandId = new Guid("00000000-0000-0000-0000-000000000011");

            //BrandForCreationDto creationDto = new BrandForCreationDto()
            //{
            //    Name = "Test",
            //    Description = "Test",
            //    AvatarUrl = ""
            //};

            //_mockServiceManager
            //    .Setup(s => s.Brand.Create(creationDto))
            //    .Returns(new BrandDto()
            //    {
            //        Id = newBrandId,
            //        Name = "Test",
            //        Description = "Test",
            //        AvatarUrl = ""
            //    });

            ////Act
            //var result = _brandController.CreateBrand(creationDto) as CreatedAtRouteResult;

            ////Assert
            //Assert.NotNull(result);
            //var createdBrand = Assert.IsType<BrandDto>(result.Value);
            //Assert.Equal(newBrandId, createdBrand.Id);
        }

        [Fact]
        public void Update_InvalidObjectPassed_ReturnsUnprocessableEntity()
        {
            ////Arrange
            //Guid brandId = _brandList.FirstOrDefault().Id;
            //BrandForUpdateDto updateDto = new BrandForUpdateDto()
            //{
            //    Description = "Test",
            //};
            //_brandController.ModelState.AddModelError("Name", "required");

            //// Act
            //var result = _brandController.UpdateBrand(brandId, updateDto);

            ////Assert
            //Assert.IsType<UnprocessableEntityObjectResult>(result);
        }

        [Fact]
        public void Update_NullObjectPassed_ReturnsBadRequest()
        {
            ////Arrange
            //Guid existingBrandId = new Guid("00000000-0000-0000-0000-000000000001");

            ////Act
            //var result = _brandController.UpdateBrand(existingBrandId, null);

            ////Assert
            //Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Update_UnknownBrandIdPassed_ReturnsNotFoundResult()
        {
            ////Arrange
            //Guid unknownBrandId = Guid.NewGuid();

            //BrandForUpdateDto updateDto = new BrandForUpdateDto()
            //{
            //    Name = "Adidas",
            //    Description = "Adidas",
            //    AvatarUrl = ""
            //};

            //_mockServiceManager
            //    .Setup(s => s.Brand.IsValidId(unknownBrandId));

            ////Act
            //var result = _brandController.UpdateBrand(unknownBrandId, updateDto);

            ////Assert
            //Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Update_ValidObjectPassed_ReturnsNoContent()
        {
            ////Arrange
            //Guid existingBrandId = new Guid("00000000-0000-0000-0000-000000000001");

            //BrandForUpdateDto updateDto = new BrandForUpdateDto()
            //{
            //    Name = "Test",
            //    Description = "Test",
            //    AvatarUrl = ""
            //};

            //_mockServiceManager
            //    .Setup(s => s.Brand.IsValidId(existingBrandId))
            //    .Returns(true);

            //_mockServiceManager
            //    .Setup(s => s.Brand.Update(existingBrandId, updateDto));

            ////Act
            //var result = _brandController.UpdateBrand(existingBrandId, updateDto);

            ////Assert
            //Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdatePartially_InvalidObjectPassed_ReturnsUnprocessableEntity()
        {
            //Arrange
            Guid brandId = _brandList.FirstOrDefault()!.Id;
            var patchDocument = new JsonPatchDocument<BrandForUpdateDto>();
            patchDocument.Replace(b => b.Name, null);  // Name can NOT be NULL

            _mockServiceManager
                .Setup(s => s.Brand.IsValidIdAsync(brandId))
                .ReturnsAsync(true);

            _mockServiceManager
                .Setup(s => s.Brand.GetDtoForPatchAsync(brandId))
                .ReturnsAsync(new BrandForUpdateDto()
                {
                    Name = "Addidas",
                    Description = "Test"
                });

            //Act
            var result = await _brandController.UpdateBrandPartially(brandId, patchDocument);

            //Assert
            Assert.IsType<UnprocessableEntityObjectResult>(result);
        }

        [Fact]
        public async Task UpdatePartially_UnknownBrandIdPassed_ReturnsNotFoundResult()
        {
            //Arrange
            var patchDocument = new JsonPatchDocument<BrandForUpdateDto>();
            patchDocument.Replace(b => b.Name, "Yonex");

            Guid brandId = Guid.NewGuid();

            _mockServiceManager
                .Setup(s => s.Brand.IsValidIdAsync(brandId))
                .ReturnsAsync(false);

            //Act
            var result = await _brandController.UpdateBrandPartially(brandId, patchDocument);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdatePartially_NullObjectPassed_ReturnsBadRequest()
        {
            //Arrange
            Guid brandId = _brandList.FirstOrDefault()!.Id;

            _mockServiceManager
                .Setup(s => s.Brand.IsValidIdAsync(brandId))
                .ReturnsAsync(false);

            //Act
            var result = await _brandController.UpdateBrandPartially(brandId, null);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdatePartially_ValidObjectPassed_ReturnsNoContent()
        {
            //Arrange
            var patchDocument = new JsonPatchDocument<BrandForUpdateDto>();
            patchDocument.Replace(b => b.Name, "Yonex");

            //brandId
            Guid brandId = _brandList.FirstOrDefault()!.Id;
            _mockServiceManager
                .Setup(s => s.Brand.IsValidIdAsync(brandId))
                .ReturnsAsync(true);

            //updateDto
            BrandForUpdateDto updateDto = new BrandForUpdateDto()
            {
                Name = "Addidas",
                Description = "Addidas"
            };
            var x = _mockServiceManager
                .Setup(s => s.Brand.GetDtoForPatchAsync(brandId))
                .ReturnsAsync(updateDto);

            //update method
            _mockServiceManager
                .Setup(s => s.Brand.UpdateAsync(brandId, updateDto));

            //Act
            var result = await _brandController.UpdateBrandPartially(brandId, patchDocument);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_UnknownBrandIdPassed_ReturnsNotFoundResult()
        {
            //Arrange
            Guid unknownBrandId = Guid.NewGuid();

            _mockServiceManager
                .Setup(s => s.Brand.IsValidIdAsync(unknownBrandId))
                .ReturnsAsync(false);

            //Act
            var result = await _brandController.DeleteBrand(unknownBrandId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_UnknownBrandIdPassed_DeleteEmployeeNeverExecuted()
        {
            //Arrange
            Guid unknownBrandId = Guid.NewGuid();

            _mockServiceManager
                .Setup(s => s.Brand.IsValidIdAsync(unknownBrandId))
                .ReturnsAsync(false);

            //Act
            var result = await _brandController.DeleteBrand(unknownBrandId);

            //Assert
            _mockServiceManager
                .Verify(s => s.Brand.DeleteAsync(unknownBrandId), Times.Never);
        }

        [Fact]
        public async Task Delete_ExistingBrandIdPassed_ReturnsNoContentResult()
        {
            //Arrange
            Guid existingBrandId = _brandList.FirstOrDefault()!.Id;

            _mockServiceManager
                .Setup(s => s.Brand.IsValidIdAsync(existingBrandId))
                .ReturnsAsync(true);

            _mockServiceManager
                .Setup(s => s.Brand.DeleteAsync(existingBrandId));

            //Act
            var result = await _brandController.DeleteBrand(existingBrandId);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ExistingBrandIdPassed_DeleteEmployeeCalledOne()
        {
            //Arrange
            Guid existingBrandId = _brandList.FirstOrDefault()!.Id;

            _mockServiceManager
                .Setup(s => s.Brand.IsValidIdAsync(existingBrandId))
                .ReturnsAsync(true);

            _mockServiceManager
                .Setup(s => s.Brand.DeleteAsync(existingBrandId));
                      
            //Act
            var result = await _brandController.DeleteBrand(existingBrandId);

            //Assert
            _mockServiceManager
                .Verify(s => s.Brand.DeleteAsync(existingBrandId), Times.Once);

            Assert.IsType<NoContentResult>(result); 
        }

    }
}
