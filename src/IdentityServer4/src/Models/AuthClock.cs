using System;

namespace IdentityServer4.Models;

/// <summary>
/// Custom Implementation of Time Provider
/// </summary>
public class AuthClock : TimeProvider
{
    private Func<DateTime> _nowFunc;

    /// <summary>
    /// Allow empty initialization for unit tests
    /// </summary>
    public AuthClock()
    {
    }
    
    /// <summary>
    /// Create an Auth Clock from a Time Provider
    /// </summary>
    /// <param name="clock">valid TimeProvider</param>
    public AuthClock(TimeProvider clock)
    {
        _nowFunc = () => clock.GetUtcNow().UtcDateTime;
    }

    /// <summary>
    /// Custom Function for overriding UtcNow Time
    /// </summary>
    public Func<DateTime> UtcNowFunc
    {
        get { return _nowFunc; }
        set { _nowFunc = value; }
    }
    
    /// <summary>
    /// Returns the result of the UtcNowFunc Function
    /// </summary>
    public DateTimeOffset UtcNow => new DateTimeOffset(_nowFunc());
}