using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class SmoothChunkingMojioObserver : SmoothObserverBase
    {
        public SmoothChunkingMojioObserver()
            : base(ObserverType.SmoothChunkingMojio, typeof(Vehicle), typeof(Mojio), 1.0)
        {
            //Mapper.CreateMap<Vehicle, Vehicle>().ForMember(x => x.Id, opt => opt.Ignore());
        }
        public SmoothChunkingMojioObserver(double interpolationRate=1.0)
            : base(ObserverType.SmoothChunkingMojio, typeof(Vehicle), typeof(Mojio), interpolationRate)
        {
        }

        public SmoothChunkingMojioObserver(Guid mojioId, double interpolationRate = 1.0)
            : base(ObserverType.SmoothChunkingMojio,
                    typeof(Vehicle), 
                    typeof(Mojio),  
                    interpolationRate)
        {
            ParentId = mojioId;
        }
    }
}
