// State - Abstract class
public abstract class State
{
    public abstract void Handle(Context context);
}


// A - ConcreteState class
public class ConcreteStateA : State
{
    public override void Handle(Context context)
    {
        context.State = new ConcreteStateB();
    }
}


// B - ConcreteState class
public class ConcreteStateB : State
{
    public override void Handle(Context context)
    {
        context.State = new ConcreteStateA();
    }
}


// Context class
public class Context
{
    State state;

    // Constructor
    public Context(State state)
    {
        this.State = state;
    }

    public State State
    {
        get { return state; }
        set
        {
            state = value;
            Console.WriteLine("State: " + state.GetType().Name);
        }
    }
    public void Request()
    {
        state.Handle(this);
    }
}

public class Program
{
    public static void Main()
    {
        var context = new Context(new ConcreteStateA());

        context.Request();
        context.Request();
        context.Request();
        context.Request();

    }
}