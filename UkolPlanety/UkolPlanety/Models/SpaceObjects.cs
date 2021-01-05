using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace UkolPlanety.Models
{
    class SpaceObjects
    {
        public ObservableCollection<ASpaceObject> AllSpaceObjects { get; set; }

        public SpaceObjects()
        {
            AllSpaceObjects = new ObservableCollection<ASpaceObject>();
            AllSpaceObjects.Add(new ASpaceObject { Name = "Mercury", Size = 2439.7, Material = "Stone" });
            AllSpaceObjects.Add(new ASpaceObject { Name = "Venus", Size = 5728.1, Material = "Stone" });
            AllSpaceObjects.Add(new ASpaceObject { Name = "Earth", Size = 6378.1, Material = "Stone" });
            AllSpaceObjects.Add(new ASpaceObject { Name = "Mars", Size = 6792.4, Material = "Stone" });
            AllSpaceObjects.Add(new ASpaceObject { Name = "Jupiter", Size = 142984, Material = "Gas" });
            AllSpaceObjects.Add(new ASpaceObject { Name = "Saturn", Size = 120536, Material = "Gas" });
            AllSpaceObjects.Add(new ASpaceObject { Name = "Uran", Size = 51118, Material = "Liqiud" });
            AllSpaceObjects.Add(new ASpaceObject { Name = "Neptun", Size = 49128, Material = "Liquid" });
        }
    }
}
