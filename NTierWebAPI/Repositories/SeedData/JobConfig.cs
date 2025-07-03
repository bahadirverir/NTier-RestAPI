using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.SeedData
{
    public class JobConfig : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasData(
                new Job { JobID = 1, JobTitle = "Yazılım Mühendisi", DepartmentID = 3 },
                new Job { JobID = 2, JobTitle = "Sistem Analisti", DepartmentID = 3 },
                new Job { JobID = 3, JobTitle = "İşe Alım Uzmanı", DepartmentID = 2 },
                new Job { JobID = 4, JobTitle = "Finans Uzmanı", DepartmentID = 4},
                new Job { JobID = 5, JobTitle = "Ağ Mühendisi", DepartmentID = 1},
                new Job { JobID = 6, JobTitle = "Pazarlama Müdürü", DepartmentID = 5 },
                new Job { JobID = 7, JobTitle = "Satış Yöneticisi", DepartmentID = 6 },
                new Job { JobID = 8, JobTitle = "Müşteri Hizmetleri", DepartmentID = 7 },
                new Job { JobID = 9, JobTitle = "Lojistik Uzmanı", DepartmentID = 8 },
                new Job { JobID = 10, JobTitle = "Mali İşler Müdürü", DepartmentID = 8 },
                new Job { JobID = 11, JobTitle = "Ar-Ge Yöneticisi", DepartmentID = 10 },
                new Job { JobID = 12, JobTitle = "Sistem Yöneticisi", DepartmentID = 1 },
                new Job { JobID = 13, JobTitle = "İç Denetçi", DepartmentID = 4 },
                new Job { JobID = 14, JobTitle = "Hukuk Danışmanı", DepartmentID = 9 },
                new Job { JobID = 15, JobTitle = "Mobil Yazılım Uzmanı", DepartmentID = 3 },
                new Job { JobID = 16, JobTitle = "Satış Temsilcisi", DepartmentID = 6 },
                new Job { JobID = 17, JobTitle = "Dijital Pazarlama", DepartmentID = 5 },
                new Job { JobID = 18, JobTitle = "Teknik Servis", DepartmentID = 1 },
                new Job { JobID = 19, JobTitle = "Yazılım Test Uzmanı", DepartmentID = 3 },
                new Job { JobID = 20, JobTitle = "Maliye Uzmanı", DepartmentID = 9 }
            );
        }
    }
}
