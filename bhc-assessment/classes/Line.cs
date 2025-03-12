
enum LineType {
    PalletLine,
    CartonLine
}

class Line(int lineNumber, double maxLineCapacity, LineType lineType, QualityMaker lineQualityMarker, int maxNumOfCartons)
{
    private int lineNumber = lineNumber;
    private double maxLineCapacity = maxLineCapacity; // in kgs or 0

    private int maxNumOfCartons = maxNumOfCartons; // num or 0

    public Package[] linePackages = [];

    public Pallet[] linePallets = [];

    public string orderOfOffloading = "newest";

    private LineType lineType = lineType;

    private QualityMaker lineQualityMarker = lineQualityMarker;


    // ======= Methods ===============


    // loading package (cartons)

    public string LoadPackagesToLine(Package[] packages) {


        if(lineType == LineType.PalletLine){
            return "You cannot add a carton to a pallet line";
        }
        
        Package[] packagesWithValidQualityMaker = Array.FindAll(
            packages, 
            (package) => LineUtils.IsPackageValidForLine(package, lineQualityMarker)
        );

        bool doesLineHaveCapacity = packagesWithValidQualityMaker.Length + linePackages.Length <= maxNumOfCartons; // since packages here are cartons

        if(!doesLineHaveCapacity){
            return "Line does not have enough capacity left to execute this operation";
        }

        Package[] merged = [.. linePackages, .. packagesWithValidQualityMaker];
        linePackages = merged;

        return "Valid packages added";
    }


    // Loading a pallet

    public string LoadPalletToLine(Pallet[] pallets) {


        if(lineType == LineType.CartonLine){
            return "You cannot add a pallet to a carton line";
        }
        
        Pallet[] palletsWithValidQualityMaker = Array.FindAll(
            pallets, 
            (pallet) => LineUtils.IsPalletValidForLine(pallet, lineQualityMarker)
        );
        bool doesLineHaveCapacity = LineUtils.calculateTotalPalletsWeight(palletsWithValidQualityMaker) <= maxLineCapacity;

        if(!doesLineHaveCapacity){
            return "Line does not have enough capacity left to execute this operation";
        }

        Pallet[] merged = [.. linePallets, .. palletsWithValidQualityMaker];
        linePallets = merged;

        return "Valid packages added";
    }

    // offloading pallets and packages
    public Package OffLoadAPackageBySerialNumber(string serialNumber){

        Package[] packageToBeOffloaded = [.. linePackages.Where(p => p.SerialNumber == serialNumber)];
        Package[] filteredPackages = [.. linePackages.Where(p => p.SerialNumber != serialNumber)];
        linePackages = filteredPackages;
        return packageToBeOffloaded[0]; // use this to load on a rack
    }

    public Pallet OffLoadAPalletSerialNumber(string serialNumber){

        Pallet[] palletToBeOffloaded = [.. linePallets.Where(p => p.SerialNumber == serialNumber)];
        Pallet[] filteredPackages = [.. linePallets.Where(p => p.SerialNumber != serialNumber)];
        linePallets = filteredPackages;
        return palletToBeOffloaded[0]; // use this to load on a rack
    }



    public string OffloadAPackage(){

        Console.WriteLine($"Offloading in ${orderOfOffloading} order");

        if(orderOfOffloading == "newest"){
            Package[] newPackages = [.. linePackages.Take(linePackages.Length - 1)];
            linePackages = newPackages;
        }else {
            Package[] newPackages = [.. linePackages.Skip(1)];
            linePackages = newPackages;
        }

        return "Package offloaded";

    }

    public string OffloadAPallet(){

        Console.WriteLine($"Offloading in ${orderOfOffloading} order");

        if(orderOfOffloading == "newest"){
            Pallet[] newPallets = [.. linePallets.Take(linePallets.Length - 1)];
            linePallets = newPallets;
        }else {
            Pallet[] newPallets = [.. linePallets.Skip(1)];
            linePallets = newPallets;
        }

        return "Package offloaded";

    }


    // Properties

    public int LineNumber {
        get {
            return lineNumber;
        }

        set {
            lineNumber = value;
        }
    }

    public LineType LineType {
        get {
            return lineType;
        }

        set {
            lineType = value;
        }
    }

    public double MaxLineCapacity {
        get {
            return maxLineCapacity;
        }

        set {
            maxLineCapacity = value;
        }
    }
}