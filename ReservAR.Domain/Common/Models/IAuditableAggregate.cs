namespace ReservAR.Domain.Common.Models;

public interface IAuditableAggregate
{
    void SetCreatedData(DateTime createdDateTime);
    void SetUpdatedData(DateTime updatedDateTime);
    void SetDeletedData(DateTime deletedDateTime);
}
