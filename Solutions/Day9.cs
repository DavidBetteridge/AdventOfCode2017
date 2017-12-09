using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions
{
    public class Day9
    {

        public int CountGroups(string stream)
        {
            int DoWork(Group grp)
            {
                var r = 1;
                foreach (var child in grp.Children)
                {
                    r += DoWork(child);
                }
                return r;
            }


            var (rootGroup,_) = BuildGroups(stream);
            var result = DoWork(rootGroup);

            return result;
        }

        private (Group,int) BuildGroups(string stream)
        {
            var groups = new Stack<Group>();
            var rootGroup = new Group();
            groups.Push(rootGroup);

            var inGarbage = false;
            var inCancel = false;
            var garbageCount = 0;

            for (int i = 1; i < stream.Length - 1; i++)
            {
                var token = stream[i];

                if (!inCancel)
                {
                    switch (token)
                    {
                        case '{':
                            //New group, add to current group
                            if (!inGarbage)
                            {
                                var newGroup = new Group();
                                groups.Peek().Children.Add(newGroup);
                                groups.Push(newGroup);
                            }
                            else
                            {
                                garbageCount++;
                            }
                            break;
                        case '}':
                            if (!inGarbage)
                            {
                                groups.Pop();
                            }
                            else
                            {
                                garbageCount++;
                            }
                            break;
                        case '<':
                            if (!inGarbage)
                            {
                                inGarbage = true;
                            }
                            else
                            {
                                garbageCount++;
                            }
                            break;
                        case '>':
                            inGarbage = false;
                            break;
                        case '!':
                            inCancel = true;
                            break;
                        default:
                            if (inGarbage)
                            {
                                garbageCount++;
                            }
                            break;
                    }
                }
                else
                {
                    inCancel = false;
                }

            }

            return (rootGroup,garbageCount);
        }

        public int CountGarbage(string stream)
        {
            var (_, result) = BuildGroups(stream);
            return result;
        }

        public int ScoreGroups(string stream)
        {
            int DoWork(Group grp, int scoreForThisGroup)
            {
                var r = scoreForThisGroup;
                foreach (var child in grp.Children)
                {
                    r += DoWork(child, scoreForThisGroup + 1);
                }
                return r;
            }


            var (rootGroup, _) = BuildGroups(stream);
            var result = DoWork(rootGroup, 1);

            return result;
        }

        private class Group
        {
            public List<Group> Children { get; set; }

            public Group()
            {
                this.Children = new List<Group>();
            }
        }
    }
}
