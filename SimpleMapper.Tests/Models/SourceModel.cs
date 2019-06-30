using System;

namespace SimpleMapper.Tests
{
    public sealed class SourceModel
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }

        public InternalSourceModel Model { get; set; }
    }
}
