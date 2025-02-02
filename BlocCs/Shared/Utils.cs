using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlocCs.Shared;

public static class Utils
{
    public static object RespondWithoutData()
    {
        return new
        {
            status = 200
        };
    }
    public static object RespondWithData<T>(T data)
    {
        return new {
            status = 200,
            data
        };
    }
}