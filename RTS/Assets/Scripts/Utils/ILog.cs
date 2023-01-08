using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using rts.mgr;

namespace rts.utils
{
    public interface ILog
    {
        public void Log(string catalog, string log);
    }
}
