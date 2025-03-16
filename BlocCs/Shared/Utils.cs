using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlocCs.Shared;

/// <summary>
/// The utilities
/// </summary>
public static class Utils
{
    /// <summary>
    /// A function to send a response without data
    /// </summary>
    /// <returns>The object of the return</returns>
    public static object RespondWithoutData()
    {
        return new
        {
            status = 200
        };
    }
    
    /// <summary>
    /// A function to respond with data
    /// </summary>
    /// <param name="data">The data to send</param>
    /// <returns>The object of the return</returns>
    public static object RespondWithData<T>(T data)
    {
        return new {
            status = 200,
            data
        };
    }

    /// <summary>
    /// Encore a string to base64
    /// </summary>
    /// <param name="plainText">An instance of a <see cref="string"/></param>
    /// <returns>An instance of a <see cref="string"/> in base64</returns>
    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    /// <summary>
    /// Decode a string from base64
    /// </summary>
    /// <param name="base64EncodedData">An instance of a <see cref="string"/> in base64</param>
    /// <returns>An instance of a <see cref="string"/></returns>
    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
}