using System.Collections.Generic;

namespace LessonForVlad4
{
    class MainWoman : Woman
    {
        public MainWoman(int x, int y) : base(x, y)
        {
            ChangeSkin();
        }
        protected void ChangeSkin()
        {
            Dictionary<char, char> replacer = new Dictionary<char, char>
            {
                { 'O', '0' },
                { '#', 'I' },
                { '1', 'I' }
            };
            ChangeFrames(animationStand, replacer);
            ChangeFrames(animationWalk, replacer);
            ChangeFrames(animationJump, replacer);
        }
        protected void ChangeFrames(Animation a, Dictionary<char, char> replacer)
        {
            for (int frame = 0; frame < a.animation.Length; frame++)
                for (int i = 0; i < a.animation[frame].Length; i++)
                    for (int j = 0; j < a.animation[frame][i].Length; j++)
                    {
                        replacer.TryGetValue(a.animation[frame][i][j], out a.animation[frame][i][j]);
                    }
        }
    }
}
