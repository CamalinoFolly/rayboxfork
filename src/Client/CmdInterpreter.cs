using static System.StringSplitOptions;

namespace RayBox.src.Client
{
    public class CmdInterpreter
    {
        public CmdInterpreter(){
            Console.WriteLine("Started console command interpreter v0.01(test)");
            waitCommand();
        }


        private static Dictionary<string, Action<string[]>> clientCommands 
        = new Dictionary<string, Action<string[]>>()
        {
            {"help", Help}, {"?", Help}, {"h", Help},
            {"quit", Quit}, {"exit", Quit}, {"close", Quit},
            {"clear", Clear}, {"clr", Clear},
            {"load", Load}
           
        };


        
        public void waitCommand(){

                Console.Write("> ");
                string inputString = Console.ReadLine();

                if(inputString.Split(new char[] { ' ' }, RemoveEmptyEntries).First().Substring(0,1).Equals("!")){
                    string command_main = inputString.Split(new char[] { ' ' }, RemoveEmptyEntries).First().Remove(0,1);
                    string[] arguments = inputString.Split(new char[] {' '}, RemoveEmptyEntries).Skip(1).ToArray();
                    
                    if (clientCommands.ContainsKey(command_main)){

                        Action<string[]> function_to_execute = null;

                        clientCommands.TryGetValue(command_main, out function_to_execute);

                        function_to_execute(arguments);
                        
                    }else{
                        Console.WriteLine("> ERROR, command does not exist");
                    }
                }else{
                    Console.WriteLine("You > " + inputString);
                }

                waitCommand();
        }



        public static void Help(String[] args){
            Console.WriteLine("RayBox command interpreter v0.01"+
            "\n commands: !load (Level | Object | Script(not implemented yet))"+
            "\n !help - displays information about the commands" +
            "\n !quit || !exit - exits the game");
        }
        public static void Quit(String[] args){
            Core.quit();
        }
        public static void Clear(String[] args){
            Console.Clear();
        }
        public static void Load(String[] args){
            if(args.Length == 0 || ! args[0].Equals("level") && ! args[0].Equals("object")){
                Console.WriteLine("ERROR you need to parse an argument (level or object)");
                return;
            }

            if(args[0].Equals("level")){

            }

        }
    }



    
}