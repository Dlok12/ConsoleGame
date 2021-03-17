using System;
using System.Collections.Generic;
using System.Timers;

namespace LessonForVlad4
{
    class Engine
    {
        public const int consoleWidth = 96;
        public const int consoleHeight = 48;

        public static char[,] screenCurrent = new char[consoleWidth, consoleHeight];
        private static char[,] screenBuffer = new char[consoleWidth, consoleHeight];

        private static Dictionary<char, ConsoleColor[]> charToColorAndBg = new Dictionary<char, ConsoleColor[]>
        {
            { '\0', new ConsoleColor[] { ConsoleColor.Black, ConsoleColor.Black } },    // Space
            { 'S', new ConsoleColor[] { ConsoleColor.DarkGray, ConsoleColor.Black } },  // Platform
            { 'X', new ConsoleColor[] { ConsoleColor.Black, ConsoleColor.DarkGray } },  // Buildings
            { 'M', new ConsoleColor[] { ConsoleColor.Black, ConsoleColor.DarkGray } },  // Buildings

            { 'O', new ConsoleColor[] { ConsoleColor.Gray, ConsoleColor.Black } },      // Unit
            { '1', new ConsoleColor[] { ConsoleColor.Gray, ConsoleColor.Black } },      // Unit
            { '#', new ConsoleColor[] { ConsoleColor.Gray, ConsoleColor.Black } },      // Unit

            { '0', new ConsoleColor[] { ConsoleColor.White, ConsoleColor.Black } },      // MC
            { 'I', new ConsoleColor[] { ConsoleColor.White, ConsoleColor.Black } }       // MC
        };

        private const int fps = 20;
        private const int toTimeout = 160;
        private static int timerTimeout = 0;
        private static Timer engineTimer = new Timer();
        private static ConsoleKey input;

        public static void Start()
        {
            Initialize();
            ReadKey();
        }

        private static void Initialize()
        {            
            ChangeConsoleParams();

            Game.SpawnUnits();
            ToScreenGameObjects();
            RePrint();

            SetTimer();
        }
        private static void ReadKey()
        {
            input = Console.ReadKey(true).Key;
            ReadKey();
        }
        private static void ChangeConsoleParams()
        {
            Console.SetWindowSize(consoleWidth, consoleHeight);
            Console.SetBufferSize(consoleWidth, consoleHeight);
            Console.CursorVisible = false;
        }

        private static void SetTimer()
        {
            engineTimer = new Timer(1000 / fps);
            engineTimer.Elapsed += OnTimedEvent;
            engineTimer.AutoReset = true;
            engineTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (timerTimeout <= 0) Update();
            else timerTimeout--;
        }
        private static void Update()
        {
            ToScreenGameObjects();
            RePrint();

            input = ConsoleKey.Clear;
        }

        private static void ToScreenGameObjects()
        {
            foreach (var go in Game.gos)
                ToScreenGameObject(go);
        }
        private static void ToScreenGameObject(GameObject go)
        {
            go.Update(input);
            for (int i = 0; i < go.currentFrame.Length; i++)
                for (int j = 0; j < go.currentFrame[i].Length; j++)
                {
                    if (go.lookRight)
                        ToScreenAt(go.currentFrame[i][j], go.x + j, go.y + i);
                    else
                        ToScreenAt(go.currentFrame[i][j], go.x - j + go.currentFrame.Length, go.y + i);
                }
        }
        private static void ToScreenAt(char c, int x, int y)
        {
            if (x >= 0 && x < consoleWidth && y >= 0 && y < consoleHeight - 1 && screenCurrent[x, y] == char.MinValue)
                screenCurrent[x, y] = c;
        }
        private static void RePrint()
        {
            int pixCounter = 0;

            for (int i = 0; i < consoleWidth; i++)
            {
                for (int j = 0; j < consoleHeight; j++)
                {
                    if (screenCurrent[i, j] != screenBuffer[i, j])
                    {
                        PrintPix(i, j);

                        pixCounter++;
                        if (pixCounter >= toTimeout)
                        {
                            pixCounter = 0;
                            timerTimeout++;
                        }
                    }
                }
            }
            screenBuffer = screenCurrent;
            screenCurrent = new char[consoleWidth, consoleHeight];
        }
        private static void PrintPix(int i, int j)
        {
            charToColorAndBg.TryGetValue(screenCurrent[i, j], out ConsoleColor[] colorAndBg);
            if (colorAndBg != null)
            {
                Console.ForegroundColor = colorAndBg[0];
                Console.BackgroundColor = colorAndBg[1];
            }
            else Console.ResetColor();

            Console.SetCursorPosition(i, j);
            Console.Write(screenCurrent[i, j]);
        }
        
        private static void PrintABall(int r, int x, int y)
        {
            x += r;
            y += r;

            for (int j = -r; j <= r; j++)
                for (int i = -r; i <= r; i++)
                    if (i * i + 2 * j * j < r * r)
                        ToScreenAt('b', x + i, y + j);
        } // Old
        private static void PrintACircle(int r, int x, int y)
        {
            x += r;
            y += r;
            for (int i = -r; i <= r; i++)
                for (int j = -r; j <= r; j++)
                    if ((i * i + 2 * j * j < r * r) && (i * i + 2 * j * j > r * r - 2 * r))
                        ToScreenAt('c', x + i, y + j);
        } // Old
    }
}
