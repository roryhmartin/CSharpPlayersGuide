
using Generics___Colored_Items;

ColoredItem<Sword> sword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);
ColoredItem<Bow> bow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Green);
ColoredItem<Axe> axe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Yellow);

sword.Display();
bow.Display();
axe.Display();