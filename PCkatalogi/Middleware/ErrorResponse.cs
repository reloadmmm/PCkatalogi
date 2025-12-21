namespace PCkatalogi.Middleware
{
    /// <summary>
    /// Структурированный ответ об ошибке
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Статус код HTTP
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Детали ошибки 
        /// </summary>
        public string? Details { get; set; }

        /// <summary>
        /// Время возникновения ошибки
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}