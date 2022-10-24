using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ScoreLogick
{
    private static uint _maxScore = 0;
    public uint Score = 0;

    public ScoreLogick()
    {

    }

    public void CheckMaxScore()
    {
        if (Score > _maxScore)
        {
            _maxScore = Score;
            SaveMaxScore();
        }
    }

    private void SaveMaxScore()
    {

    }
}

