static class PalletUtils {
    public static bool IsPackageValid(Package package, QualityMaker palletQualityMaker){

        bool isMassEqual = package.qualityMarker.ProductMass == palletQualityMaker.ProductMass;
        bool isProductTypeEqual = package.qualityMarker.ProductType == palletQualityMaker.ProductType;
        bool isLoosePackage = package.typeOfPackage == PackageType.Loose;

        if(isMassEqual && isProductTypeEqual && isLoosePackage){
            return true;
        }else {
            return false;
        }
    }
}