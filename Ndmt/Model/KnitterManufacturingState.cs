using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ndmt.Model
{
    class KnitterManufacturingState : IKnitterState
    {
        private KnitterEntity mKnitterEntitiy;
        private const string MANUFACURING_STATE_STRING = "Manufacturing";

        public KnitterManufacturingState(KnitterEntity ke)
        {
            this.mKnitterEntitiy = ke;
        }
        
        public override string ToString() 
        {
            return KnitterManufacturingState.MANUFACURING_STATE_STRING;
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
            return;
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
            // 开始进入CleaningUpState
            this.mKnitterEntitiy.CurrentState = this.mKnitterEntitiy.CleaningUpState;

            // 记录结束时间
            this.mKnitterEntitiy.LogEventTime(ShiftEntity.Properties.FinishTime);
        }
    }
}
