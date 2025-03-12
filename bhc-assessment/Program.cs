QualityMaker maker1 = new QualityMaker("Tobbaco", 212.22);
QualityMaker maker2 = new QualityMaker("Tobbaco", 212.22);
QualityMaker maker3 = new QualityMaker("Tobbaco", 212.22);


Package package1 = new Package("dasd", maker1, PackageType.Loose);
Package package2 = new Package("dasd", maker2, PackageType.Loose);
Package package3 = new Package("dasd3434", maker3, PackageType.Carton);

Package[] loosePackages = [package1, package2, package3];
Line line = new Line(1, 0, LineType.CartonLine, maker1, 10);
line.LoadPackagesToLine(loosePackages);
Console.WriteLine(line.linePackages.Length);