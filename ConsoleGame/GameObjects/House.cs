using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonForVlad4
{
    class House : GameObject
    {
        Animation animation = new Animation(Levels.house8x6);

        public House(int x, int y) : base(x, y)
        {
            currentFrame = animation.animation[0];
        }
    }
}
