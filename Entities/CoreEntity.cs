using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMService.Entities
{
    public class CoreEntity
    {
        public CoreEntity()
        {
            DateCreate = DateUpdate = DateTime.UtcNow;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }

        //Разделение видимости записей по арендаторам (фирмам)
        public int TenantId { get; set; }
    }
}
