using Charberry_Tree___Events;

CharberryTree tree = new CharberryTree();
Harvester harvester = new Harvester(tree);
Notifier notifier = new Notifier(tree);

while (true)
{
    tree.MaybeGrow();
}