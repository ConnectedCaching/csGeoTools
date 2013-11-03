using csGeoTools.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csGeoTools.Contracts
{
    abstract class GeocacheBase
    {
        String Id;
        String Name;
        String PlacedBy;
        User Owner;
        CacheSize Size;
        Double Difficulty;
        Double Terrain;

    }
}
