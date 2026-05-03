using Microsoft.VisualBasic;
using Xunit.Sdk;

public class Game
{
    List<int> listRolls = [];
    int frames = 1;
    int score = 0;
    public void Roll(int pins)
    {
        listRolls.Add(pins);
    }

    public List<int> GiveInitialList()
    {
        return listRolls;
    }

    public List<(int, int, int)> OrderPoints(List<int> list)
    {
        var listFrames = new List<(int, int, int)> { };
        for (var i = 0; i < listRolls.Count; i++)
        {
            if (frames < 10) // frame 1-9
            {
                if (listRolls[i] == 10) //strike 
                {
                    listFrames.Add((listRolls[i], 0, 0)); // put strike in frame
                }
                else
                {
                    listFrames.Add((listRolls[i], listRolls[i + 1], 0)); // if not strike, put 2 throws in frame
                    i += 1;         //skip a throw bc you put in 2 throws
                }
                frames += 1;
            }
            else //frame 10
            {
                if ((listRolls[i] == 10) || ((listRolls[i] + listRolls[i + 1]) == 10)) // if strike or spare in frame 10
                {
                    listFrames.Add((listRolls[i], listRolls[i + 1], listRolls[i + 2]));
                    i += 2;
                }
                else
                {
                    listFrames.Add((listRolls[i], listRolls[i + 1], 0)); // if not strike or spare, put 2 last throws in frame
                    i += 2;
                }
            }
        }
        return listFrames;
    }

    public int Score()
    {
        var listFrames = OrderPoints(listRolls);
        for (var i = 0; i < frames; i++)
        {
            score += listFrames[i].Item1 + listFrames[i].Item2 + listFrames[i].Item3; // adds alls throws to score
            if (i < frames - 2)  //1-8 frame
            {
                if (listFrames[i].Item1 == 10) //strike
                {
                    if (listFrames[i + 1].Item1 == 10)
                    {
                        score += listFrames[i + 1].Item1 + listFrames[i + 2].Item1; //strike after strike
                    }
                    else
                    {
                        score += listFrames[i + 1].Item1 + listFrames[i + 1].Item2;  // add 2 following throws to score (not strikes)
                    }
                }
                else if ((listFrames[i].Item1 + listFrames[i].Item2) == 10) //spare
                {
                    score += listFrames[i + 1].Item1;
                }
            }
            else if (i == 8) // 9th frame
            {
                if (listFrames[i].Item1 == 10) //strike
                {
                    score += listFrames[i + 1].Item1 + listFrames[i + 1].Item2;
                }
                else if ((listFrames[i].Item1 + listFrames[i].Item2) == 10) //spare
                {
                    score += listFrames[i + 1].Item1;
                }
            }
            else if (i == 9) // 10th frame
            {
                if (listFrames[i].Item1 == 10) //strike
                { // nothing cuz you already added them to the score at the start.
                  //  the 2 last strikes in a perfect game are just bonus rolls.
                }
                else if ((listFrames[i].Item1 + listFrames[i].Item2) == 10) //spare
                { // nothing cuz you already added them to the score at the start so you dont add them here.
                  //  the 2 last throws are just bonus rolls.
                }
            }
        }
        return score;
    }
}