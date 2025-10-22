using Parcial_pokemons;
using NUnit.Framework.Legacy;
using System.Security.Cryptography.X509Certificates;

namespace ParcialPokemons
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [TestCase(40)]
        [TestCase(0)]
        [TestCase(-90)]
        [TestCase(256)]
        public void TestMoveCreation(int poder)
        {
            var move = new Move("Bug Bite", Types.Bug, MoveType.Physical, poder);

            ClassicAssert.LessOrEqual(move.BasePower, 255);
            ClassicAssert.GreaterOrEqual(move.BasePower, 1);
        }
        [Test]
        public void TestDefaultMovePower()
        {
            Move move1 = new Move("Bug Bite", Types.Bug, MoveType.Physical);
            Assert.That(move1.BasePower, Is.EqualTo(100));
        }
        [Test]
        public void TestDefaultLevelPokemon()
        {
            Pokemon caterpie = new Pokemon("Caterpie", Types.Grass);

            Assert.That(caterpie.Level, Is.EqualTo(1));
        }
        [Test]
        public void TestDefaultAttack()
        {
            Pokemon caterpie = new Pokemon("Caterpie", Types.Grass);

            Assert.That(caterpie.Attack, Is.EqualTo(10));
        }
        [Test]
        public void TestDefaultDefense()
        {
            Pokemon caterpie = new Pokemon("Caterpie", Types.Grass);

            Assert.That(caterpie.Defense, Is.EqualTo(10));
        }
        [Test]
        public void TestDefaultSpATK()
        {
            Pokemon caterpie = new Pokemon("Caterpie", Types.Grass);

            Assert.That(caterpie.SpecialAttack, Is.EqualTo(10));
        }
        [Test]
        public void TestDefaultSpDEF()
        {
            Pokemon caterpie = new Pokemon("Caterpie", Types.Grass);

            Assert.That(caterpie.SpecialDefense, Is.EqualTo(10));
        }
    }
}