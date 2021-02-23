using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shared.ExceptionHandling;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace UnitTests.Middleware
{
    public class ExceptionMiddlewareTests
    {
        [Fact]
        public async Task InvokeAsync_NoExceptionThrownInsideMiddleware_ContextResponseNotModifiedAsync()
        {
            //arrange
            var middleWare = new ExceptionMiddleware(next: async (innerHttpContext) =>
                {
                    await Task.Run(() =>
                    {
                        return HttpStatusCode.OK;
                    });
                });
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //act
            await middleWare.InvokeAsync(context);

            //assert
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var body = reader.ReadToEnd();
            Assert.Equal("", body);
        }

        [Fact]
        public async Task InvokeAsync_InternalServerErrorThrownInsideMiddleware_ContextResponseModifiedAsync()
        {
            //arrange
            string expectedOutput = "{\"Message\":\"Internal server error\"}";
            var middleWare = new ExceptionMiddleware(next: async (innerHttpContext) =>
                {
                    await Task.Run(() =>
                    {
                        throw new Exception();
                    });
                });
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //act
            await middleWare.InvokeAsync(context);

            //assert
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var body = reader.ReadToEnd();
            Assert.Equal(expectedOutput, body);
        }

        [Fact]
        public async Task InvokeAsync_ValidationExceptionThrownInsideMiddleware_ContextResponseModifiedAsync()
        {
            //arrange
            string expectedOutput = "{\"Message\":\"Bad Request\"}";
            var middleWare = new ExceptionMiddleware(next: async (innerHttpContext) =>
            {
                await Task.Run(() =>
                {
                    throw new ValidationException();
                });
            });
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //act
            await middleWare.InvokeAsync(context);

            //assert
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var body = reader.ReadToEnd();
            Assert.Equal(expectedOutput, body);
        }

        [Fact]
        public async Task InvokeAsync_UnauthorizedAccessExceptionThrownInsideMiddleware_ContextResponseModifiedAsync()
        {
            //arrange
            string expectedOutput = "{\"Message\":\"You have no access\"}";
            var middleWare = new ExceptionMiddleware(next: async (innerHttpContext) =>
            {
                await Task.Run(() =>
                {
                    throw new UnauthorizedAccessException();
                });
            });
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //act
            await middleWare.InvokeAsync(context);

            //assert
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var body = reader.ReadToEnd();
            Assert.Equal(expectedOutput, body);
        }

    }
}
