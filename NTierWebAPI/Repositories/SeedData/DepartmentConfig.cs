using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.SeedData
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department { DepartmentID = 1, DepartmentName= "IT" },
                new Department { DepartmentID = 2, DepartmentName = "İnsan Kaynakları" },
                new Department { DepartmentID = 3, DepartmentName = "Yazılım" },
                new Department { DepartmentID = 4, DepartmentName = "Finans"},
                new Department { DepartmentID = 5, DepartmentName = "Pazarlama" },
                new Department { DepartmentID = 6, DepartmentName = "Satış" },
                new Department { DepartmentID = 7, DepartmentName = "Müşteri Hizmetleri" },
                new Department { DepartmentID = 8, DepartmentName = "Lojistik" },
                new Department { DepartmentID = 9, DepartmentName = "Mali İşler" },
                new Department { DepartmentID = 10, DepartmentName = "Ar-Ge" }
            );
        }
    }
}