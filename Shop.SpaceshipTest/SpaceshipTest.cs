using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using System;

namespace Shop.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            SpaceshipDto dto = new SpaceshipDto();

            dto.Name = "Name";
            dto.Type = "Type";
            dto.Passengers = 123;
            dto.EnginePower = 123;
            dto.Crew = 123;
            dto.Company = "asd";
            dto.CargoWeight = 123;
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipServices>().Create(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotEqual()
        {
            //Arrange
            Guid guid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");
            // kuidas teha automaatselt guidi??
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

            //Act
            await Svc<ISpaceshipServices>().GetAsync(guid);

            //Assert
            Assert.Equal(guid, wrongGuid);
        }

        [Fact]
        public async Task Should_GetByIdSpaceship_WhenReturnsEqual()
        {
            //Arrange
            Guid databaseGuid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");
            Guid getGuid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");

            //Act
            await Svc<ISpaceshipServices>().GetAsync(getGuid);

            //Assert
            Assert.Equal(databaseGuid, getGuid);
        }

        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            //Arrange
            SpaceshipDto spaceship = MockSpaceshipData();

            //Act
            var addSpaceship = await Svc<ISpaceshipServices>().Create(spaceship);
            var result = await Svc<ISpaceshipServices>().Delete(spaceship.Id.GetValueOrDefault());

            //Assert
            Assert.Equal(result, addSpaceship);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();

            var addSpaceship = await Svc<ISpaceshipServices>().Create(spaceship);
            var addSpaceship2 = await Svc<ISpaceshipServices>().Create(spaceship);

            var result = await Svc<ISpaceshipServices>().Delete(addSpaceship2.Id.GetValueOrDefault());

            Assert.NotEqual(result.Id, addSpaceship.Id);
        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            Guid guid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");

            Spaceship spaceship = new Spaceship();
            
            SpaceshipDto dto = MockSpaceshipData();

            spaceship.Id = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");
            spaceship.Name = "asd";
            spaceship.Type = "asdasd";
            spaceship.Passengers = 123123;
            spaceship.EnginePower = 987654;
            spaceship.Crew = 567;
            spaceship.Company = "Company asd";
            spaceship.CargoWeight = 567;
            spaceship.CreatedAt = DateTime.Now.AddYears(1);
            spaceship.ModifiedAt = DateTime.Now.AddYears(1);

            await Svc<ISpaceshipServices>().Update(dto);

            Assert.Equal(spaceship.Id, guid);
            Assert.NotEqual(spaceship.Name, dto.Name);
            Assert.Equal(spaceship.Crew, dto.Crew);
            Assert.DoesNotMatch(spaceship.Passengers.ToString(), dto.Passengers.ToString());
        }

        private SpaceshipDto MockSpaceshipData()
        {
            return new SpaceshipDto()
            {
                //Id = Guid.NewGuid(),
                Name = "Name",
                Type = "Type",
                Passengers = 123,
                EnginePower = 123,
                Crew = 123,
                Company = "Company",
                CargoWeight = 123
            };
        }
    }
}
