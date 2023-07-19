namespace Cqrs_Mediatr.Exception;

public class OrderProductIsNullException : System.Exception
{
    public OrderProductIsNullException(string message): base(message)
    {
        
    }
    
}