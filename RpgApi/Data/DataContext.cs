using Microsoft.EntityFrameworkCore;
using RpgApi.Models;
using RpgApi.Models.Enuns;
using RpgApi.Utils;

namespace RpgApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }
        public DbSet<PersonagemHabilidade> PersonagemHabilidades { get; set; }
        public DbSet<Disputa> Disputas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personagem>().HasData
            (
                new Personagem() { Id = 1, Nome = "Frodo", PontosVida = 100, Forca = 17, Defesa = 23, Inteligencia = 33, Classe = ClasseEnum.Cavaleiro },
                new Personagem() { Id = 2, Nome = "Sam", PontosVida = 100, Forca = 15, Defesa = 25, Inteligencia = 30, Classe = ClasseEnum.Cavaleiro },
                new Personagem() { Id = 3, Nome = "Galadriel", PontosVida = 100, Forca = 18, Defesa = 21, Inteligencia = 35, Classe = ClasseEnum.Clerigo },
                new Personagem() { Id = 4, Nome = "Gandalf", PontosVida = 100, Forca = 18, Defesa = 18, Inteligencia = 37, Classe = ClasseEnum.Mago },
                new Personagem() { Id = 5, Nome = "Hobbit", PontosVida = 100, Forca = 20, Defesa = 17, Inteligencia = 31, Classe = ClasseEnum.Cavaleiro },
                new Personagem() { Id = 6, Nome = "Celeborn", PontosVida = 100, Forca = 21, Defesa = 13, Inteligencia = 34, Classe = ClasseEnum.Clerigo },
                new Personagem() { Id = 7, Nome = "Radagast", PontosVida = 100, Forca = 25, Defesa = 11, Inteligencia = 35, Classe = ClasseEnum.Mago }
            );

            modelBuilder.Entity<Arma>().HasData
            (
                new Arma() { Id = 1, Nome = "Lanca", Dano = 10, PersonagemId = 1},
                new Arma() { Id = 2, Nome = "Machado", Dano = 20, PersonagemId = 2},
                new Arma() { Id = 3, Nome = "Picareta", Dano = 30, PersonagemId = 3},
                new Arma() { Id = 4, Nome = "Pistola", Dano = 40, PersonagemId = 4},
                new Arma() { Id = 5, Nome = "Manopla", Dano = 50, PersonagemId = 5},
                new Arma() { Id = 6, Nome = "Chicote", Dano = 60, PersonagemId = 6},
                new Arma() { Id = 7, Nome = "Arco", Dano = 70, PersonagemId = 7}
            );

            modelBuilder.Entity<PersonagemHabilidade>()
                .HasKey(ph => new { ph.PersonagemId, ph.HabilidadeId });

            modelBuilder.Entity<Habilidade>().HasData
            (
                new Habilidade() { Id = 1, Nome = "Adormecer", Dano = 39 },
                new Habilidade() { Id = 2, Nome = "Congelar", Dano = 41 },
                new Habilidade() { Id = 3, Nome = "Hipnotizar", Dano = 37 }
            );

            modelBuilder.Entity<PersonagemHabilidade>().HasData
            (
                new PersonagemHabilidade() { PersonagemId = 1, HabilidadeId = 1 },
                new PersonagemHabilidade() { PersonagemId = 1, HabilidadeId = 2 },
                new PersonagemHabilidade() { PersonagemId = 2, HabilidadeId = 2 },
                new PersonagemHabilidade() { PersonagemId = 3, HabilidadeId = 2 },
                new PersonagemHabilidade() { PersonagemId = 3, HabilidadeId = 3 },
                new PersonagemHabilidade() { PersonagemId = 4, HabilidadeId = 3 },
                new PersonagemHabilidade() { PersonagemId = 5, HabilidadeId = 1 },
                new PersonagemHabilidade() { PersonagemId = 6, HabilidadeId = 2 },
                new PersonagemHabilidade() { PersonagemId = 7, HabilidadeId = 3 }
            );

            //In??cio da cria????o do usu??rio padr??o.
            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "Admin";

            modelBuilder.Entity<Usuario>().HasData(user);
            //Fim da cria????o do usu??rio padr??o.   

            //Define que se o Perfil n??o for informado, o valor padr??o ser?? jogador
            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Jogador");
        }
        
    }
}