using Creatures;

namespace Commands
{
    public class WaitCommand: Command
    {
        public WaitCommand(Creature creature, float duration)
        {
            this.creature = creature;
            this.duration = duration;
        }
        
        public override void Validate(){}
        
        public override void Execute(){}
    }
}