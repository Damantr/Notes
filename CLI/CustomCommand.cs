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

namespace CLI;

public abstract class ACommand {
    public ACommand(string command, string? name = null, string? description = null) {
        Name = name;
        Description = description;
        CommandText = command;
    }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string CommandText { get; set; }

    public void Execute(string command) {
        if (CommandText == command) {
            IsCalled?.Invoke();
            Handle();
        }
    }

    protected abstract void Handle();

    public event Action? IsCalled;
}

public class CustomCommand : ACommand {
    public CustomCommand(Action action, string command, string? name = null, string? description = null) :
        base(command, name, description) {
        Action = action;
    }

    public CustomCommand(Action action, string command) :
        this(action, command, null, null) {

    }

    public Action? Action { get; set; }

    protected override void Handle() => Action?.Invoke();
}
