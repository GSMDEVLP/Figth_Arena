using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_arena.Models
{
    public static class Hero
    {
        public static int idleFrames = 5;    // будем передавать в конструктор игрока
        public static int runFrames = 8;
        public static int attackFrames = 7;
        public static int deathFrames = 7;
    }
}
