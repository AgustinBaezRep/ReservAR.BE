namespace ReservAR.Application.Test;

public abstract class BaseTest<TSUT>
{
    protected TSUT SUT { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected BaseTest() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
