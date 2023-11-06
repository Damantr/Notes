using CLI;

var controller = new CLIController();

controller.InjectCommand(new CustomCommand(Hello, "/hello"));

controller.ReadCommands();

void Hello() {
    Console.WriteLine("Hello!");
}


