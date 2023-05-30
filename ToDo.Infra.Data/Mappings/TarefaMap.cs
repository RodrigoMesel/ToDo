using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Enums;
using ToDo.Domain.Models;

namespace ToDo.Infra.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("tarefa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.IdResponsavel)
                    .HasColumnName("id_responsavel_fk");

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(500)
                .HasColumnType("varchar(500)");

            builder.Property(x => x.DataPrevista)
                .HasColumnName("data_prevista");

            builder.Property(c => c.StatusTarefa)
                .HasMaxLength(50)
                .HasColumnName("status_tarefa")
                .HasConversion(x => x.ToString(), x => (StatusTarefa)Enum.Parse(typeof(StatusTarefa), x))
                .IsRequired();

            builder.HasOne(x => x.Responsavel)
                .WithMany(u => u.Tarefas)
                .HasForeignKey(x => x.IdResponsavel)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
