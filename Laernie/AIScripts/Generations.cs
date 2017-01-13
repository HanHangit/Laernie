using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laernie
{
    struct Information
    {
        float value;
        MoveInformation move;

        public Information(float _value, MoveInformation _move)
        {
            value = _value;
            move = _move;
        }

    }    


    class Generations
    {
        int maxGeneration;
        float mutationChance;

        public Generations(int _maxGeneration, float _mutationChance)
        {
            maxGeneration = _maxGeneration;
            mutationChance = _mutationChance;
        }
    }
}
