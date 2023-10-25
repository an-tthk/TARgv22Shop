using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;

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
            var guid = new Guid("0946d4c2-f3d6-47c7-9322-acf061949331");
            //Arrange
            //old data from db
            Spaceship spaceship = new Spaceship();

            //new data
            SpaceshipDto dto = MockSpaceshipData();

            spaceship.Id = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");
            spaceship.Name = "asd";
            spaceship.Type = "asdasd";
            spaceship.Passengers = 123123;
            spaceship.EnginePower = 987654;
            spaceship.Crew = 123;
            spaceship.Company = "Company asd";
            spaceship.CargoWeight = 567;
            spaceship.CreatedAt = DateTime.Now.AddYears(1);
            spaceship.ModifiedAt = DateTime.Now.AddYears(1);

            //Act
            await Svc<ISpaceshipServices>().Update(dto);

            //Assert
            Assert.Equal(spaceship.Id, guid);
            Assert.NotEqual(spaceship.EnginePower, dto.EnginePower);
            Assert.Equal(spaceship.Crew, dto.Crew);
            Assert.DoesNotMatch(spaceship.Passengers.ToString(), dto.Passengers.ToString());
        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateDataVersion2()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipServices>().Create(dto);

            SpaceshipDto update = MockUpdateSpaceshipData();
            var updateSpaceship = await Svc<ISpaceshipServices>().Update(update);

            ///error korda teha
            Assert.Matches(updateSpaceship.Name, createSpaceship.Name);
            Assert.NotEqual(updateSpaceship.EnginePower, createSpaceship.EnginePower);
            Assert.NotEqual(updateSpaceship.Crew, createSpaceship.Crew);
            Assert.DoesNotMatch(updateSpaceship.Passengers.ToString(), createSpaceship.Passengers.ToString());
        }

        [Fact]
        public async Task ShouldNot_UpdateSpaceship_WhenNotUpdateData()
        {
            SpaceshipDto dto = MockSpaceshipData();
            await Svc<ISpaceshipServices>().Create(dto);

            SpaceshipDto nullUpdate = MockNullSpaceship();
            await Svc<ISpaceshipServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.True(dto.Id == nullId);
        }

        private SpaceshipDto MockNullSpaceship()
        {
            return new SpaceshipDto()
            {
                Id = null,
                Name = "Name123",
                Type = "type123",
                Passengers = 123,
                EnginePower = 123,
                Crew = 123,
                Company = "Company123",
                CargoWeight = 123,
                CreatedAt = DateTime.Now.AddYears(1),
                ModifiedAt = DateTime.Now.AddYears(1),
            };
        }

        private SpaceshipDto MockUpdateSpaceshipData()
        {
            return new SpaceshipDto()
            {
                Name = "asd123",
                Type = "asd",
                Passengers = 123456,
                EnginePower = 123456,
                Crew = 123456,
                Company = "asdasdasd",
                CargoWeight = 123456,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
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
                CargoWeight = 123,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
        }
    }
}
