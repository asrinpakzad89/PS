namespace CMMSAPP.Common.Extensions;

public static class EnumExtensions
{
    public static int ToInt<TEnum>(this TEnum enumValue) where TEnum : Enum
    {
        return Convert.ToInt32(enumValue);
    }

    public static TEnum ToEnum<TEnum>(this int value) where TEnum : Enum
    {
        if (!Enum.IsDefined(typeof(TEnum), value))
            throw new ArgumentException($"مقدار {value} در Enum {typeof(TEnum).Name} تعریف نشده است.");

        return (TEnum)Enum.ToObject(typeof(TEnum), value);
    }
}
