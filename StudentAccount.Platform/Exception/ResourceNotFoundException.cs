namespace StudentAccount.Platform.Exception;

public class ResourceNotFoundException : System.Exception
{
    public ResourceNotFoundException( string message): base(message)
    {
    }
}
