using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using XmasTree.Step1;

namespace XmasTree
{
    [TestClass]
    public class XmasTreeTest
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
            if (multiverse.Universes != null)
            {
                foreach (var universe in multiverse.Universes)
                {
                    if (universe.Galaxies != null)
                    {
                        foreach (var galaxy in universe.Galaxies)
                        {
                            if (galaxy.Planets != null)
                            {
                                foreach (var planet in galaxy.Planets)
                                {
                                    if (planet.Continents != null)
                                    {
                                        foreach (var continent in planet.Continents)
                                        {
                                            if (continent.Countries != null)
                                            {
                                                foreach (var country in continent.Countries)
                                                {
                                                    if (country.Citizens != null)
                                                    {
                                                        foreach (var citizen in country.Citizens)
                                                        {
                                                            Trace.WriteLine($"{citizen.FirstName} {citizen.LastName}");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void TestSmallerXmasTree()
        {
            if (multiverse.Universes == null)
            {
                return;
            }

            foreach (var universe in multiverse.Universes)
            {
                if (universe.Galaxies == null)
                {
                    continue;
                }

                foreach (var galaxy in universe.Galaxies)
                {
                    if (galaxy.Planets == null)
                    {
                        continue;
                    }

                    foreach (var planet in galaxy.Planets)
                    {
                        if (planet.Continents == null)
                        {
                            continue;
                        }

                        foreach (var continent in planet.Continents)
                        {
                            if (continent.Countries == null)
                            {
                                continue;
                            }

                            foreach (var country in continent.Countries)
                            {
                                if (country.Citizens == null)
                                {
                                    continue;
                                }

                                foreach (var citizen in country.Citizens)
                                {
                                    Trace.WriteLine($"{citizen.FirstName} {citizen.LastName}");
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
            foreach(var citizen in citizens)
            {
                Trace.WriteLine($"{citizen.FirstName} {citizen.LastName}");
            }
        }

        private List<Citizen> GetCitizens(Multiverse multiverse)
        {
            var citizens = multiverse.Universes
                ?.SelectMany(universe => universe.Galaxies)
                ?.SelectMany(galaxy => galaxy.Planets)
                ?.SelectMany(planet => planet.Continents)
                ?.SelectMany(continent => continent.Countries)
                ?.SelectMany(country => country.Citizens)
                ?.ToList();

            return citizens ?? new List<Citizen>();
        }
    }
}
