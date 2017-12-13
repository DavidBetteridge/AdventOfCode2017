namespace Solutions
{
    public class Day13
    {
        public int Calculate(string input)
        {
            var depths = input.Split(new[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            var all = new Location[100];
            foreach (var dep in depths)
            {
                var parts = dep.Split(':');
                var location = int.Parse(parts[0]);
                var depth = int.Parse(parts[1].Trim());
                all[location] = new Location() { CurrentLocation = 0, Increasing = true, TotalDepth = depth };
            }

            var hits = 0;
            for (int picosecond = 0; picosecond < 100; picosecond++)
            {
                var here = all[picosecond];
                if (here != null && here.CurrentLocation == 0)
                {
                    hits += picosecond * here.TotalDepth;
                }

                for (int loc = 0; loc < 100; loc++)
                {
                    var location = all[loc];
                    if (location != null)
                    {
                        if (location.Increasing)
                        {
                            var newLocation = location.CurrentLocation + 1;
                            if (newLocation >= location.TotalDepth)
                            {
                                location.CurrentLocation--;
                                location.Increasing = false;
                            }
                            else
                            {
                                location.CurrentLocation++;
                            }
                        }
                        else
                        {
                            var newLocation = location.CurrentLocation - 1;
                            if (newLocation < 0)
                            {
                                location.CurrentLocation++;
                                location.Increasing = true;
                            }
                            else
                            {
                                location.CurrentLocation--;
                            }
                        }
                    }
                }


            }

            return hits;
        }

        class Location
        {
            public int TotalDepth { get; set; }
            public int CurrentLocation { get; set; }
            public bool Increasing { get; set; }
        }
    }
}
