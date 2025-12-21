namespace PCkatalogi.Middleware
{
    /// <summary>
    /// Методы расширения для регистрации middleware
    /// </summary>
    public static class ErrorHandlingMiddlewareExtensions
    {
        /// <summary>
        /// Добавляет глобальный обработчик исключений в конвейер middleware
        /// </summary>
        public static IApplicationBuilder UseGlobalErrorHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}   