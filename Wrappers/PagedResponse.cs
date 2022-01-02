using System;

namespace CRMService.Wrappers
{
    /// <summary>
    /// Обертка ответа контроллера для разбивки на страницы
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResponse<T> : Response<T>
    {
        /// <summary>
        /// Текущая страница
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Элементов на странице
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Ссылка на первую страницу
        /// </summary>
        public Uri FirstPage { get; set; }

        /// <summary>
        /// Ссылка на последнюю страницу
        /// </summary>
        public Uri LastPage { get; set; }

        /// <summary>
        /// Всего страниц
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Всего записей
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Ссылка на следующую страницу
        /// </summary>
        public Uri NextPage { get; set; }

        /// <summary>
        /// Ссылка на предыдущую страницу
        /// </summary>
        public Uri PreviousPage { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Result = data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }
    }
}
