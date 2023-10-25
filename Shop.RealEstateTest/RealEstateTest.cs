using Shop.ApplicationServices.Services;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using System.Drawing;
using System.Xml;

namespace Shop.RealEstateTest
{
    public class RealEstateTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
        {
            RealEstateDto dto = MockRealEstateData();

            var result = await Svc<IRealEstateServices>().Create(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnsNotEqual()
        {
            //Arrange
            Guid guid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");
            // kuidas teha automaatselt guidi??
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

            //Act
            await Svc<IRealEstateServices>().GetAsync(guid);

            //Assert
            Assert.Equal(guid, wrongGuid);
        }

        [Fact]
        public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
        {
            //Arrange
            Guid databaseGuid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");
            Guid getGuid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");

            //Act
            await Svc<IRealEstateServices>().GetAsync(getGuid);

            //Assert
            Assert.Equal(databaseGuid, getGuid);
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            //Arrange
            RealEstateDto realestate = MockRealEstateData();

            //Act
            var addRealEstate = await Svc<IRealEstateServices>().Create(realestate);
            var result = await Svc<IRealEstateServices>().Delete(realestate.Id.GetValueOrDefault());

            //Assert
            Assert.Equal(result, addRealEstate);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            RealEstateDto realestate = MockRealEstateData();

            var addRealEstate = await Svc<IRealEstateServices>().Create(realestate);
            var addRealEstate2 = await Svc<IRealEstateServices>().Create(realestate);

            var result = await Svc<IRealEstateServices>().Delete(addRealEstate2.Id.GetValueOrDefault());

            Assert.NotEqual(result.Id, addRealEstate.Id);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {
            var guid = new Guid("0946d4c2-f3d6-47c7-9322-acf061949331");
            //Arrange
            //old data from db
            RealEstate realestate = new RealEstate();

            //new data
            RealEstateDto dto = MockRealEstateData();

            realestate.Id = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");
            realestate.Address = "Nameasd";
            realestate.SizeSqrtM = 123456f;
            realestate.RoomCount = 987654;
            realestate.Floor = 123123;
            realestate.BuildingType = "asd123";
            realestate.BuiltInYear = DateTime.Now.AddYears(-1);
            realestate.CreatedAt = DateTime.Now.AddYears(1);
            realestate.UpdatedAt = DateTime.Now.AddYears(1);


            //Act
            await Svc<IRealEstateServices>().Update(dto);

            //Assert
            Assert.Equal(realestate.Id, guid);
            Assert.NotEqual(realestate.RoomCount, dto.RoomCount);
            Assert.Equal(realestate.BuildingType, dto.BuildingType);
            Assert.DoesNotMatch(realestate.Floor.ToString(), dto.Floor.ToString());
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateDataVersion2()
        {
            RealEstateDto dto = MockRealEstateData();
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);

            RealEstateDto update = MockUpdateRealEstateData();
            var updateRealEstate = await Svc<IRealEstateServices>().Update(update);

            ///error korda teha
            Assert.Matches(updateRealEstate.Address, createRealEstate.Address);
            Assert.NotEqual(updateRealEstate.RoomCount, createRealEstate.RoomCount);
            Assert.NotEqual(updateRealEstate.BuildingType, createRealEstate.BuildingType);
            Assert.DoesNotMatch(updateRealEstate.Floor.ToString(), createRealEstate.Floor.ToString());
        }

        [Fact]
        public async Task ShouldNot_UpdateRealEstate_WhenNotUpdateData()
        {
            RealEstateDto dto = MockRealEstateData();
            await Svc<IRealEstateServices>().Create(dto);

            RealEstateDto nullUpdate = MockNullRealEstate();
            await Svc<IRealEstateServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.True(dto.Id == nullId);
        }

        private RealEstateDto MockNullRealEstate()
        {
            return new RealEstateDto()
            {
                Id = null,
                Address = "asd",
                SizeSqrtM = 123123f,
                RoomCount = 123123,
                Floor = 123123,
                BuildingType = "asdasd",
                BuiltInYear = DateTime.Now,
                CreatedAt = DateTime.Now.AddYears(1),
                UpdatedAt = DateTime.Now.AddYears(1),
            };
        }

        private RealEstateDto MockUpdateRealEstateData()
        {
            return new RealEstateDto()
            {
                Address = "asd",
                SizeSqrtM = 123123f,
                RoomCount = 123123,
                Floor = 123123,
                BuildingType = "asdasd",
                BuiltInYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
        }

        private RealEstateDto MockRealEstateData()
        {
            return new RealEstateDto()
            {
                Address = "Name",
                SizeSqrtM = 123f,
                RoomCount = 123,
                Floor = 123,
                BuildingType = "asd",
                BuiltInYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
        }
    }
}
