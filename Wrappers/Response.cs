using System.Collections.Generic;

namespace CRMService.Wrappers
{
    /// <summary>
    /// Обертка ответа контроллера
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Result = data;
        }

        public Response(string message)
        {
            Succeeded = true;
            Message = message;
        }

        public Response(T data, string message)
        {
            Succeeded = true;
            Message = message;
            Result = data;
        }

        /// <summary>
        /// Успешное выполнение запроса
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Список ошибок
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Сам ответ
        /// </summary>
        public T Result { get; set; }      
    }
}
