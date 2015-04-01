using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ndmt.Model
{
    class KnitterFlushingState : IKnitterState
    {
        private KnitterEntity mKnitterEntitiy;
        private const string FLUSHING_STATE_STRING = "Flushing";

        public KnitterFlushingState(KnitterEntity ke)
        {
            this.mKnitterEntitiy = ke;
        }

        public override string ToString()
        {
            return KnitterFlushingState.FLUSHING_STATE_STRING;
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
            // 清空FTP图案文件
            this.mKnitterEntitiy.FlushPatternEP();
             
            // 开始进入LoadingState;
            this.mKnitterEntitiy.CurrentState = this.mKnitterEntitiy.LoadingState;

            // FTP装载数据
            this.mKnitterEntitiy.LoadPatternEP();
        }

        public void UnmountExStorage()
        {
            return;
        }

        public void LogEventTime()
        {
            return;
        }
    }
}
