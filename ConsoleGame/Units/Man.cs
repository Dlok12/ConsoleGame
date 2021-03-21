using System;

namespace LessonForVlad4
{
    class Man : GameObject
    {
        protected int walkSpeed = 2;
        protected int afterWalkStandDelay = 20;

        protected int jumpSpeed = 3;
        protected int jumpRoute = 0;
        protected int jumpTime = 0;
        protected int jumpMaxTime = 3;
        protected int currentJumpDelay = 0;
        protected bool jump = false;

        protected Animation animationStand = new Animation(AnimationsLibrary.manStandFrames) { slowdown = 128 };
        protected Animation animationWalk = new Animation(AnimationsLibrary.manWalkFrames) { slowdown = 2 };
        protected Animation animationJump = new Animation(AnimationsLibrary.manJumpFrames);

        public Man(int x, int y) : base(x, y)
        {
            animationJump.slowdown = jumpMaxTime;
            SetFrame(animationStand.GetFrame());
        }

        protected void Stand()
        {
            velocityX = 0;

            AnimateStand();
        }
        protected void AnimateStand()
        {
            if (animationStand.delay == 0)
            {
                animationWalk.ReAnimate();
            }

            SetFrame(animationStand.GetFrame());
        }

        protected void Walk(int routeX)
        {
            velocityX = routeX * walkSpeed;

            if (routeX != 0)
            {
                lookRight = routeX < 0 ? false : true;
                x += velocityX;
            }

            AnimateWalk();
        }
        protected void AnimateWalk()
        {
            SetFrame(animationWalk.GetFrame());

            animationStand.delay = afterWalkStandDelay;
            animationStand.ReAnimate();
        }

        protected void Jump()
        {
            if (jumpRoute == 0)
                jumpRoute = 1;
        }
        protected void Jumping()
        {
            if (jumpRoute != 0)
            {
                if (!jump && currentJumpDelay <= jumpMaxTime) currentJumpDelay++;
                else
                {
                    currentJumpDelay = 0;
                    jump = true;

                    y -= jumpRoute * jumpSpeed;

                    if (jumpRoute == 1)
                    {
                        jumpTime++;
                        if (jumpTime > jumpMaxTime) jumpRoute = -1;
                    }
                    else if (jumpRoute == -1)
                    {
                        jumpTime--;
                        if (jumpTime < 1)
                        {
                            jumpRoute = 0;
                            jump = false;
                            animationJump.ReAnimate();
                        }
                    }
                }
                AnimateJump();
            }
        }
        protected void AnimateJump()
        {
            SetFrame(animationJump.GetFrame());

            animationStand.delay = afterWalkStandDelay;
            animationStand.ReAnimate();
        }

        public override void Update(ConsoleKey key)
        {
            Stand();
            Jumping();
            UpdateCoords();
        }
    }
}
