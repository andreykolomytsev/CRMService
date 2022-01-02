using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMService.DTOModels
{
    /// <summary>
    /// Текущий авторизованный пользователь
    /// </summary>
    public class Account
    {
        public int Id { get; set; }

        /// PERMISSIONS

        public int TenantId { get; set; }
    }
}
