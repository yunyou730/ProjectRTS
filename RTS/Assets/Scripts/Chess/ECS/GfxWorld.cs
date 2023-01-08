using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace rts.chess
{
    public class GfxWorld : World
    {
        void RegisterSystems()
        {
            base.RegisterSystems();

            var gfxCreationSys = new GfxCreationSystem(this);
        }

        void Dispose()
        {
            
        }
    }
}
