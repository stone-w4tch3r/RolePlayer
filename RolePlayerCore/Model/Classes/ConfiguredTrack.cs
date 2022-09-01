using System;
using RolePlayerCore.Interfaces;

namespace RolePlayerCore.Model.Classes
{
	public record ConfiguredTrack : IConfiguredTrack
	{

        public ITrack Track { get; }

        public string Title { get; }

        public string Comment { get ; }
        public ISegment SegmentToPlay { get; }

		public ConfiguredTrack()
		{
		}
    }
}

