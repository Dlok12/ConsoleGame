using System;
using System.Collections.Generic;

namespace LessonForVlad4
{
    class MainCharacter : Man
    {
        private int leftWall = 0;
        private int rightWall = 90;
        Animation animationClimb = new Animation(AnimationsLibrary.manClimbFrames) { slowdown = 4 };

        public MainCharacter(int x, int y) : base(x, y)
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
            ChangeFrames(animationClimb, replacer);
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

        public override void Update(ConsoleKey key)
        {
            if (key == ConsoleKey.D && x < rightWall) Walk(1);
            if (key == ConsoleKey.A && x > leftWall) Walk(-1);

            if (key == ConsoleKey.W) Jump();

            Stand();
            Jumping();
            UpdateCoords();
        }
    }
}
