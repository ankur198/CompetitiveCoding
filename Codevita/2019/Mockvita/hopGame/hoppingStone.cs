using System;
using System.Collections.Generic;
using System.Text;

namespace hopGame
{
    class HoppingStone
    {
        public int Value { get; set; }
        public HoppingStone(int value)
        {
            Value = value;
        }
    }

    class Path
    {
        public List<HoppingStone> hoppingStones = new List<HoppingStone>();
        public int index = 0;
        public bool isDoubleJumpAllowed = true;
        public int Score { get; set; }

        public Path makeCopy()
        {
            var child = new Path() { index = index, isDoubleJumpAllowed = isDoubleJumpAllowed, Score = Score };
            child.hoppingStones = new List<HoppingStone>(hoppingStones);
            return child;
        }
    }

    class Builder
    {
        readonly List<HoppingStone> AllHoppingStones;

        public int max = 0;
        public Path maxp = null;
        public Builder(int[] stones)
        {
            AllHoppingStones = new List<HoppingStone>();
            foreach (var item in stones)
            {
                AllHoppingStones.Add(new HoppingStone(item));
            }
        }

        public void start()
        {
            Traverse(new Path());
        }

        void Traverse(Path parent)
        {
            if (parent.index == AllHoppingStones.Count)
            {
                //max = Math.Max(max, parent.Score);
                if (max < parent.Score)
                {
                    max = parent.Score;
                    maxp = parent;
                }
            }

            else if (isFeasable(parent))
            {
                // no jump
                var child = parent.makeCopy();
                var landedStone = AllHoppingStones[child.index];
                child.hoppingStones.Add(landedStone);
                child.Score += landedStone.Value;
                child.index++;

                Traverse(child);

                if (isSingleJumpFeasable(parent))
                {
                    var child1 = parent.makeCopy();
                    landedStone = AllHoppingStones[child1.index + 1];
                    child1.hoppingStones.Add(landedStone);
                    child1.Score += 2 * landedStone.Value;
                    child1.index += 2;

                    Traverse(child1);

                    if (isDoubleJumpFeasable(parent))
                    {
                        var child2 = parent.makeCopy();
                        child2.isDoubleJumpAllowed = false;
                        landedStone = AllHoppingStones[child2.index + 2];
                        child2.hoppingStones.Add(landedStone);
                        child2.Score += 3 * landedStone.Value;
                        child2.index += 3;

                        Traverse(child2);
                    }
                    
                }
                
            }
        }
        bool isFeasable(Path path)
        {
            return path.index < AllHoppingStones.Count;
        }
        bool isSingleJumpFeasable(Path path)
        {
            return path.index + 1 < AllHoppingStones.Count;
        }
        bool isDoubleJumpFeasable(Path path)
        {
            return path.index + 2 < AllHoppingStones.Count && path.isDoubleJumpAllowed;
        }
    }
}
