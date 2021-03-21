namespace LessonForVlad4
{
    class Woman : Man
    {
        public Woman(int x, int y) : base(x, y)
        {
            animationStand = new Animation(AnimationsLibrary.womanStandFrames) { slowdown = animationStand.slowdown };
            animationWalk = new Animation(AnimationsLibrary.womanWalkFrames) { slowdown = animationWalk.slowdown };
            animationJump = new Animation(AnimationsLibrary.womanJumpFrames) { slowdown = animationJump.slowdown };
        }
    }
}
