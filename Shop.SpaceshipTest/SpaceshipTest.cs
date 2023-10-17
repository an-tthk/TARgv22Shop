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
            Guid guid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");
            
            // kuidas teha automaatselt guidi??
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

            var result = await Svc<ISpaceshipServices>().GetAsync(guid);

            Assert.NotNull(result);
        }
    }
}
