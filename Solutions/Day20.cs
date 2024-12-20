using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day20
    {

        public class Particle
        {
            //
            private long pX;
            private long pY;
            private long pZ;

            private long vX;
            private long vY;
            private long vZ;

            private long aX;
            private long aY;
            private long aZ;

            public int ID { get; }

            public bool Dead { get; set; }

            public long FurthestDistance { get; set; }

            public Particle(int id, int pX, int pY, int pZ, int vX, int vY, int vZ, int aX, int aY, int aZ)
            {
                this.ID = id;

                this.pX = pX;
                this.pY = pY;
                this.pZ = pZ;

                this.aX = aX;
                this.aY = aY;
                this.aZ = aZ;

                this.vX = vX;
                this.vY = vY;
                this.vZ = vZ;

                this.FurthestDistance = long.MinValue;
            }

            public void Next()
            {
                this.vX += this.aX;
                this.vY += this.aY;
                this.vZ += this.aZ;
                this.pX += this.vX;
                this.pY += this.vY;
                this.pZ += this.vZ;
            }

            public long Distance()
            {
                return Math.Abs(pX) + Math.Abs(pY) + Math.Abs(pZ);
            }

            public string Hash()
                => $"{pX},{pY},{pZ}";
        }

        public int FindRemaining(string given)
        {
            var particles = BuildParticles(given);
            var numberAlive = particles.Count;
            var hashes = new Dictionary<string, Particle>();
            for (int i = 0; i < 50000; i++)
            {
                hashes.Clear();
                foreach (var particle in particles.Where(d => !d.Dead))
                {
                    particle.Next();

                    var hash = particle.Hash();
                    if (hashes.TryGetValue(hash, out var dup))
                    {
                        particle.Dead = true;
                        numberAlive--;

                        if (!dup.Dead)
                        {
                            dup.Dead = true;
                            numberAlive--;
                        }
                    }
                    else
                    {
                        hashes.Add(hash, particle);
                    }
                }
            }

            return numberAlive;
        }

        public int FindClosest(string given)
        {
            var particles = BuildParticles(given);

            //Detect cycles
            for (int i = 0; i < 1000; i++)
            {
                foreach (var particle in particles)
                {
                    particle.Next();
                }
            }

            for (int i = 0; i < 50000; i++)
            {
                foreach (var particle in particles)
                {
                    particle.Next();
                    particle.FurthestDistance = Math.Max(particle.FurthestDistance, Math.Abs(particle.Distance()));
                }
            }

            var solution = particles.OrderBy(p => p.FurthestDistance);
            return solution.First().ID;


            //var cyclesOnly = particles.Where(p => p.IsCycle);

            ////Find closest to zero
            //var closestID = -1;
            //var closestDistance = int.MaxValue;
            //for (int i = 0; i < 1000; i++)
            //{
            //    foreach (var particle in cyclesOnly)
            //    {
            //        particle.Next();

            //        var distance = particle.Distance();
            //        if (distance < closestDistance)
            //        {
            //            closestDistance = distance;
            //            closestID = particle.ID;
            //        }
            //    }
            //}

            //return closestID;
        }

        private static List<Particle> BuildParticles(string given)
        {
            var lines = given.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var particles = new List<Particle>();
            var id = 0;
            foreach (var line in lines)
            {
                //p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>
                var bits = line.Split(new[] { ">," }, StringSplitOptions.RemoveEmptyEntries);
                var ps = bits[0].Replace("p=<", "").Replace(">", "").Trim().Split(',').Select(a => int.Parse(a)).ToArray();
                var vs = bits[1].Replace("v=<", "").Replace(">", "").Trim().Split(',').Select(a => int.Parse(a)).ToArray();
                var acs = bits[2].Replace("a=<", "").Replace(">", "").Trim().Split(',').Select(a => int.Parse(a)).ToArray();

                var p = new Particle(id, ps[0], ps[1], ps[2], vs[0], vs[1], vs[2], acs[0], acs[1], acs[2]);
                particles.Add(p);

                id++;
            }

            return particles;
        }
    }
}
