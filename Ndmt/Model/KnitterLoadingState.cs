using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ndmt.Model
{
    class KnitterLoadingState : IKnitterState
    {
        private KnitterEntity mKnitterEntitiy;
        private const string LOADING_STATE_STRING = "Loading";


        public KnitterLoadingState(KnitterEntity ke)
        {
            this.mKnitterEntitiy = ke;
        }
        
        public override string ToString()
        {
            return KnitterLoadingState.LOADING_STATE_STRING;
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Ready()
        {
            this.mKnitterEntitiy.CurrentState = this.mKnitterEntitiy.IdleState;
        }

        public void MountExStorage()
        {
            throw new NotImplementedException();
        }

        public void FlushAndLoadPatternEP()
        {
            throw new NotImplementedException();
        }

        public void UnmountExStorage()
        {
            // 卸载USB设备
            this.mKnitterEntitiy.UnmountExStorage();

            // 结束进入ManufacturingState
            this.mKnitterEntitiy.CurrentState = this.mKnitterEntitiy.ManufacturingState;
        }

        public void LogEventTime()
        {
            return;
        }
    }
}
