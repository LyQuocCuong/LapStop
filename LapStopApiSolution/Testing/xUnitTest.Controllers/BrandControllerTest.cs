using DTO.Creation;
using DTO.Output;
using DTO.Update;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using RestfulApiHandler.Controllers;
using Xunit;
using xUnitTest.Controllers.Base;

namespace xUnitTest.Controllers
{
    public class BrandControllerTest : BaseControllerTest
    {
        private readonly BrandController _brandController;
        private readonly List<BrandDto> _brandList;

        public BrandControllerTest()
        {
            _brandController = new BrandController(_mockLogService.Object, _mockServiceManager.Object);
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
        public void GetAllBrands_ActionExecuted_ReturnsAllItems()
        {
            // Arrange
            _mockServiceManager
                .Setup(s => s.Brand.GetAll())
                .Returns(_brandList);

            //Act
            var okResult = _brandController.GetAllBrands() as OkObjectResult;

            //Assert
            Assert.NotNull(okResult);
            //Cast Type when SUCCESSFUL
            var resultList = Assert.IsType<List<BrandDto>>(okResult.Value);
            Assert.Equal(_brandList.Count(), resultList.Count());
        }

        [Fact]
        public void GetAllBrands_ActionExecuted_ReturnsOkObjectResult()
        {
            // Arrange
            _mockServiceManager
                .Setup(s => s.Brand.GetAll())
                .Returns(_brandList);

            //Act
            var result = _brandController.GetAllBrands();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetBrandById_UnknownBrandIdPassed_ReturnsNotFoundResult()
        {
            //Arrange
            Guid unknownBrandId = Guid.NewGuid();

            _mockServiceManager
                .Setup(s => s.Brand.GetOneById(unknownBrandId))
                .Returns((BrandDto)null);

            //Action
            var result = _brandController.GetBrandById(unknownBrandId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetBrandById_ExistingBrandIdPassed_ReturnOkObjectResult()
        {
            //Arrange
            Guid existingBrandId = new Guid("00000000-0000-0000-0000-000000000001");

            _mockServiceManager
                .Setup(s => s.Brand.GetOneById(existingBrandId))
                .Returns(_brandList.FirstOrDefault(b => b.Id == existingBrandId));

            //Act
            var result = _brandController.GetBrandById(existingBrandId);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetBrandById_ExistingBrandIdPassed_ReturnsRightItem()
        {
            //Arrange
            Guid existingBrandId = new Guid("00000000-0000-0000-0000-000000000001");

            _mockServiceManager
                .Setup(s => s.Brand.GetOneById(existingBrandId))
                .Returns(_brandList.FirstOrDefault(b => b.Id == existingBrandId));

            //Act
            var result = _brandController.GetBrandById(existingBrandId) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            BrandDto brand = Assert.IsType<BrandDto>(result.Value);
            Assert.Equal(existingBrandId, brand.Id);
            //OR:
            //Assert.Equal(existingBrandId, (result.Value as BrandDto).Id);
        }

        [Fact]
        public void Create_InvalidObjectPassed_ReturnsUnprocessableEntity()
        {
            //Arrange
            BrandForCreationDto nameMissingBrand = new BrandForCreationDto()
            {
                Description = "Test"
            };
            _brandController.ModelState.AddModelError("Name", "Required");

            //Act
            var result = _brandController.CreateBrand(nameMissingBrand);

            //Assert
            Assert.IsType<UnprocessableEntityObjectResult>(result);
        }

        [Fact]
        public void Create_NullObjectPassed_ReturnsBadRequest()
        {
            //Arrange

            //Act
            var result = _brandController.CreateBrand(null);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Create_ValidObjectPassed_ReturnsCreatedResponse()
        {
            //Arrange
            Guid newBrandId = new Guid("00000000-0000-0000-0000-000000000011");

            BrandForCreationDto creationDto = new BrandForCreationDto()
            {
                Name = "Test",
                Description = "Test",
                AvatarUrl = ""
            };

            _mockServiceManager
                .Setup(s => s.Brand.Create(creationDto))
                .Returns(new BrandDto()
                {
                    Id = newBrandId,
                    Name = "Test",
                    Description = "Test",
                    AvatarUrl = ""
                });

            //Act
            var result = _brandController.CreateBrand(creationDto);

            //Assert
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public void Create_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            //Arrange
            Guid newBrandId = new Guid("00000000-0000-0000-0000-000000000011");

            BrandForCreationDto creationDto = new BrandForCreationDto()
            {
                Name = "Test",
                Description = "Test",
                AvatarUrl = ""
            };

            _mockServiceManager
                .Setup(s => s.Brand.Create(creationDto))
                .Returns(new BrandDto()
                {
                    Id = newBrandId,
                    Name = "Test",
                    Description = "Test",
                    AvatarUrl = ""
                });

            //Act
            var result = _brandController.CreateBrand(creationDto) as CreatedAtRouteResult;

            //Assert
            Assert.NotNull(result);
            var createdBrand = Assert.IsType<BrandDto>(result.Value);
            Assert.Equal(newBrandId, createdBrand.Id);
        }

        [Fact]
        public void Update_InvalidObjectPassed_ReturnsUnprocessableEntity()
        {
            //Arrange
            Guid brandId = _brandList.FirstOrDefault().Id;
            BrandForUpdateDto updateDto = new BrandForUpdateDto()
            {
                Description = "Test",
            };
            _brandController.ModelState.AddModelError("Name", "required");

            // Act
            var result = _brandController.UpdateBrand(brandId, updateDto);

            //Assert
            Assert.IsType<UnprocessableEntityObjectResult>(result);
        }

        [Fact]
        public void Update_NullObjectPassed_ReturnsBadRequest()
        {
            //Arrange
            Guid existingBrandId = new Guid("00000000-0000-0000-0000-000000000001");

            //Act
            var result = _brandController.UpdateBrand(existingBrandId, null);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Update_UnknownBrandIdPassed_ReturnsNotFoundResult()
        {
            //Arrange
            Guid unknownBrandId = Guid.NewGuid();

            BrandForUpdateDto updateDto = new BrandForUpdateDto()
            {
                Name = "Adidas",
                Description = "Adidas",
                AvatarUrl = ""
            };

            _mockServiceManager
                .Setup(s => s.Brand.IsValidId(unknownBrandId));

            //Act
            var result = _brandController.UpdateBrand(unknownBrandId, updateDto);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Update_ValidObjectPassed_ReturnsNoContent()
        {
            //Arrange
            Guid existingBrandId = new Guid("00000000-0000-0000-0000-000000000001");

            BrandForUpdateDto updateDto = new BrandForUpdateDto()
            {
                Name = "Test",
                Description = "Test",
                AvatarUrl = ""
            };

            _mockServiceManager
                .Setup(s => s.Brand.IsValidId(existingBrandId))
                .Returns(true);

            _mockServiceManager
                .Setup(s => s.Brand.Update(existingBrandId, updateDto));

            //Act
            var result = _brandController.UpdateBrand(existingBrandId, updateDto);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdatePartially_InvalidObjectPassed_ReturnsUnprocessableEntity()
        {
            //Arrange
            Guid brandId = _brandList.FirstOrDefault().Id;
            var patchDocument = new JsonPatchDocument<BrandForUpdateDto>();
            patchDocument.Replace(b => b.Name, null);  // Name can NOT be NULL

            _mockServiceManager
                .Setup(s => s.Brand.IsValidId(brandId))
                .Returns(true);

            _mockServiceManager
                .Setup(s => s.Brand.GetDtoForPatch(brandId))
                .Returns(new BrandForUpdateDto()
                {
                    Name = "Addidas",
                    Description = "Test"
                });

            //Act
            var result =_brandController.UpdateBrandPartially(brandId, patchDocument);

            //Assert
            Assert.IsType<UnprocessableEntityObjectResult>(result);
        }

        [Fact]
        public void UpdatePartially_UnknownBrandIdPassed_ReturnsNotFoundResult()
        {
            //Arrange
            var patchDocument = new JsonPatchDocument<BrandForUpdateDto>();
            patchDocument.Replace(b => b.Name, "Yonex");

            Guid brandId = Guid.NewGuid();

            _mockServiceManager
                .Setup(s => s.Brand.IsValidId(brandId))
                .Returns(false);

            //Act
            var result = _brandController.UpdateBrandPartially(brandId, patchDocument);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdatePartially_NullObjectPassed_ReturnsBadRequest()
        {
            //Arrange
            Guid brandId = _brandList.FirstOrDefault().Id;

            _mockServiceManager
                .Setup(s => s.Brand.IsValidId(brandId))
                .Returns(false);

            //Act
            var result = _brandController.UpdateBrandPartially(brandId, null);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdatePartially_ValidObjectPassed_ReturnsNoContent()
        {
            //Arrange
            var patchDocument = new JsonPatchDocument<BrandForUpdateDto>();
            patchDocument.Replace(b => b.Name, "Yonex");

            //brandId
            Guid brandId = _brandList.FirstOrDefault().Id;
            _mockServiceManager
                .Setup(s => s.Brand.IsValidId(brandId))
                .Returns(true);

            //updateDto
            BrandForUpdateDto updateDto = new BrandForUpdateDto()
            {
                Name = "Addidas",
                Description = "Addidas"
            };
            var x = _mockServiceManager
                .Setup(s => s.Brand.GetDtoForPatch(brandId))
                .Returns(updateDto);

            //update method
            _mockServiceManager
                .Setup(s => s.Brand.Update(brandId, updateDto));

            //Act
            var result = _brandController.UpdateBrandPartially(brandId, patchDocument);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_UnknownBrandIdPassed_ReturnsNotFoundResult()
        {
            //Arrange
            Guid unknownBrandId = Guid.NewGuid();

            _mockServiceManager
                .Setup(s => s.Brand.IsValidId(unknownBrandId))
                .Returns(false);

            //Act
            var result = _brandController.DeleteBrand(unknownBrandId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_UnknownBrandIdPassed_DeleteEmployeeNeverExecuted()
        {
            //Arrange
            Guid unknownBrandId = Guid.NewGuid();

            _mockServiceManager
                .Setup(s => s.Brand.IsValidId(unknownBrandId))
                .Returns(false);

            //Act
            var result = _brandController.DeleteBrand(unknownBrandId);

            //Assert
            _mockServiceManager
                .Verify(s => s.Brand.Delete(unknownBrandId), Times.Never);
        }

        [Fact]
        public void Delete_ExistingBrandIdPassed_ReturnsNoContentResult()
        {
            //Arrange
            Guid existingBrandId = _brandList.FirstOrDefault().Id;

            _mockServiceManager
                .Setup(s => s.Brand.IsValidId(existingBrandId))
                .Returns(true);

            _mockServiceManager
                .Setup(s => s.Brand.Delete(existingBrandId));

            //Act
            var result = _brandController.DeleteBrand(existingBrandId);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ExistingBrandIdPassed_DeleteEmployeeCalledOne()
        {
            //Arrange
            Guid existingBrandId = _brandList.FirstOrDefault().Id;

            _mockServiceManager
                .Setup(s => s.Brand.IsValidId(existingBrandId))
                .Returns(true);

            _mockServiceManager
                .Setup(s => s.Brand.Delete(existingBrandId));
                      
            //Act
            var result = _brandController.DeleteBrand(existingBrandId);

            //Assert
            _mockServiceManager
                .Verify(s => s.Brand.Delete(existingBrandId), Times.Once);

            Assert.IsType<NoContentResult>(result); 
        }

    }
}
