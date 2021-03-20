using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.Entities
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
        public virtual DbSet<LootLine> LootLines { get; set; }
        public virtual DbSet<LootTable> LootTables { get; set; }
        public virtual DbSet<Mob> Mobs { get; set; }
        public virtual DbSet<MobSpawn> MobSpawns { get; set; }
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
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MobId).HasColumnName("mob_id");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Mob)
                    .WithMany(p => p.KillStats)
                    .HasForeignKey(d => d.MobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KillStats__mob_i__2180FB33");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.KillStats)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KillStats__playe__208CD6FA");
            });

            modelBuilder.Entity<LootLine>(entity =>
            {
                entity.ToTable("LootLine");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DropPercentage)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("drop_percentage")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LootTableId).HasColumnName("loot_table_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.WeaponId).HasColumnName("weapon_id");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.LootLines)
                    .HasForeignKey(d => d.WeaponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LootLine__weapon__1CBC4616");
            });

            modelBuilder.Entity<LootTable>(entity =>
            {
                entity.ToTable("LootTable");

                entity.Property(e => e.Id).HasColumnName("id");
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

            modelBuilder.Entity<MobSpawn>(entity =>
            {
                entity.ToTable("MobSpawn");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ModId).HasColumnName("mod_id");

                entity.Property(e => e.SpawnX).HasColumnName("spawn_x");

                entity.Property(e => e.SpawnY).HasColumnName("spawn_y");

                entity.HasOne(d => d.Mod)
                    .WithMany(p => p.MobSpawns)
                    .HasForeignKey(d => d.ModId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MobSpawn__mod_id__07C12930");
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
