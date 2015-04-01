using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ndmt.Model
{
    class KnitterIdleState : IKnitterState
    {
        private KnitterEntity mKnitterEntitiy;
        private const string IDLE_STATE_STRING = "Idle";

        public KnitterIdleState(KnitterEntity ke)
        {
            this.mKnitterEntitiy = ke;
        }
        
        public override string ToString()
        {
            return KnitterIdleState.IDLE_STATE_STRING;
        }

        public void Restart()
        {
            this.mKnitterEntitiy.CurrentState = this.mKnitterEntitiy.BootingState;
        }

        public void Reset()
        {
            this.mKnitterEntitiy.CurrentState = this.mKnitterEntitiy.BootingState;
        }

        public void Ready()
        {
            return;
        }

        public void MountExStorage()
        {
            // 挂载USB设备
            this.mKnitterEntitiy.MountExStorage();

            // 结束进入FlushingState
            this.mKnitterEntitiy.CurrentState = this.mKnitterEntitiy.FlushingState;
        }

        public void FlushAndLoadPatternEP()
        {
            return;
        }

        public void UnmountExStorage()
        {
            return;
        }

        public void LogEventTime()
        {
            // 记录开始时间
            this.mKnitterEntitiy.LogEventTime(ShiftEntity.Properties.StartTime); 
        }
    }
}
