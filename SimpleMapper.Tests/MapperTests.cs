using System;
using NUnit.Framework;

namespace SimpleMapper.Tests
{
    [TestFixture]
    public sealed class MapperTests
    {
        private Mapper _mapper;
        private SourceModel _sourceModel;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mapper = new Mapper();
            _mapper.Configurate<SourceModel, DestinationModel>();
            _mapper.Configurate<InternalSourceModel, InternalDestinationModel>();

            _sourceModel = new SourceModel();
        }

        [TearDown]
        public void CleanUp()
        {
            _sourceModel = new SourceModel();
        }

        public SourceModel FullFillModel()
        {
            return new SourceModel
            {
                Id = Guid.NewGuid(),
                Number = 1,
                Description = "model",
                Model = new InternalSourceModel
                {
                    Id = Guid.NewGuid(),
                    Number = 2,
                    Description = "internal model"
                }
            };
        }

        [Test]
        public void Map_MappingSourceModelOnDestination_ShouldSetIdField()
        {
            // Arrange
            _sourceModel = this.FullFillModel();

            // Act
            var mappedModel = _mapper.Map<SourceModel, DestinationModel>(_sourceModel);

            // Assert
            Assert.AreEqual(_sourceModel.Id, mappedModel.Id);
        }

        [Test]
        public void Map_MappingSourceModelOnDestination_ShouldSetNumberField()
        {
            // Arrange
            _sourceModel = this.FullFillModel();

            // Act
            var mappedModel = _mapper.Map<SourceModel, DestinationModel>(_sourceModel);

            // Assert
            Assert.AreEqual(_sourceModel.Number, mappedModel.Number);
        }

        [Test]
        public void Map_MappingSourceModelOnDestination_ShouldSetDescriptionField()
        {
            // Arrange
            _sourceModel = this.FullFillModel();

            // Act
            var mappedModel = _mapper.Map<SourceModel, DestinationModel>(_sourceModel);

            // Assert
            Assert.AreEqual(_sourceModel.Id, mappedModel.Id);
        }

        [Test]
        public void Map_MappingSourceModelOnDestination_ModelShouldNotBeNull()
        {
            // Arrange
            _sourceModel = this.FullFillModel();

            // Act
            var mappedModel = _mapper.Map<SourceModel, DestinationModel>(_sourceModel);

            // Assert
            Assert.NotNull(mappedModel.Model);
        }

        [Test]
        public void Map_MappingSourceModelOnDestination_ShouldSetModelsFieldIdField()
        {
            // Arrange
            _sourceModel = this.FullFillModel();

            // Act
            var mappedModel = _mapper.Map<SourceModel, DestinationModel>(_sourceModel);

            // Assert
            Assert.AreEqual(_sourceModel.Model.Id, mappedModel.Model.Id);
        }

        [Test]
        public void Map_MappingSourceModelOnDestination_ShouldSetModelsFieldNumberField()
        {
            // Arrange
            _sourceModel = this.FullFillModel();

            // Act
            var mappedModel = _mapper.Map<SourceModel, DestinationModel>(_sourceModel);

            // Assert
            Assert.AreEqual(_sourceModel.Model.Number, mappedModel.Model.Number);
        }

        [Test]
        public void Map_MappingSourceModelOnDestination_ShouldSetModelsFieldDescriptionField()
        {
            // Arrange
            _sourceModel = this.FullFillModel();

            // Act
            var mappedModel = _mapper.Map<SourceModel, DestinationModel>(_sourceModel);

            // Assert
            Assert.AreEqual(_sourceModel.Model.Description, mappedModel.Model.Description);
        }
    }
}
