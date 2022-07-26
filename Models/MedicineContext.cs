using Microsoft.EntityFrameworkCore;

namespace MedicineTag.Models;

public partial class MedicineContext : DbContext
{
    public MedicineContext()
    {

    }

    public MedicineContext(DbContextOptions<MedicineContext> options):base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;database=medicinetag;user=root;password=sky77619", new MySqlServerVersion(new Version(8, 0, 29)));
        }
    }

    public virtual DbSet<MedicineInfo> medicineInfos{get;set;}

    public virtual DbSet<MedicineClass> medicineClass { get; set; }
}