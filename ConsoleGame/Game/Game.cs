using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonForVlad4
{
    class Game
    {
        public static List<GameObject> gos = new List<GameObject>();
        private static Random rnd = new Random();
        
        public static void SpawnUnits()
        {
            int y = Engine.consoleHeight - 18;
            gos.Add(new MainCharacter(Engine.consoleWidth / 2, y));
            gos.Add(new Enemy(Engine.consoleWidth, y));
            gos.Add(new MainWoman(Engine.consoleWidth / 3, y));

            for (int i = 0; i < 96 / 12; i++) gos.Add(new Platform(i * 12, y + 5));

            House h = new House(Engine.consoleWidth - 25, 0);
            h.y = y - h.currentFrame.Length + 6;
            gos.Add(h);

            GameObject shop = new GameObject(1, y + 6) { currentFrame = new Animation(Levels.shop4x2).animation[0] };
            shop.y -= shop.currentFrame.Length;
            gos.Add(shop);
        }
    }
}
