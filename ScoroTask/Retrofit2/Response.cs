using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Retrofit2.Http;
using static Retrofit2.Utils;

namespace Retrofit2
{
    /** An HTTP response. */

    public sealed class Response<T>
    {
        ///** Create a synthetic successful response with {@code body} as the deserialized body. */
        //public static Response<T> success(T body = default(T))
        //{
        //    return success(body, new okhttp3.Response.Builder() //
        //        .code(200)
        //        .message("OK")
        //        .protocol(Protocol.HTTP_1_1)
        //        .request(new Request.Builder().url("http://localhost/").build())
        //        .build());
        //}

        ///**
        // * Create a synthetic successful response using {@code headers} with {@code body} as the
        // * deserialized body.
        // */
        //public static Response<T> success(T body, Headers headers)
        //{
        //    checkNotNull(headers, "headers == null");
        //    return success(body, new okhttp3.Response.Builder() //
        //        .code(200)
        //        .message("OK")
        //        .protocol(Protocol.HTTP_1_1)
        //        .headers(headers)
        //        .request(new Request.Builder().url("http://localhost/").build())
        //        .build());
        //}

        ///**
        // * Create a successful response from {@code rawResponse} with {@code body} as the deserialized
        // * body.
        // */
        //public static Response<T> success(T body = default(T), okhttp3.Response rawResponse)
        //{
        //    checkNotNull(rawResponse, "rawResponse == null");
        //    if (!rawResponse.isSuccessful())
        //    {
        //        throw new ArgumentException("rawResponse must be successful response");
        //    }
        //    return new Response<T>(rawResponse, body, null);
        //}

        ///**
        // * Create a synthetic error response with an HTTP status code of {@code code} and {@code body}
        // * as the error body.
        // */
        //public static Response<T> error(int code, ResponseBody body)
        //{
        //    if (code < 400) throw new ArgumentException("code < 400: " + code);
        //    return error(body, new okhttp3.Response.Builder() //
        //        .code(code)
        //        .message("Response.error()")
        //        .protocol(Protocol.HTTP_1_1)
        //        .request(new Request.Builder().url("http://localhost/").build())
        //        .build());
        //}

        ///** Create an error response from {@code rawResponse} with {@code body} as the error body. */
        //public static Response<T> error(ResponseBody body, okhttp3.Response rawResponse)
        //{
        //    checkNotNull(body, "body == null");
        //    checkNotNull(rawResponse, "rawResponse == null");
        //    if (rawResponse.isSuccessful())
        //    {
        //        throw new ArgumentException("rawResponse should not be successful response");
        //    }
        //    return new Response<T>(rawResponse, null, body);
        //}

        //private readonly okhttp3.Response rawResponse;
        //private readonly T _body;
        //private readonly ResponseBody _errorBody;

        //private Response(okhttp3.Response rawResponse, T body = default(T),
        //    ResponseBody errorBody = null)
        //{
        //    this.rawResponse = rawResponse;
        //    this._body = body;
        //    this._errorBody = errorBody;
        //}

        ///** The raw response from the HTTP client. */
        //public okhttp3.Response raw()
        //{
        //    return rawResponse;
        //}

        ///** HTTP status code. */
        //public int code()
        //{
        //    return rawResponse.code();
        //}

        ///** HTTP status message or null if unknown. */
        //public String message()
        //{
        //    return rawResponse.message();
        //}

        ///** HTTP headers. */
        //public Headers headers()
        //{
        //    return rawResponse.headers();
        //}

        ///** Returns true if {@link #code()} is in the range [200..300). */
        //public bool isSuccessful()
        //{
        //    return rawResponse.isSuccessful();
        //}

        ///** The deserialized response body of a {@linkplain #isSuccessful() successful} response. */
        //public T body()
        //{
        //    return _body;
        //}

        ///** The raw response body of an {@linkplain #isSuccessful() unsuccessful} response. */
        ////public ResponseBody errorBody()
        ////{
        ////    return _errorBody;
        ////}

        //public String toString()
        //{
        //    return rawResponse.toString();
        //}
    }

}