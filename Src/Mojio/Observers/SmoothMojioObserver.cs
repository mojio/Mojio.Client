using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class SmoothMojioObserver : SmoothObserverBase
    {
        public SmoothMojioObserver()
            : base(ObserverType.SmoothMojio, typeof(Vehicle), typeof(Mojio), 1.0)
        {
            //Mapper.CreateMap<Vehicle, Vehicle>().ForMember(x => x.Id, opt => opt.Ignore());
        }
        public SmoothMojioObserver(double interpolationRate=1.0)
            : base(ObserverType.SmoothMojio, typeof(Vehicle), typeof(Mojio), interpolationRate)
        {
        }

        public SmoothMojioObserver(Guid mojioId, double interpolationRate = 1.0)
            : base(ObserverType.SmoothMojio,
                    typeof(Vehicle), 
                    typeof(Mojio),  
                    interpolationRate)
        {
            ParentId = mojioId;
        }
    }
}
