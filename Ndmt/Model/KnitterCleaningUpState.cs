using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ndmt.Model
{
    class KnitterCleaningUpState : IKnitterState
    {
        private KnitterEntity mKnitterEntitiy;
        private const string CLEANING_UP_STATE_STRING = "Cleaning up";

        public KnitterCleaningUpState(KnitterEntity ke)
        {
            this.mKnitterEntitiy = ke;
        }

        public override string ToString() 
        {
            return KnitterCleaningUpState.CLEANING_UP_STATE_STRING;
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
