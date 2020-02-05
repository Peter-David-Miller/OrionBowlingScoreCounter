using System;

namespace OrionProjectBowlingScoreCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            BowlingScore[] GameScore = new BowlingScore[11];
            BowlingScore frame1 = new BowlingScore(0, false, false, 0, 0);
            BowlingScore frame2 = new BowlingScore(0, false, false, 0, 0);
            BowlingScore frame3 = new BowlingScore(0, false, false, 0, 0);
            BowlingScore frame4 = new BowlingScore(0, false, false, 0, 0);
            BowlingScore frame5 = new BowlingScore(0, false, false, 0, 0);
            BowlingScore frame6 = new BowlingScore(0, false, false, 0, 0);
            BowlingScore frame7 = new BowlingScore(0, false, false, 0, 0);
            BowlingScore frame8 = new BowlingScore(0, false, false, 0, 0);
            BowlingScore frame9 = new BowlingScore(0, false, false, 0, 0);
            BowlingScore frame10 = new BowlingScore(0, false, false, 0, 0);
            BowlingScore frameAdditional = new BowlingScore(0, false, false, 0, 0);
            GameScore[0] = frame1;
            GameScore[1] = frame2;
            GameScore[2] = frame3;
            GameScore[3] = frame4;
            GameScore[4] = frame5;
            GameScore[5] = frame6;
            GameScore[6] = frame7;
            GameScore[7] = frame8;
            GameScore[8] = frame9;
            GameScore[9] = frame10;
            GameScore[10] = frameAdditional;

            bool StrikeFinal = false;
            bool SpareFinal = false;
            int loopCounter = 0;
            while (loopCounter < 10 || StrikeFinal == true || SpareFinal == true)
            {
                loopCounter++;                
                bool Strike = false;
                bool Spare = false;
                int ScoreLocal = 0;
                bool ValidInput = false;
                bool DoubleStrikeChance = false;
                bool SpareClear = false;
                StrikeFinal = false;
                if (SpareFinal == true)
                {
                    SpareClear = true;
                }
                while (ValidInput == false)
                {
                    Console.WriteLine("Please input value scored in first run of frame " + loopCounter);
                    String Run1 = Console.ReadLine();
                    if (Run1 == "X" || Run1 == "x")
                    {

                        ScoreLocal = 10;
                        ValidInput = true;
                        GameScore[loopCounter - 1].Run1 = 10;
                        if (loopCounter == 10)
                        {
                            StrikeFinal = true;
                            Strike = true;
                        }
                        if (loopCounter == 11)
                        {

                            DoubleStrikeChance = true;
                        }
                        else
                        {
                            Strike = true;
                        }
                    }
                    else if (Run1 == "-")
                    {
                        ValidInput = true;
                        GameScore[loopCounter - 1].Run1 = 0;
                    }
                    else if (Run1 == "1" || Run1 == "2" || Run1 == "3" || Run1 == "4" || Run1 == "5" || Run1 == "6" || Run1 == "7" || Run1 == "8" || Run1 == "9")
                    {
                        int ScoreR1 = Convert.ToInt16(Run1);
                        ScoreLocal = ScoreLocal + ScoreR1;
                        ValidInput = true;
                        GameScore[loopCounter - 1].Run1 = ScoreR1;
                    }
                    else
                    {
                        Console.WriteLine("The String you have added was unexpected. Valid inputs for the 1st run include x or X for strike, - for miss or any interger between 1 and 9.");
                    }

                }

                if (SpareFinal == false)
                {
                    if (Strike == false && ValidInput == true)
                    {
                        ValidInput = false;
                        while (ValidInput == false)
                        {
                            Console.WriteLine("Please input value scored in second run of frame " + loopCounter);
                            String Run2 = Console.ReadLine();
                            ValidInput = false;
                            if (DoubleStrikeChance == true)
                            {
                                if (Run2 == "X" || Run2 == "x")
                                {
                                    GameScore[loopCounter - 1].Run2 = 10;
                                }
                            }

                            else if (Run2 == "/")
                            {

                                int SpareScore = 0;
                                SpareScore = 10 - ScoreLocal;
                                GameScore[loopCounter - 1].Run2 = SpareScore;
                                ScoreLocal = 10;
                                if (loopCounter == 10)
                                {
                                    SpareFinal = true;
                                    Spare = true;
                                }
                                else
                                {
                                    Spare = true;
                                }

                            }
                            else if (Run2 == "-")
                            {
                                GameScore[loopCounter - 1].Run2 = 0;
                                ValidInput = true;
                            }
                            else if (Run2 == "1" || Run2 == "2" || Run2 == "3" || Run2 == "4" || Run2 == "5" || Run2 == "6" || Run2 == "7" || Run2 == "8" || Run2 == "9")
                            {
                                int ScoreR2 = Convert.ToInt16(Run2);
                                ScoreLocal = ScoreLocal + ScoreR2;
                                GameScore[loopCounter - 1].Run2 = ScoreR2;
                                if (ScoreLocal >= 10)
                                {
                                    Console.WriteLine("Error");
                                }
                                if (ScoreLocal < 10)
                                {
                                    Console.WriteLine("Valid");
                                }
                                ValidInput = true;
                            }
                            else
                            {
                                Console.WriteLine("The String you have added was unexpected. Valid inputs for the 2nd run include / for spare, - for miss or any interger between 1 and 9, x or X if a strike on your 2nd free ball.");
                            }
                        }
                        
                    }
 

                }
                if (ValidInput == false)
                {

                }
                if (SpareClear == true)
                {
                    SpareFinal = false;
                }
                GameScore[loopCounter - 1].Score = ScoreLocal;
                GameScore[loopCounter - 1].Strike = Strike;
                GameScore[loopCounter - 1].Spare = Spare;
            }
            int TotalScoreCounter = 0;
            int TotalScore = 0;
            while (TotalScoreCounter < 10)
            {
                int AdditionalScore = 0;
                TotalScore = TotalScore + GameScore[TotalScoreCounter].Score;
                if (GameScore[TotalScoreCounter].Strike && TotalScoreCounter <= 9)
                {
                    if (GameScore[TotalScoreCounter + 1].Strike == true)
                    {
                        AdditionalScore = GameScore[TotalScoreCounter + 1].Score + GameScore[TotalScoreCounter + 2].Run1;
                    }
                    else
                    {
                        AdditionalScore = GameScore[TotalScoreCounter + 1].Run1 + GameScore[TotalScoreCounter + 1].Run2;
                    }
                    
                }
                if (GameScore[TotalScoreCounter].Spare && TotalScoreCounter <= 9)
                {
                    AdditionalScore = GameScore[TotalScoreCounter + 1].Run1;
                }
                TotalScore = TotalScore + AdditionalScore;
                TotalScoreCounter++;

                Console.WriteLine("The total scored points is " + TotalScore);
            }
        }
    }

}
