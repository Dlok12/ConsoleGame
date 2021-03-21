using System.Collections.Generic;

namespace LessonForVlad4
{
    class Platform : GameObject
    {
        Animation animationStand = new Animation(new List<string[]>
        {
            new string[]
            {
                "SSSSSSSSSSSS",
                "SSS/SSSSS/SS",
                "SSSSSSSSSSS/",
                "SSSSSSS/SSSS"
            }
        });
        public Platform(int x, int y) : base(x, y)
        {
            currentFrame = animationStand.animation[0];
            fallingSpeed = 0;
        }
    }
}
