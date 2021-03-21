using System;

namespace LessonForVlad4
{
    class GameObject
    {
        public int x, y;
        public int velocityX, velocityY;
        public int fallingSpeed = 3;
        public bool lookRight = true;
        public char[][] currentFrame;

        public GameObject(int x, int y)
        {
            this.x = x;
            this.y = y;
            velocityX = 0;
            velocityY = 0;
        }
        public void SetFrame(char[][] frame)
        {
            if (frame != null)
                currentFrame = frame;
        }
        public virtual void Update(ConsoleKey input)
        {
            UpdateCoords();
        }
        protected void UpdateCoords()
        {
            x += velocityX;
            y += velocityY;

            //if (fallingSpeed != 0 && Falling()) y += fallingSpeed;
        }
        //protected bool Falling()
        //{
        //    int height = currentFrame.Length;
        //    int yDown = y + height;

        //    if (yDown >= Engine.consoleHeight) return false;

        //    for (int j = 0; j < currentFrame[0].Length; j++)
        //    {
        //        if (Engine.screenCurrent[x + j, yDown + 1] != char.MinValue)
        //            return false;
        //    }
        //    return true;
        //}
    }
}
