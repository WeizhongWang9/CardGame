using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game.GameTerms
{
    /*
    public class ObjectInitializer<T> where T: InGameObject,IHandle
    {
        HandleManager<T> _handleManager;
        public HandleManager<T> handleManager { get { return _handleManager; } }
        public ObjectInitializer(HandleManager<T> handleManager)
        {
            this._handleManager = handleManager;
        }

        public ulong initialize(T obj)
        {
            obj.handle = _handleManager.assignObjectID(obj);
            return obj.handle;
        }

    }*/

    public class InGameObject : IHandle
    {
        public ulong handle;

        public ulong getHandle()
        {
            return handle;
        }
    }

}
