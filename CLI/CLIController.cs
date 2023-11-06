/*
 *                       *--------------------*
 *                      /|  _____я на кубике /|
 *                     / |  |0 0|           / |
 *                    /  |  \_-_/          /  |
 *                   /   |   /|\          /   |
 *                  /    |  / | \        /    |
 *                 /     |   *-*        /     |
 *                /      |  / /        /      |
 *               *-------+-/-/--------*       |
 *               |       *-|-|--------+-------*
 *               |      /  | |        |      /
 *               |     /              |     /
 *               |    /               |    /
 *  очко         |   /                |   /
 *               |  /                 |  /
 *               | /                  | /
 *               |/                   |/
 *               *--------------------*
 *
 */

using CLI.Language;

namespace CLI;

internal class CLIController {
    private IReadOnlyDictionary<CLIStringDescriptors, InterlanguageString> _strConstants = TextConstants.CLIStrings;
    private List<CustomCommand> _customCommands = new List<CustomCommand>();

    public void ReadCommands() {
        while (true) {
            var command = Console.ReadLine();
            if (command == null || string.IsNullOrEmpty(command) || string.IsNullOrWhiteSpace(command)) {
                return;
            }
            foreach (var c in _customCommands) {
                c.Execute(command);
            }
        }
    }

    public bool InjectCommand(CustomCommand command) {
        if (!_customCommands.Contains(command)) {
            _customCommands.Add(command);
            return true;
        }
        return false;
    }
}

