using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using rts.utils;
using UnityEngine;
using Debug = UnityEngine.Debug;


namespace rts.mgr
{
    public class LogManager : IDisposable,ILog
    {
        public void Dispose()
        {
            
        }

        public void Log(string catalog, string log)
        {
            Debug.Log("[" + catalog + "]" + log);
        }
    }
}
