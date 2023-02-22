using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;
using WebProductionAccounting.Domain.Entities;
using WebProductionAccounting.Domain.Enum;
using static System.Formats.Asn1.AsnWriter;

namespace WebProductionAccounting.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

            try
            {
                Database.EnsureCreated();
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
            }

        }

        /** Сотрудники */
        public DbSet<Employee> Employees { get; set; }

        /** Работы */
        public DbSet<Work> Works { get; set; }

        /** Связь многие ко многим между Сотрудниками и Работами */
        public DbSet<EmployeeWork> EmployeeWorks { get; set; }

        /** Настройка модели */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("employees");

            // Добавление записей в сущность Сотрудники по умолчанию 
            var employees = new Employee[]
                  {
                    new()
                    {
                    Id = 1,
                    Lastname = "Михайлов",
                    Firstname = "Станислав",
                    Middlename = "Александрович",
                    PersonnelNumber = 18011993,
                    Position = EmployeePositions.Programmer,
                    DateOfEmployment = DateTime.Now
                    },
                    new()
                    {
                    Id = 2,
                    Lastname = "Иванов",
                    Firstname = "Петр",
                    Middlename = "Николаевич",
                    PersonnelNumber = 00000001,
                    Position = EmployeePositions.ProcessEngineer,
                    DateOfEmployment = DateTime.Now
                    }
                  };

            // Добавление записей в сущность Работы по умолчанию
            var works = new Work[]
            {
                new()
                {
                Id = 1,
                Name = "Разработка ПО",
                Scope = 20.00,
                DateTimeImplementation = DateTime.Now
                },
                new()
                {
                Id = 2,
                Name = "Составление техноческого задания",
                Scope = 5.25,
                DateTimeImplementation = DateTime.Now
                },
                new()
                {
                Id = 3,
                Name = "Заполнение документации",
                Scope = 3.75,
                DateTimeImplementation = DateTime.Now
                }

            };

            // Многие ко многим
            var employee_works = new EmployeeWork[]
            {
                new()
                {
                    EmployeeId = 1,
                    WorkId = 1
                },
                new()
                {
                    EmployeeId = 1,
                    WorkId = 2
                },
                new()
                {
                    EmployeeId = 2,
                    WorkId = 3
                }
            };


            //modelBuilder.Entity<Employee>(b =>
            //{
            //    b.ToTable("Employees").HasKey(e => e.Id);

            //    b.HasData(employees);
            //});


            //modelBuilder.Entity<Work>(b =>
            //{
            //    b.ToTable("Works").HasKey(w => w.Id);

            //    b.HasData(works);

            //});


            //modelBuilder.Entity<EmployeeWork>()
            //.HasKey(w => new { w.EmployeeId, w.WorkId });

            //modelBuilder.Entity<EmployeeWork>()
            //    .HasOne(ew => ew.Employee)
            //    .WithMany(e => e.EmployeeWorks)
            //    .HasForeignKey(ew => ew.EmployeeId);

            //modelBuilder.Entity<EmployeeWork>()
            //    .HasOne(ew => ew.Work)
            //    .WithMany(w => w.EmployeeWorks)
            //    .HasForeignKey(w => w.WorkId);

            //modelBuilder.Entity<EmployeeWork>(b =>
            //{
            //    b.ToTable("EmployeeWorks");
            //    b.HasData(employee_works);
            //});

            modelBuilder.Entity<Employee>(b =>
            {
                b.ToTable("Employees").HasKey(e => e.Id);

                b.HasData(employees);
            });


            modelBuilder.Entity<Work>(b =>
            {
                b.ToTable("Works").HasKey(w => w.Id);

                b.HasData(works);
            });

            modelBuilder
                .Entity<Employee>()
                .HasMany(e => e.Works)
                .WithMany(w => w.Employees)
                .UsingEntity<EmployeeWork>(
                   j => j
                    .HasOne(ew => ew.Work)
                    .WithMany(w => w.EmployeeWorks)
                    .HasForeignKey(ew => ew.WorkId), // связь с таблицей Works через WorkId 
                j => j
                    .HasOne(ew => ew.Employee)
                    .WithMany(e => e.EmployeeWorks)
                    .HasForeignKey(ew => ew.EmployeeId), // связь с таблицей Employees через EmployeeIdd
                j =>
                {
                    j.HasKey(ew => new { ew.EmployeeId, ew.WorkId });
                    j.HasData(employee_works);
                    j.ToTable("EmployeeWorks");
                });
            }

    }

    }
