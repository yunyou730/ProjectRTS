using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using rts.utils;
using UnityEngine;

namespace rts.chess
{
    public class World : IDisposable
    {
        private ChessInfo _chessInfo = null;
        private int _eidSeed = 0;
        
        private Dictionary<int, Entity> _entityMap = new Dictionary<int, Entity>();
        private Dictionary<string, Singleton> _singletonDict = new Dictionary<string, Singleton>();
        private List<System> _logicSystems = new List<System>();
        private List<System> _gfxSystems = new List<System>();
        
        public int LogicFPS { get; } = 15;
        public float LogicTimeSpan {
            get
            {
                return 1.0f / LogicFPS;
            }
        }
        
        private ILog _logger = null;
        
        public World(ILog logger)
        {
            _logger = logger;
        }
        
        public virtual void Dispose()
        {
            
        }
        
        public virtual void Initialize(ChessInfo chessInfo)
        {
            _chessInfo = chessInfo;
            RegisterSingletons();
            RegisterSystems();
        }
        
        protected void RegisterSingletons()
        {
            var setup = new SetupSingleton(this);
            setup.FillMapBaseInfo(_chessInfo._tileSize,_chessInfo._mapWidth,_chessInfo._mapHeight);
            _singletonDict.Add(nameof(SetupSingleton),setup);
        }
        
        protected void RegisterSystems()
        {
            _gfxSystems.Add(new GfxCreationSystem(this));
        }

        public T GetSingleton<T>(string singletonKey) where T : Singleton
        {
            T result = null;
            if (_singletonDict.ContainsKey(singletonKey))
            {
                result = _singletonDict[singletonKey] as T;
            }
            return result;
        }

        public int NextEid()
        {
            _eidSeed++;
            return _eidSeed;
        }

        public Entity CreateEntity()
        {
            Entity entity = new Entity(NextEid());
            return entity;
        }
        
        public void TickLogic()
        {
            foreach (var sys in _logicSystems)
            {
                sys.Tick();
            }
        }
        
        public void TickRender()
        {
            foreach (var sys in _gfxSystems)
            {
                sys.Tick();
            }
        }
    }
    


}
