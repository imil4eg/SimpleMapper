using System;

namespace SimpleMapper.Tests
{
    public sealed class DestinationModel
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }

        public InternalDestinationModel Model { get; set; }
    }
}
