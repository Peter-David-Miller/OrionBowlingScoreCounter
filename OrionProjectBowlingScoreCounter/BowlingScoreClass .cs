using System;
using System.Collections.Generic;
using System.Text;

namespace OrionProjectBowlingScoreCounter
{
    public class BowlingScore
    {

        public int Score;
        public bool Strike;
        public bool Spare;
        public int Run1;
        public int Run2;

        public void SetS(int S) { Score = S; }
        public int GetS() { return Score; }
        public void SetSt(bool ST) { Strike = ST; }
        public bool GetSt() { return Strike; }
        public void SetSp(bool SP) { Spare = SP; }
        public bool GetSp() { return Spare; }
        public void SetR1(int R1) { Run1 = R1; }
        public int GetR1() { return Run2; }
        public void SetR2(int R2) { Run2 = R2; }
        public int GetR2() { return Run2; }

        public BowlingScore(int Score, bool Strike, bool Spare, int Run1, int Run2 )
        {
            this.SetS(Score);
            this.SetSt(Strike);
            this.SetSp(Spare);
            this.SetR1(Run1);
            this.SetR2(Run2);
        }
    }
}
