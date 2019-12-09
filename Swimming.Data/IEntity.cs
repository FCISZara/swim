using System;

namespace Swimming.Data
{
    public interface IEntity
    {
        Guid Id { get; set; }
        string CreatedBy { get; set; }
        DateTime CreationDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModificationDate { get; set; }
        bool? IsActive { get; set; }

    }
}
