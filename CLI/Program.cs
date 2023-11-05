new CLIController().ReadCommand();

/*
 *                       *--------------------*
 *                      /|  _____я на кубике /|
 *                     / |  |0 0|           / |
 *                    /  |  \_-_/          /  |
 *                   /   |   /|\          /   |
 *                  /    |  / | \        /    |
 *                 /     |   *-*        /     |
 *                /      |  / /        /      |
 *               *-------+-/-/--------*-------|
 *               |       * | |        |       *
 *               |      /  | |        |      /
 *               |     /              |     /
 *               |    /               |    /
 *  очко         |   /                |   /
 *               |  /                 |  /
 *               | /                  | /
 *               |/                   |/
 *               *--------------------*
 */              



// тут еще ниче не сделали 
internal class CLIController {
    public void ReadCommand() {
        var strConstants = TextConstants.CLIStrings;

        while (true) { //вівод команд
            Console.WriteLine(strConstants[CLIStringDescriptors.Hello]);
            Console.WriteLine(strConstants[CLIStringDescriptors.OfferOfChangingLanguage]);

            var val = Console.ReadLine();
            if (val == "en") {
                InterlanguageString.CurrentLanguage = Languages.EN;
            }
            if (val == "ru") {
                InterlanguageString.CurrentLanguage = Languages.RU;
            }
            Console.Clear();
        }
    }
}

// идентификаторы для строчек по которым мы получаем строчку на нужном языке
internal enum CLIStringDescriptors {
    Hello,
    OfferOfChangingLanguage,
}
