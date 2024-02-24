namespace LitePrimitives.UnitTests.Extensions.OptionExtensionsTests;

public class ToOptionTests
{
    [Fact]
    public void Returns_Option_From_Value_Type_In_Some_State()
    {
        const bool expected = OptionConstants.ExpectedValue;
        
        expected.ToOption().ShouldReturnValueOnMatch(expected);
    }
    
    [Fact]
    public void Returns_Option_From_Nullable_Value_Type_In_Some_State()
    {
        bool? expected = OptionConstants.ExpectedValue;
        
        expected.ToOption().ShouldReturnValueOnMatch(expected.Value);
    }
    
    [Fact]
    public void Returns_Option_From_Reference_In_Some_State()
    {
        // ReSharper disable once VariableCanBeNotNullable
        object? expected = new object();
        
        expected.ToOption().ShouldReturnValueOnMatch(expected);
    }
    
    [Fact]
    public void Returns_Option_From_String_Nullable_Reference_In_Some_State()
    {
        // ReSharper disable once VariableCanBeNotNullable
        const string? expected = "Test";

        expected.ToOption().ShouldReturnValueOnMatch(expected);
    }
    
    [Fact]
    public void Returns_Option_From_Null_Value_Type_In_None_State()
    {
        bool? expected = null;
        
        expected.ToOption().ShouldReturnNothingOnMatch();
    }
    
    [Fact]
    public void Returns_Option_From_Null_Reference_In_None_State()
    {
        object? expected = null;
        
        expected.ToOption().ShouldReturnNothingOnMatch();
    }
    
    [Fact]
    public void Returns_Option_From_String_Nullable_Reference_In_None_State()
    {
        string? expected = null;
        
        expected.ToOption().ShouldReturnNothingOnMatch();
    }
    
    [Fact]
    public void Returns_Option_From_Inline_String_Nullable_Reference_In_None_State()
    {
        ((string?)null).ToOption().ShouldReturnNothingOnMatch();
    }
}