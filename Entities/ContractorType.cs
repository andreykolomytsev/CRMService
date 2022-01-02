using System;

namespace CRMService.Entities
{
    public class ContractorType
    {
        /// <summary>
        /// Типы контрагентов
        /// </summary>
        public enum Type
        {
            IndividualPerson, // Физическое лицо
            LegalPerson, //Юридическое лицо
            Entrepreneur // ИП
        }

        /// <summary>
        /// Проверка на то, существует ли передаваемый тип в перечислении
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <returns></returns>
        public static bool CheckType(object value)
        {
            if (Enum.IsDefined(typeof(ContractorType.Type), value)) return true;
            return false;
        }
    }
}
