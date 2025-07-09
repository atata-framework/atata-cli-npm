namespace Atata.Cli.Npm;

/// <summary>
/// The exception that is thrown when NPM is not found.
/// </summary>
public sealed class NpmNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NpmNotFoundException"/> class.
    /// </summary>
    public NpmNotFoundException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NpmNotFoundException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public NpmNotFoundException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NpmNotFoundException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public NpmNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
