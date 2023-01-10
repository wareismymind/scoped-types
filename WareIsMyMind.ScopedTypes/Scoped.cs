namespace WareIsMyMind.ScopedTypes;

/// <summary>
/// A container for an instance of <typeparamref name="T"/> that uses <c>typeof(<typeparamref name="TScope"/>)</c> as
/// metadata to make its type distinct.
/// </summary>
/// <typeparam name="T">The type of the value in the container.</typeparam>
/// <typeparam name="TScope">A type used to identify a particular instance of <typeparamref name="T"/>.</typeparam>
public record Scoped<T, TScope>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Scoped{T, TScope}"/> type to wrap <paramref name="value"/>.
    /// </summary>
    public Scoped(T value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Value = value;
    }

    /// <summary>
    /// The wrapped <typeparamref name="T"/>.
    /// </summary>
    public T Value { get; private set; }

    /// <summary>
    /// Converts <paramref name="scoped"/> to its <typeparamref name="T"/> value.
    /// </summary>
    public static implicit operator T(Scoped<T, TScope> scoped) => scoped.Value;

    /// <summary>
    /// Converts <paramref name="value"/> to a <see cref="Scoped{T, TScope}"/> of <typeparamref name="T"/> and
    /// <typeparamref name="TScope"/>.
    /// </summary>
    public static explicit operator Scoped<T, TScope>(T value) => new(value);
}
