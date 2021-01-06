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
            AllSpaceObjects.Add(new ASpaceObject { IsHazerdious = false, Name = "Test", Size = 232, Speed = 11 });
        }
    }
}
