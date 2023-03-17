using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Dtos;
using GenFu;
using Moq;
using Ports.Output;
using Presenters.Interfaces;
using Presenters.Presenters;
using UseCases.UseCases;

namespace UseCaseLayerTests
{
    public class GetAllPeopleUseCaseTests
    {

        [Fact]
        public async Task GetAllPeople_ThereArePeopleSaved_ReturnListPeople()
        {
            // Arrange
            var mockPersonRepository = new Mock<IPersonRepository>();
            IGetAllPeopleOutputPort output = new GetAllPeoplePresenter();

            var people = A.ListOf<Person>(20);

            // Act
            mockPersonRepository.Setup(p => p.GetAll()).ReturnsAsync(people);

            var useCase = new GetAllPeopleUseCase(mockPersonRepository.Object, output);

            await useCase.GetAllPeopleHandle();
            var response = ((IPresenter<List<PersonViewDto>>)output).Content;

            // Assert
            Assert.Equal(20, response!.Count);
        }

        [Fact]
        public async Task GetAllPeople_ThereAreNotPeopleSaved_ReturnEmptyList()
        {
            // Arrange
            var mockPersonRepository = new Mock<IPersonRepository>();
            IGetAllPeopleOutputPort output = new GetAllPeoplePresenter();

            // Act
            mockPersonRepository.Setup(p => p.GetAll());

            var useCase = new GetAllPeopleUseCase(mockPersonRepository.Object, output);

            await useCase.GetAllPeopleHandle();
            var response = ((IPresenter<List<PersonViewDto>>)output).Content;

            // Assert
            Assert.Empty(response!);
        }
    }
}