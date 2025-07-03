using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.SeedData
{ 
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee { EmployeeID = 1, FirstName = "Bahadır", LastName = "Verir", Salary = 30000, DepartmentID = 3, JobID = 1 },
                new Employee { EmployeeID = 2, FirstName = "Hakan", LastName = "Yıldırım", Salary = 42000, DepartmentID = 4, JobID = 4 },
                new Employee { EmployeeID = 3, FirstName = "Miyaw", LastName = "Miyawoğlu", Salary = 47500, DepartmentID = 2, JobID = 3 },
                new Employee { EmployeeID = 4, FirstName = "Burak", LastName = "Bozkurt", Salary = 28000, DepartmentID = 3, JobID = 2 },
                new Employee { EmployeeID = 5, FirstName = "Furkan", LastName = "Nerse", Salary = 30000, DepartmentID = 3, JobID = 1 },
                new Employee { EmployeeID = 6, FirstName = "Yasin", LastName = "Burma", Salary = 35000, DepartmentID = 4, JobID = 4},
                new Employee { EmployeeID = 7, FirstName = "Baha", LastName = "Sağlam", Salary = 27500, DepartmentID = 1, JobID = 5},
                new Employee { EmployeeID = 8, FirstName = "Emre", LastName = "Aydın", Salary = 46000, DepartmentID = 1, JobID = 12 },
                new Employee { EmployeeID = 9, FirstName = "Gökhan", LastName = "Kaya", Salary = 38000, DepartmentID = 6, JobID = 7 },
                new Employee { EmployeeID = 10, FirstName = "Mehmet", LastName = "Öztürk", Salary = 42000, DepartmentID = 5, JobID = 6 },
                new Employee { EmployeeID = 11, FirstName = "İsmail", LastName = "Güven", Salary = 39000, DepartmentID = 3, JobID = 2 },
                new Employee { EmployeeID = 12, FirstName = "Ayşe", LastName = "Kara", Salary = 52000, DepartmentID = 10, JobID = 11 },
                new Employee { EmployeeID = 13, FirstName = "Zeynep", LastName = "Ekinci", Salary = 41000, DepartmentID = 9, JobID = 14 },
                new Employee { EmployeeID = 14, FirstName = "Serdar", LastName = "Turan", Salary = 48000, DepartmentID = 3, JobID = 15 },
                new Employee { EmployeeID = 15, FirstName = "Hasan", LastName = "Demir", Salary = 37500, DepartmentID = 1, JobID = 18 },
                new Employee { EmployeeID = 16, FirstName = "Seda", LastName = "Koç", Salary = 34000, DepartmentID = 6, JobID = 16 },
                new Employee { EmployeeID = 17, FirstName = "Deniz", LastName = "Büyük", Salary = 47000, DepartmentID = 7, JobID = 8 },
                new Employee { EmployeeID = 18, FirstName = "Ali", LastName = "Şahin", Salary = 39000, DepartmentID = 8, JobID = 9 },
                new Employee { EmployeeID = 19, FirstName = "Zeynep", LastName = "Can", Salary = 47000, DepartmentID = 5, JobID = 17 },
                new Employee { EmployeeID = 20, FirstName = "Ömer", LastName = "Görkem", Salary = 46000, DepartmentID = 4, JobID = 13 },
                new Employee { EmployeeID = 21, FirstName = "Cem", LastName = "Yılmaz", Salary = 42000, DepartmentID = 3, JobID = 19 },
                new Employee { EmployeeID = 22, FirstName = "Hüseyin", LastName = "Topal", Salary = 43000, DepartmentID = 3, JobID = 2 },
                new Employee { EmployeeID = 23, FirstName = "Özgür", LastName = "Balkaya", Salary = 55000, DepartmentID = 1, JobID = 5 },
                new Employee { EmployeeID = 24, FirstName = "Gül", LastName = "Aslan", Salary = 46000, DepartmentID = 9, JobID = 20 },
                new Employee { EmployeeID = 25, FirstName = "Burcu", LastName = "Duman", Salary = 35000, DepartmentID = 5, JobID = 6 },
                new Employee { EmployeeID = 26, FirstName = "Sefa", LastName = "Sarı", Salary = 52000, DepartmentID = 10, JobID = 11 },
                new Employee { EmployeeID = 27, FirstName = "Neslihan", LastName = "Güzel", Salary = 42000, DepartmentID = 4, JobID = 4 },
                new Employee { EmployeeID = 28, FirstName = "Murat", LastName = "Öztürk", Salary = 46000, DepartmentID = 1, JobID = 12 },
                new Employee { EmployeeID = 29, FirstName = "Emine", LastName = "Çelik", Salary = 43000, DepartmentID = 2, JobID = 3 },
                new Employee { EmployeeID = 30, FirstName = "Fatma", LastName = "Kocaoğlu", Salary = 48000, DepartmentID = 3, JobID = 2 },
                new Employee { EmployeeID = 31, FirstName = "Bahadır", LastName = "Akdoğan", Salary = 44000, DepartmentID = 6, JobID = 16 },
                new Employee { EmployeeID = 32, FirstName = "Mert", LastName = "Özdemir", Salary = 47000, DepartmentID = 7, JobID = 8 },
                new Employee { EmployeeID = 33, FirstName = "İrem", LastName = "Erdem", Salary = 42000, DepartmentID = 8, JobID = 9 },
                new Employee { EmployeeID = 34, FirstName = "Fatih", LastName = "Duran", Salary = 50000, DepartmentID = 5, JobID = 17 },
                new Employee { EmployeeID = 35, FirstName = "Büşra", LastName = "Arslan", Salary = 46000, DepartmentID = 9, JobID = 14 },
                new Employee { EmployeeID = 36, FirstName = "Hakan", LastName = "Aksu", Salary = 49000, DepartmentID = 3, JobID = 19 },
                new Employee { EmployeeID = 37, FirstName = "Eda", LastName = "Aslan", Salary = 42000, DepartmentID = 4, JobID = 13 },
                new Employee { EmployeeID = 38, FirstName = "Selim", LastName = "Kılıç", Salary = 43000, DepartmentID = 10, JobID = 11 },
                new Employee { EmployeeID = 39, FirstName = "Cemre", LastName = "Çetin", Salary = 46000, DepartmentID = 1, JobID = 5 },
                new Employee { EmployeeID = 40, FirstName = "Berk", LastName = "Koç", Salary = 48000, DepartmentID = 2, JobID = 3 },
                new Employee { EmployeeID = 41, FirstName = "Sinem", LastName = "Yalçın", Salary = 45000, DepartmentID = 2, JobID = 3 },
                new Employee { EmployeeID = 42, FirstName = "Tolga", LastName = "Demirtaş", Salary = 32000, DepartmentID = 3, JobID = 1 },
                new Employee { EmployeeID = 43, FirstName = "Melis", LastName = "Özkan", Salary = 38000, DepartmentID = 6, JobID = 16 },
                new Employee { EmployeeID = 44, FirstName = "Kerem", LastName = "Akın", Salary = 29000, DepartmentID = 1, JobID = 18 },
                new Employee { EmployeeID = 45, FirstName = "Derya", LastName = "Karataş", Salary = 47000, DepartmentID = 5, JobID = 17 },
                new Employee { EmployeeID = 46, FirstName = "Barış", LastName = "Erdoğan", Salary = 44000, DepartmentID = 10, JobID = 11 },
                new Employee { EmployeeID = 47, FirstName = "Ebru", LastName = "Acar", Salary = 36000, DepartmentID = 4, JobID = 13 },
                new Employee { EmployeeID = 48, FirstName = "Can", LastName = "Uysal", Salary = 31000, DepartmentID = 3, JobID = 15 },
                new Employee { EmployeeID = 49, FirstName = "Nazlı", LastName = "Özsoy", Salary = 42000, DepartmentID = 9, JobID = 14 },
                new Employee { EmployeeID = 50, FirstName = "Fırat", LastName = "Sarı", Salary = 48000, DepartmentID = 3, JobID = 19 },
                new Employee { EmployeeID = 51, FirstName = "Aylin", LastName = "Güney", Salary = 35000, DepartmentID = 7, JobID = 8 },
                new Employee { EmployeeID = 52, FirstName = "Serkan", LastName = "Doğan", Salary = 41000, DepartmentID = 1, JobID = 12 },
                new Employee { EmployeeID = 53, FirstName = "Pelin", LastName = "Kaya", Salary = 47000, DepartmentID = 6, JobID = 7 },
                new Employee { EmployeeID = 54, FirstName = "Murat", LastName = "Şen", Salary = 45000, DepartmentID = 4, JobID = 13 },
                new Employee { EmployeeID = 55, FirstName = "Elif", LastName = "Çetin", Salary = 39000, DepartmentID = 2, JobID = 3 },
                new Employee { EmployeeID = 56, FirstName = "Onur", LastName = "Demir", Salary = 30000, DepartmentID = 8, JobID = 9 },
                new Employee { EmployeeID = 57, FirstName = "İlker", LastName = "Yılmaz", Salary = 50000, DepartmentID = 5, JobID = 6 },
                new Employee { EmployeeID = 58, FirstName = "Selin", LastName = "Özdemir", Salary = 43000, DepartmentID = 10, JobID = 11 },
                new Employee { EmployeeID = 59, FirstName = "Tuna", LastName = "Kılıç", Salary = 34000, DepartmentID = 1, JobID = 18 },
                new Employee { EmployeeID = 60, FirstName = "Damla", LastName = "Aydın", Salary = 46000, DepartmentID = 9, JobID = 20 }
            );
        }
    }
}