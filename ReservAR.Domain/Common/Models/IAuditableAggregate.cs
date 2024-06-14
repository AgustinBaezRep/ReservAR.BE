using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservAR.Domain.Common.Models
{
    public interface IAuditableAggregate
    {
        void SetCreatedData(DateTime createdDateTime);
        void SetUpdatedData(DateTime updatedDateTime);
        void SetDeletedData(DateTime deletedDateTime);
    }
}
