using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess
{
    public partial class Project2Context : DbContext
    {
        public Project2Context()
        {
        }

        public Project2Context(DbContextOptions<Project2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Consumable> Consumables { get; set; }
        public virtual DbSet<KillStat> KillStats { get; set; }
        public virtual DbSet<LootTable> LootTables { get; set; }
        public virtual DbSet<Lootline> Lootlines { get; set; }
        public virtual DbSet<Mob> Mobs { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("Character");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attack)
                    .HasColumnName("attack")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CharacterName)
                    .HasMaxLength(50)
                    .HasColumnName("character_name");

                entity.Property(e => e.Defense)
                    .HasColumnName("defense")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Exp)
                    .HasColumnName("exp")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Health)
                    .HasColumnName("health")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.Mana)
                    .HasColumnName("mana")
                    .HasDefaultValueSql("((10))");
            });

            modelBuilder.Entity<Consumable>(entity =>
            {
                entity.ToTable("Consumable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("item_name");

                entity.Property(e => e.Strength).HasColumnName("strength");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<KillStat>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ModId).HasColumnName("mod_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Mod)
                    .WithMany(p => p.KillStats)
                    .HasForeignKey(d => d.ModId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KillStats__mod_i__00200768");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KillStats)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KillStats__user___7F2BE32F");
            });

            modelBuilder.Entity<LootTable>(entity =>
            {
                entity.ToTable("LootTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MobId).HasColumnName("mob_id");

                entity.HasOne(d => d.Mob)
                    .WithMany(p => p.LootTables)
                    .HasForeignKey(d => d.MobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LootTable__mob_i__6FE99F9F");
            });

            modelBuilder.Entity<Lootline>(entity =>
            {
                entity.ToTable("Lootline");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DropPercentage)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("drop_percentage");

                entity.Property(e => e.LootTableId).HasColumnName("loot_table_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.WeaponId).HasColumnName("weapon_id");

                entity.HasOne(d => d.LootTable)
                    .WithMany(p => p.Lootlines)
                    .HasForeignKey(d => d.LootTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lootline__loot_t__03F0984C");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.Lootlines)
                    .HasForeignKey(d => d.WeaponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lootline__weapon__04E4BC85");
            });

            modelBuilder.Entity<Mob>(entity =>
            {
                entity.ToTable("Mob");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attack).HasColumnName("attack");

                entity.Property(e => e.Defense)
                    .HasColumnName("defense")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Exp).HasColumnName("exp");

                entity.Property(e => e.Health).HasColumnName("health");

                entity.Property(e => e.LootTableId).HasColumnName("loot_table_id");

                entity.Property(e => e.Speed)
                    .HasColumnName("speed")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.LootTable)
                    .WithMany(p => p.Mobs)
                    .HasForeignKey(d => d.LootTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mob__loot_table___7C4F7684");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CharacterId).HasColumnName("character_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("username");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.CharacterId)
                    .HasConstraintName("FK__Player__characte__72C60C4A");
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.ToTable("Weapon");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttackSpeed)
                    .HasColumnName("attack_speed")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Damage).HasColumnName("damage");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.LevelRequirement)
                    .HasColumnName("level_requirement")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Rarity)
                    .HasMaxLength(50)
                    .HasColumnName("rarity")
                    .HasDefaultValueSql("('common')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
