using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public enum EntityType
    {
        Token=0,
        Vehicle,
        Storage,
        Product,
        DTC,
        Trip,
        Invoice,
        User,
        Log,
        Observer,
        DeviceLog,
        Subscription,
        Event,
        Mojio,
        App,
        AppApnCertificate,
        SMSEvents,
        MojioPrivate,
        UserPrivate,
        AppPrivate,
        VehiclePrivate,
        VehicleImage,
        MojioReport,
        MojioImage,
        UserImage,
        BaseServiceTask,
        DeviceStats,
        Access,
        AuthorizationToken,
        RefreshToken,
        Address,
        Location,
		SimCard,
        MojioConfiguration,
        MojioUpdate,
        Firmware,
        Operation,
        OperationData
    }
}
