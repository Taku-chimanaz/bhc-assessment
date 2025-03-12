enum PackageType {
 Loose,
 Carton,

}
class Package {

    private string serialNumber;
    public QualityMaker qualityMarker;
    public PackageType typeOfPackage;

    public Package(string serialNumber, QualityMaker qualityMarker, PackageType typeOfPackage) {
        this.serialNumber = serialNumber;
        this.qualityMarker = qualityMarker;
        this.typeOfPackage = typeOfPackage;
    }


    public string SerialNumber{
        get {
            return serialNumber;
        }

        set {
            serialNumber = value;
        }
    }

    public PackageType TypeOfPackage {
        get {
            return typeOfPackage;
        }

        set {
            typeOfPackage = value;
        }
    }
    
}