
using static SDL2.SDL;

namespace RayBox.src{
    public sealed class Core
    {
        static void Main(){
            Console.WriteLine("starting..");
            new Core();
        }
        static IntPtr window;
        static IntPtr surface;
        static bool running = false;

        public Core(){

            Console.WriteLine(" starting SDL");
            if(SDL_Init(SDL_INIT_VIDEO) < 0){
                return;
                 Console.WriteLine(" error, sdl cannot be initialized");
            }
            
            Console.WriteLine(" starting Window");
            window = SDL_CreateWindow("RayBox",
            SDL_WINDOWPOS_CENTERED,SDL_WINDOWPOS_CENTERED,
            360,240,
            0);

            surface = SDL_GetWindowSurface(window);
            
            initGame();

            running = true;        
            while(running){
                while (SDL_PollEvent(out SDL_Event e) == 1)
                {
                    switch (e.type)
                    {
                        case SDL_EventType.SDL_QUIT:
                            running = false;
                            break;
                    }
                }



            }

            SDL_DestroyWindow(window);
            SDL_Quit();
        }
        public static void quit(){
            SDL_DestroyWindow(window);
            SDL_Quit();
            Environment.Exit(0);
        }

        void initGame(){
            Console.WriteLine(" starting game");

            new Client.CmdInterpreter();
        }

        
    }
}

