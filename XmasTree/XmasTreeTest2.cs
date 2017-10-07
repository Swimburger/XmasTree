using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using XmasTree.Step2;

namespace XmasTree
{
    [TestClass]
    public class XmasTreeTest2
    {
        private static Multiverse multiverse;

        [ClassInitialize]
        public static void InitMultiverse(TestContext context)
        {
            // Fixture setup
            Fixture fixture = new Fixture();
            multiverse = fixture.Create<Multiverse>();
        }


        [TestMethod]
        public void TestXmasTree()
        {
            foreach (var universe in multiverse.Universes)
            {
                foreach (var galaxy in universe.Galaxies)
                {
                    foreach (var planet in galaxy.Planets)
                    {
                        foreach (var continent in planet.Continents)
                        {
                            foreach (var country in continent.Countries)
                            {
                                foreach (var citizen in country.Citizens)
                                {
                                    Console.WriteLine($"{citizen.FirstName} {citizen.LastName}");
                                }
                            }
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void TestDeconstructedXmasTree()
        {
            var citizens = GetCitizens(multiverse);
            foreach (var citizen in citizens)
            {
                Console.WriteLine($"{citizen.FirstName} {citizen.LastName}");
            }
        }

        private List<Citizen> GetCitizens(Multiverse multiverse)
        {
            var citizens = multiverse.Universes
                .SelectMany(universe => universe.Galaxies)
                .SelectMany(galaxy => galaxy.Planets)
                .SelectMany(planet => planet.Continents)
                .SelectMany(continent => continent.Countries)
                .SelectMany(country => country.Citizens)
                .ToList();

            return citizens ?? new List<Citizen>();
        }
    }
}
