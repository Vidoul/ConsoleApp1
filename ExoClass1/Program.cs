using System;
using System.Collections.Generic;

namespace ZooV1
{
    // ====== Domaine ======
    public enum Habitat { Savane, Aquarium, Jungle }

    public abstract class Animal
    {
        public string Nom { get; }   
        public int Age { get; }

        protected Animal(string nom, int age)
        {
            Nom = nom;
            Age = age;
        }

        // Contrat imposé aux enfants
        public abstract void SeDeplacer();
        public abstract void FaireDuBruit();

        // Comportement commun (réutilisé)
        public virtual void Manger() => Console.WriteLine($"{Nom} mange sa ration.");
    }

    public sealed class Lion : Animal
    {
        public Lion(string nom, int age) : base(nom, age) { }

        public override void SeDeplacer() => Console.WriteLine($"{Nom} marche fièrement dans l'enclos.");
        public override void FaireDuBruit() => Console.WriteLine($"{Nom} rugit : ROAAAR !");
        public override void Manger() => Console.WriteLine($"{Nom} dévore de la viande.");
    }

    public sealed class Pingouin : Animal
    {
        public Pingouin(string nom, int age) : base(nom, age) { }

        public override void SeDeplacer() => Console.WriteLine($"{Nom} nage et glisse sur la glace.");
        public override void FaireDuBruit() => Console.WriteLine($"{Nom} fait : kwa-kwa !");
    }

    public sealed class Serpent : Animal
    {
        public Serpent(string nom, int age) : base(nom, age) { }

        public override void SeDeplacer() => Console.WriteLine($"{Nom} rampe silencieusement.");
        public override void FaireDuBruit() => Console.WriteLine($"{Nom} siffle : ssssss !");
    }

    public class Enclos
    {
        public string Nom { get; }
        public Habitat Habitat { get; }
        private readonly List<Animal> _animaux = new();

        public Enclos(string nom, Habitat habitat)
        {
            Nom = nom;
            Habitat = habitat;
        }

        public void Ajouter(Animal animal) => _animaux.Add(animal);

        public void RoutineDuMatin()
        {
            Console.WriteLine($"\n=== Enclos {Nom} ({Habitat}) ===");
            foreach (var a in _animaux)
            {
                // Polymorphisme : c’est la bonne implémentation qui s’exécute
                a.FaireDuBruit();
                a.SeDeplacer();
                a.Manger();
            }
        }
    }

    public class Zoo
    {
        private readonly List<Enclos> _enclos = new();
        public void AjouterEnclos(Enclos e) => _enclos.Add(e);

        public void LancerRoutine()
        {
            Console.WriteLine("=== Routine du Zoo ===");
            foreach (var e in _enclos) e.RoutineDuMatin();
        }
    }

    // ====== Demo ======
    class Program
    {
        static void Main()
        {
            var zoo = new Zoo();

            var savane = new Enclos("Savane", Habitat.Savane);
            savane.Ajouter(new Lion("Simba", 5));

            var aquarium = new Enclos("Aquarium", Habitat.Aquarium);
            aquarium.Ajouter(new Pingouin("Pingo", 2));

            var jungle = new Enclos("Terrarium", Habitat.Jungle);
            jungle.Ajouter(new Serpent("Kaa", 7));

            zoo.AjouterEnclos(savane);
            zoo.AjouterEnclos(aquarium);
            zoo.AjouterEnclos(jungle);

            zoo.LancerRoutine();
        }
    }
}
