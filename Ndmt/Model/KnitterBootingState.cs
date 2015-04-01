using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ndmt.Model
{
    public class KnitterBootingState : IKnitterState
    {
        private KnitterEntity mKnitterEntitiy;
        private const string BOOTING_STATE_STRING = "Booting";

        public KnitterBootingState(KnitterEntity ke)
        {
            this.mKnitterEntitiy = ke;
        }

        public override string ToString() 
        {
            return KnitterBootingState.BOOTING_STATE_STRING;
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
            throw new NotImplementedException();
        }

        public void LogEventTime()
        {
            throw new NotImplementedException();
        }
    }

}
