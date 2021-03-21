using System.Collections.Generic;

namespace LessonForVlad4
{
    class Animation
    {
        public char[][][] animation;
        public int delay = 0;
        public int slowdown = 0;

        public int currentFrame = 0;

        public Animation(List<string[]> protoAnimation)
        {
            SetAnimation(protoAnimation);
        }
        public void SetAnimation(List<string[]> protoAnimation)
        {
            if (protoAnimation != null)
            {
                currentFrame = 0;
                animation = new char[protoAnimation.Count][][];
                for (int i = 0; i < animation.Length; i++)
                {
                    animation[i] = new char[protoAnimation[i].Length][];
                    for (int j = 0; j < animation[i].Length; j++)
                        animation[i][j] = protoAnimation[i][j].Replace(' ', char.MinValue).ToCharArray();
                }
            }
        }
        public void ReAnimate()
        {
            currentFrame = 0;
        }
        
        public char[][] GetFrame()
        {
            if (delay != 0)
            {
                delay--;
                return null;
            }

            int sd = slowdown + 1;
            if (currentFrame >= animation.Length * sd)
                currentFrame = 0;
            char[][] res = animation[currentFrame / sd];
            currentFrame++;
            return res;
        }
    }
}
