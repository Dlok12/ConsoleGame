using System;

namespace LessonForVlad4
{
    class Enemy : Man
    {
        int maxR = 96;

        public Enemy(int x, int y) : base(x, y)
        {
            lookRight = false;
        }
        public override void Update(ConsoleKey key)
        {
            Walk(-1);
            if (-maxR > x) x = maxR;
        }
    }
}
